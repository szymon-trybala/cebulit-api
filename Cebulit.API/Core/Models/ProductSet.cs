namespace Cebulit.API.Core.Models
{
    public abstract class ProductSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}