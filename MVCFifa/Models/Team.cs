﻿using System.ComponentModel.DataAnnotations;

namespace MVCFifa.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public ICollection<TeamPlayer>? TeamPlayers { get; set; }
    }
}
