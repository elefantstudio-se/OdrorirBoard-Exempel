using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OdrorirBoard.Models.Modals;
using OdrorirBoard.Models;
using OdrorirBoard.Helpers;

namespace OdrorirBoard.Areas.BackEnd.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }

    }

    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}
