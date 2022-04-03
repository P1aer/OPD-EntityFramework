using System.ComponentModel.DataAnnotations;


namespace OPD_EF
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

       [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
