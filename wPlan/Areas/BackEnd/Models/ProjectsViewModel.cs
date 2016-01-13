using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdrorirBoard.Controllers;
using OdrorirBoard.Models;
using OdrorirBoard.Helpers;
using Microsoft.Owin.Security;

namespace OdrorirBoard.Areas.BackEnd.Models
{
    public class ProjectsViewModel
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public static class LabelStyles
        {
            public const string Success = "success";
            public const string Error = "error";
            public const string Information = "info";
            public const string Warning = "warning";
            public const string Danger = "danger";
            public const string Default = "default";
        }

        public enum ProjectLabelState
        {
            Active,
            NotActive,
            Complete,
            Alpha,
            Beta,
            Optimizing
        }

        public enum TaskState
        {
            Done,
            OnIT,
            Debugging,
            Assigned
        }

        public class Project
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
            public DateTime CreatedOn = DateTime.Today;

            [Required]
            public string Name { get; set; }

            [DataType(DataType.MultilineText)]
            public string Description { get; set; }

            public List<string> projectMembers { get; set; }
            //public List<string> ActiveProjects { get; set; }

            public int Count { get; set; }
            public List<int> ProjectsCount { get; set; }

            public string ProjectOwner { get; set; }

            public string AddedToProject { get; set; }

            [Required]
            public ProjectLabelState ProjectState { get; set; }

            public virtual ICollection<OdrorirUserInfo> Users { get; set; }
            public virtual TeamViewModel.Team Teams { get; set; }
            public virtual Tasks ProjectTasks { get; set; }

            //Lista att lagra project i .

            public class Tasks
            {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public Guid Id { get; set; }
                [Required]
                public string Name { get; set; }
                [DataType(DataType.MultilineText)]
                public string TaskDescription { get; set; }
                public bool TaskIsDone { get; set; }
                public string TaskAssignedBy { get; set; }

                public TaskState taskstate { get; set; }
                public ICollection<Project> Projects { get; set; }
                public ICollection<OdrorirUserInfo> User { get; set; }
            }
        }
    }
}