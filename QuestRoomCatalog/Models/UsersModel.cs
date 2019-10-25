using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRoomCatalog.Models
{
    public class UsersModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Поле \"Имя пользователя\" должно быть больше 5 и меньше 25 символов.")]
        public string UserName { get; set; }

        [Required]
        public int RoleId { get; set; }

        
        public string RoleName { get; set; }
    }
}