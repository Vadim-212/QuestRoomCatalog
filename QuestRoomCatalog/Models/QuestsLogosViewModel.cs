namespace QuestRoomCatalog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;

    public class QuestsLogosViewModel
    {
        public int Id { get; set; }

        public int QuestRoomId { get; set; }

        //[Required]
        public byte[] Image { get; set; }

        public bool IsLogo { get; set; }


        public Image Img { get; set; }
        public string QuestRoomName { get; set; }

        //public QuestsRoomsViewModel QuestsRooms { get; set; }
    }
}
