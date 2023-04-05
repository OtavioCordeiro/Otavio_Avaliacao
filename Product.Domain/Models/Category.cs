namespace MyProduct.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Situation { get; set; }
        public List<Product> Products { get; set; }
    }
}
