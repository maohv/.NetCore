using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{
    [DisplayName("Tên khách")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} phải có độ dài từ {2} đến {1} kí tự")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string CustomerName { get; set; }

    [DisplayName("Địa chỉ Email")]
    [EmailAddress(ErrorMessage = "Địa chỉ Email không phù hợp")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string Email { get; set; }

    [DisplayName("Năm sinh")]
    [Range(1970, 2005, ErrorMessage = "{0} sai, phải nhập trong khoảng {1} đến {2}")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    // [Sochan]
    public int? YearOfBirth { get; set; }
}