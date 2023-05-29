using System;
using System.Collections.Generic;

namespace TestScaffold.Models;

public partial class Donhang
{
    public int DonhangId { get; set; }

    public int? KhachhangId { get; set; }

    public int? NhanvienId { get; set; }

    public DateTime? Ngaydathang { get; set; }

    public int? ShipperId { get; set; }
}
