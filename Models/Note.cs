using System.ComponentModel.DataAnnotations;

namespace AttemptOne.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}