using System;
using System.Collections.Generic;
using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("Ad")]
    public class Ad
    {
        [Column("AdId")]
        public int Id { get; set; }

        //public int UserId { get; set; }

        [ForeignKey("UserId", tableName: "User")]
        public User User { get; set; }

        //public int LocationId { get; set; }
        [ForeignKey("LocationId", tableName: "Location")]
        public Location Location { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        // get from db
        [Column("Kind")]
        public string Type { get; set; }

        // get from db
        [Column("State")]
        public string State { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
