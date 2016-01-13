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
using System.Data.Entity;
using OdrorirBoard.Areas.BackEnd.Models;


namespace OdrorirBoard.Models
{
    public class OBUser : IdentityUser
    {
        public string Town { get; set; }
        public string Country { get; set; }
        // FirstName & LastName will be stored in a different table called MyUserInfo
        public virtual OdrorirUserInfo OBUserInfo { get; set; }
    }

    public class OdrorirUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool isActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime CreatedOn = DateTime.Today;

        public ICollection<TeamViewModel.Team> inTeam { get; set; }

    }

    public static class TaskStyle
    {
        public const string Success = "success";
        public const string Error = "error";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
        public const string Default = "default";
    }

    public enum taskstate
    {
        Done,
        OnIT,
        Debugging,
        Assigned
    }

    public class ProjectTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string AssignedBy { get; set; }
        public taskstate taskState { get; set; }

    }
}