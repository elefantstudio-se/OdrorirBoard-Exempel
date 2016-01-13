using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OdrorirBoard.Helpers;
using OdrorirBoard.Areas.BackEnd.Models;

namespace OdrorirBoard.Models
{
    public class SiteDataContext : DbContext
    {
        public SiteDataContext() : base("DefaultConnection") { }

        public DbSet<NotificationAlert.Notification> Notifications { get; set; }

        public DbSet<TeamViewModel.Team> Teams { get; set; }
        
        public DbSet<ProjectsViewModel.Project.Tasks> ProjectsTasks { get; set; }

        //Tillhör User.
        public DbSet<ProjectsViewModel.Project> Projects { get; set; }
        public DbSet<OdrorirUserInfo> User { get; set; }


    }
}