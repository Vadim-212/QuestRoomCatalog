using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRoomCatalog.Models
{
    public class QuestsRoomsModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 2, ErrorMessage = "Поле \"Название\" должно быть больше 2 и меньше 75 символов.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TimeForQuest { get; set; }

        public int MaxGamer { get; set; }

        public int MinGamer { get; set; }

        [Required]
        [Range(12,55)]
        public int MinAgeGamer { get; set; }

        [Required]
        [Range(1,5,ErrorMessage = "Поле \"Уровень страха\" должно иметь значение от 1 до 5")]
        public int FearLevel { get; set; }

        [Range(1,5)]
        public int ComplexityLevel { get; set; }
    }
}