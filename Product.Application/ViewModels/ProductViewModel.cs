namespace MyProduct.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Situation { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
