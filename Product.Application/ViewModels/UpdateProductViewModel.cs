namespace MyProduct.Application.ViewModels
{
    public class UpdateProductViewModel
    {        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Situation { get; set; }
        public int? CategoryId { get; set; }
    }
}
