using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BaiTap06.Models
{
    public class TaiKhoanViewModel 
    {
        public int Id { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
    }
}
