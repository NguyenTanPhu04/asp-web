using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public int PublicationYear { get; set; }

        public string Genre { get; set; }

        // Foreign key cho Author
        public int AuthorId { get; set; }

        // Navigation property
        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }
    }
}
