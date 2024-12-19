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
        [StringLength(25,ErrorMessage = "Karakter sayısı en fazla 25 olabilir")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [ScaffoldColumn(true)]
        [StringLength(10, ErrorMessage = "Karakter sayısı en fazla 10 olabilir")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli mail adresi giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş geçilemez")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Lütfen geçerli telefon numarası giriniz")]
        public string Phone { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Lütfen geçerli telefon numarası giriniz")]
        public string? Phone2 { get; set; }
        public Guid? FK_SchoolDetail { get; set; }
        
    }
}
