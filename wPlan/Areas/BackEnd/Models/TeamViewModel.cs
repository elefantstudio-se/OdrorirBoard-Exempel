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
using System.Security.Cryptography;
using System.Text;

namespace OdrorirBoard.Areas.BackEnd.Models
{
    public class TeamViewModel
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

        public enum LabelState
        {
            Active,
            Private,
            NotActive,
        }


        public class Team
        {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
            public DateTime CreatedOn = DateTime.Today;

            public string Name { get; set; }
            public int Count { get; set; }
            public int TotalProjects { get; set; }

            public int TeamCount { get; set; }
            public LabelState TeamState { get; set; }
            public virtual ICollection<ProjectsViewModel.Project> Projects { get; set; }
            public virtual ICollection<OdrorirUserInfo> Members { get; set; }

        }
    }
}
