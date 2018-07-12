namespace Football.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Player
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}