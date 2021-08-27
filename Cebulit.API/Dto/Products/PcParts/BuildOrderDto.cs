namespace Cebulit.API.Dto.Products.PcParts
{
    public class BuildOrderDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public BuildDto Build { get; set; }
    }
}