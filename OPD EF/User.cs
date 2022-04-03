﻿using System.ComponentModel.DataAnnotations;


namespace OPD_EF
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(9)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
