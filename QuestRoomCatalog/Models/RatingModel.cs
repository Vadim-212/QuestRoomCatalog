using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRoomCatalog.Models
{
    public class RatingModel
    {
        public int Id { get; set; }

        public int QuestRoomId { get; set; }

        [Range(1,10)]
        public int RatingLevel { get; set; }

        public string QuestRoomName { get; set; }
    }
}