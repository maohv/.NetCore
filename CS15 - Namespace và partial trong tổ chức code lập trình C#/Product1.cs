namespace Sanpham
{
    //thêm partial có thể chia nhỏ ra nhiều file code
    public partial class Product
    {
        public string name { get; set; }

        public decimal price { get; set; }

        public string GetInfo()
        {
            return $"{name} / {price} : {description}";
        }
    }
}