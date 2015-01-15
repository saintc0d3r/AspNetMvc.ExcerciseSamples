
namespace WorkingWithRazor.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { set; get; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}