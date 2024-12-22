using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Business.User.Model.Request
{
    public class RequestCreateUser
    {
        [Required(ErrorMessage = "Kullanıcı alanı boş geçilemez")]
        [ScaffoldColumn(true)]
        [StringLength(25,MinimumLength = 3,ErrorMessage = "Karakter sayısı en fazla 25 olabilir")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Karakter sayısı en fazla 10 olabilir")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Lütfen geçerli mail adresi giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş geçilemez")]
        [Phone(ErrorMessage = "Lütfen geçerli telefon numarası giriniz")]
        public string Phone { get; set; }
        [Phone(ErrorMessage = "Lütfen geçerli telefon numarası giriniz")]
        public string? Phone2 { get; set; }
        public Guid? FK_SchoolDetail { get; set; }
        
    }
}
