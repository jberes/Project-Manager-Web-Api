﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerWebApi.Models
{
    public partial class sp_Insert_TaskResult
    {
        public string ProjectName { get; set; }
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime DateAdded { get; set; }
        public string AssignedToEmail { get; set; }
        public int Priority { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateDue { get; set; }
        public int ProjectID { get; set; }
    }
}
