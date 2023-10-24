using Handicraft_proj.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace Handicraft_proj.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductsController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AllProducts()
        {
            // Retrieve products from your data source (e.g., database, service)
            List<Product> products = GetProductsFromDataSource();

            // Filter products based on Handicrafts category
            var handicraftProducts = products;
            //var handicraftProducts = products.Where(p => p.Category == Category.Handicrafts);

            // Pass the filtered products to the view
            return View(handicraftProducts);
        }
        private List<Product> GetProductsFromDataSource()
        {
            // Logic to fetch products from the database or any other data source
            // This method should return a List<Product>
            // Sample data:
            return new List<Product>
            {
                new Product
                {
                    Name = "Pottery Product 1",
                    Price = 350.00m,
                    Category = Category.Pottery,
                    Description = "Beautiful pottery item.",
                    ImageData = GetSampleImageData(Category.Pottery), // Method to retrieve image binary data
                    ImageMimeType = "image/jpeg" // MIME type of the image
                },
                new Product
                {
                    Name = "Textile Product 1",
                    Price = 450.00m,
                    Category = Category.Textiles,
                    Description = "Elegant textile item.",
                    ImageData = GetSampleImageData(Category.Textiles), // Method to retrieve image binary data
                    ImageMimeType = "image/png" // MIME type of the image
                },
                // Add more products as needed
            };
        }
        private byte[] GetSampleImageData(Category category)
        {
            string imageName = string.Empty;

            // Determine the image path based on the category
            switch (category)
            {
                case Category.Pottery:
                    imageName = "pottery_1.jpg";
                    break;
                case Category.Textiles:
                    imageName = "textile_1.jpg";
                    break;
                // Add more cases for other categories as needed
                default:
                    // Default image path or handle unknown category
                    imageName = "textile_1.jpg";
                    break;
            }
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Products", imageName);
            byte[] imageData;

            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, (int)fs.Length);
            }

            return imageData;
        }
    }
}
