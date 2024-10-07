using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public string Nationality { get; set; }

        public int BirthYear { get; set; } // Sử dụng int cho năm sinh

        public virtual ICollection<Book> Books { get; set; }
    }
}
