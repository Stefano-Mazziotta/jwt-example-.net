using jwt_example.Models;

namespace jwt_example.Constants
{
    public class ProductConstants
    {
        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() { name = "Pepsi", description = "Bebida con gas"},
            new ProductModel() { name = "Coca Cola", description = "Bebida con gas"}
        };
    }
}
