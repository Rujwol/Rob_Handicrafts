namespace Handicraft_proj.Models.Products
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public byte[] ImageData { get; set; } // Byte array to store image data
        public string ImageMimeType { get; set; } // MIME type of the image (e.g., "image/jpeg", "image/png")

    }

    public enum Category
    {
        Pottery,
        Textiles,
        Woodcraft,
        MetalCraft,
    }
}
