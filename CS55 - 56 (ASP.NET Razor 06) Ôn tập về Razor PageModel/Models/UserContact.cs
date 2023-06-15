using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserContact
{
    [BindProperty]
    [DisplayName("Id của bạn")]
    [Range(1, 100, ErrorMessage = "Nhap qua gioi han so")] //Cho số từ 1 khoảng nào đó
    public int UserId { get; set; }

    [BindProperty]
    [DisplayName("Email của bạn")]
    [EmailAddress(ErrorMessage = "Email sai định dạng")]
    public string Email { get; set; }

    [BindProperty]
    [DisplayName("Tên người dùng")]
    public string UserName { get; set; }


}