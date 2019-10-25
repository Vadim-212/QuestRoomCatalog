using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRoomCatalog.Models
{
    public class RolesModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "Поле \"Имя роли\" должно быть больше 3 и меньше 20 символов.")]
        public string RoleName { get; set; }
    }
}