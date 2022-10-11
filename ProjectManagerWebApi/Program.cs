using Microsoft.EntityFrameworkCore;
using ProjectManagerWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Task = ProjectManagerWebApi.Models.Tasks;
using Project = ProjectManagerWebApi.Models.Projects;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using ProjectManagerWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSqlServer<ProjectTrackerContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProjectTrackerContext>(o => o.UseSqlServer(connString));
builder.Services.AddScoped<ProjectTrackerContextProcedures>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/tasks", async ([FromServices] ProjectTrackerContext db) =>
{ return await db.Tasks.ToListAsync(); });


app.MapGet("api/task_sp/{id}", async ([FromServicesAttribute] ProjectTrackerContextProcedures db, int id) =>
{
    var op = new OutputParameter<int>();
    return await db.sp_Select_TaskAsync(id, op);
});

app.MapPost("api/task_dto", async ([FromServices] ProjectTrackerContext db,
       [FromBody] Task task) =>
{
    var newTask = new Task()
    {
        TaskName = task.TaskName,
        DateUpdated = DateTime.Now,
        DateDue = task.DateDue,
        ProjectId = task.ProjectId,
        AssignedToEmail = task.AssignedToEmail,
        Priority = task.Priority,
    };
    await db.Tasks.AddAsync(newTask);
    await db.SaveChangesAsync();
    return Results.Ok(newTask);
});

app.MapPost("api/task", async ([FromServices] ProjectTrackerContext db,
        Task task) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Ok(task);
});

app.MapPut("api/task", async ([FromServices] ProjectTrackerContext db,
    [FromBody] Task task) =>
{
    var dbTask = await db.Tasks.FindAsync(task.TaskId);
    if (dbTask == null)
        return Results.NotFound("Feature Request #" + task.TaskId + " Not Found");

    dbTask.ProjectId = task.ProjectId;
    dbTask.TaskName = task.TaskName;
    dbTask.DateUpdated = System.DateTime.Now;
    dbTask.DateDue = task.DateDue;
    dbTask.AssignedToEmail = task.AssignedToEmail;
    dbTask.Priority = task.Priority;
    await db.SaveChangesAsync();
    return Results.Ok(dbTask);
});



app.MapPost("api/task_sp", async ([FromServices] ProjectTrackerContextProcedures db,
   Task task) =>
{
    var op = new OutputParameter<int>();
    List<sp_Insert_TaskResult> lst = new List<sp_Insert_TaskResult>();
    lst = await db.sp_Insert_TaskAsync(task.TaskName, DateTime.Now, task.DateDue,
          task.ProjectId, task.AssignedToEmail, task.Priority, op);
    Console.WriteLine(lst[0]);
    return lst[0];
});

app.MapPut("api/task_sp", async ([FromServices] ProjectTrackerContextProcedures db, Task task) =>
{
    var op = new OutputParameter<int>();
    var err = new OutputParameter<int?>();
    object updatedTask = null;

    try
    {
        updatedTask = await db.sp_Update_TaskAsync(task.TaskId, task.TaskName, System.DateTime.Now,
                task.DateDue, task.ProjectId, task.AssignedToEmail, task.Priority, err, op);
    }
    catch
    {
        return Results.BadRequest();
    }
    return updatedTask;
});

app.MapDelete("api/task/{id}", async (ProjectTrackerContext db, int id) =>
{
    var dbRequest = await db.Tasks.FindAsync(id);
    if (dbRequest == null)
        return Results.NotFound("Feature #" + id + " Not Found");

    db.Tasks.Remove(dbRequest);
    await db.SaveChangesAsync();
    return Results.Ok(dbRequest);
});

// Use Stored Procedure
app.MapDelete("api/task_sp/{id}", async (ProjectTrackerContextProcedures db, int id) =>
{
    var op = new OutputParameter<int>();
    await db.sp_Delete_TaskAsync(id, op);
    return Results.Ok();
});


app.MapGet("api/projects_sp", async ([FromServices] ProjectTrackerContextProcedures db) =>
{
    var op = new OutputParameter<int>();
    return await db.sp_Select_ProjectsAsync(op);
});

app.MapGet("api/project_sp/{id}", async ([FromServices] ProjectTrackerContextProcedures db, int id) =>
{
    var op = new OutputParameter<int>();
    return await db.sp_Select_ProjectAsync(id, op);
});

app.MapPost("api/project_sp", async ([FromServices] ProjectTrackerContextProcedures db,
   Project project) =>
{
    var op = new OutputParameter<int>();
    return await db.sp_Insert_ProjectAsync(project.ProjectName, op);
});

app.MapPut("api/project_sp", async ([FromServices] ProjectTrackerContextProcedures db, Project project) =>
{
    var op = new OutputParameter<int>();
    var err = new OutputParameter<int?>();
    object updatedProject = null;

    try
    {
        if (project.ProjectId != 0 && project.ProjectName != "")
            updatedProject = await db.sp_Update_ProjectAsync(project.ProjectName,
                project.ProjectId, err, op);
        else
            return Results.BadRequest();
    }
    catch
    {
        return Results.BadRequest();
    }
    return updatedProject;
});

app.UseHttpsRedirection();
app.Run();
