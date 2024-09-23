using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BaiTapVN03.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string ImageUrl { get; set; }
    }
}
