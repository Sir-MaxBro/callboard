﻿using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    public class Phone
    {
        public int Id { get; set; }

        //public int UserId { get; set; }

        [ForeignKey("UserId", tableName: "User")]
        public User User { get; set; }

        public string Number { get; set; }
    }
}
