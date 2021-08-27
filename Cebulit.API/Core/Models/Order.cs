namespace Cebulit.API.Core.Models
{
    public abstract class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
    }
}