﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagerWebApi.Data
{
    public partial class ProjectTrackerContext
    {
        private IProjectTrackerContextProcedures _procedures;

        public virtual IProjectTrackerContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new ProjectTrackerContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IProjectTrackerContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sp_Insert_ProjectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_Insert_TaskResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_Select_ProjectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_Select_ProjectsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_Select_TaskResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_SelectAll_ProjectsTasksResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_SelectAll_TasksResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_Update_ProjectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<sp_Update_TaskResult>().HasNoKey().ToView(null);
        }
    }

    public partial class ProjectTrackerContextProcedures : IProjectTrackerContextProcedures
    {
        private readonly ProjectTrackerContext _context;

        public ProjectTrackerContextProcedures(ProjectTrackerContext context)
        {
            _context = context;
        }

        public virtual async Task<int> sp_Delete_ProjectAsync(int? ProjectId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ProjectId",
                    Value = ProjectId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_Delete_Project] @ProjectId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }


       // public virtual async Task<List<sp_Insert_ProjectResult>>
//        public virtual async Task<int> sp_Delete_TaskAsync(int? TaskId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        public virtual async Task<int> sp_Delete_TaskAsync(int? TaskId, 
                OutputParameter<int> returnValue = null, 
                CancellationToken cancellationToken = default)         
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "TaskId",
                    Value = TaskId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_Delete_Task] @TaskId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Insert_ProjectResult>> 
            sp_Insert_ProjectAsync(string ProjectName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ProjectName",
                    Size = 100,
                    Value = ProjectName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Insert_ProjectResult>("EXEC @returnValue = [dbo].[sp_Insert_Project] @ProjectName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Insert_TaskResult>> sp_Insert_TaskAsync(string TaskName, DateTime? DateUpdated, DateTime? DateDue, int? ProjectId, string AssignedToEmail, int? Priority, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "TaskName",
                    Size = 100,
                    Value = TaskName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DateUpdated",
                    Value = DateUpdated ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "DateDue",
                    Value = DateDue ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "ProjectId",
                    Value = ProjectId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "AssignedToEmail",
                    Size = 100,
                    Value = AssignedToEmail ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Priority",
                    Value = Priority ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Insert_TaskResult>("EXEC @returnValue = [dbo].[sp_Insert_Task] @TaskName, @DateUpdated, @DateDue, @ProjectId, @AssignedToEmail, @Priority", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Select_ProjectResult>> sp_Select_ProjectAsync(int? ProjectId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ProjectId",
                    Value = ProjectId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Select_ProjectResult>("EXEC @returnValue = [dbo].[sp_Select_Project] @ProjectId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Select_ProjectsResult>> sp_Select_ProjectsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Select_ProjectsResult>("EXEC @returnValue = [dbo].[sp_Select_Projects]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Select_TaskResult>> sp_Select_TaskAsync(int? TaskId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "TaskId",
                    Value = TaskId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Select_TaskResult>("EXEC @returnValue = [dbo].[sp_Select_Task] @TaskId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_SelectAll_ProjectsTasksResult>> sp_SelectAll_ProjectsTasksAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_SelectAll_ProjectsTasksResult>("EXEC @returnValue = [dbo].[sp_SelectAll_ProjectsTasks]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_SelectAll_TasksResult>> sp_SelectAll_TasksAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_SelectAll_TasksResult>("EXEC @returnValue = [dbo].[sp_SelectAll_Tasks]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Update_ProjectResult>> sp_Update_ProjectAsync(string ProjectName, int? ProjectId, OutputParameter<int?> out_error_number, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterout_error_number = new SqlParameter
            {
                ParameterName = "out_error_number",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = out_error_number?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterout_error_number,
                new SqlParameter
                {
                    ParameterName = "ProjectName",
                    Size = 100,
                    Value = ProjectName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "ProjectId",
                    Value = ProjectId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Update_ProjectResult>("EXEC @returnValue = [dbo].[sp_Update_Project] @out_error_number OUTPUT, @ProjectName, @ProjectId", sqlParameters, cancellationToken);

            out_error_number.SetValue(parameterout_error_number.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_Update_TaskResult>> 
            sp_Update_TaskAsync(int? TaskId, string TaskName, DateTime? DateUpdated, DateTime? DateDue, int? ProjectId, string AssignedToEmail, int? Priority, OutputParameter<int?> out_error_number, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterout_error_number = new SqlParameter
            {
                ParameterName = "out_error_number",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = out_error_number?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterout_error_number,
                new SqlParameter
                {
                    ParameterName = "TaskId",
                    Value = TaskId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "TaskName",
                    Size = 100,
                    Value = TaskName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DateUpdated",
                    Value = DateUpdated ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "DateDue",
                    Value = DateDue ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "ProjectId",
                    Value = ProjectId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "AssignedToEmail",
                    Size = 100,
                    Value = AssignedToEmail ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Priority",
                    Value = Priority ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_Update_TaskResult>("EXEC @returnValue = [dbo].[sp_Update_Task] @out_error_number OUTPUT, @TaskId, @TaskName, @DateUpdated, @DateDue, @ProjectId, @AssignedToEmail, @Priority", sqlParameters, cancellationToken);

            out_error_number.SetValue(parameterout_error_number.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
