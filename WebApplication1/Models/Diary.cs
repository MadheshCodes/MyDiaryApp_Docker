using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Diary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;

        public string? Mood { get; set; }         // e.g., Happy, Sad
        public string? Gratitude { get; set; }    // optional short text
        public string? Affirmation { get; set; }  // optional
    }
}
