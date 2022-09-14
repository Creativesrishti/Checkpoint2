List<Products> products = new List<Products>();

Console.WriteLine("Add a Product and close with q");
Products.inputProducts(products);

Console.WriteLine("My List");
//foreach loop to print all the entered products
foreach (Products prod in products)
{
    Console.WriteLine(prod.Category.PadRight(10) + prod.ProductName.PadRight(10)
        + prod.Price.ToString().PadRight(10));
}
//To add more products after the list is displayed
Console.WriteLine("Do you want to add more products(y/n)?");
string input = Console.ReadLine();
if (input.ToLower().Trim() == "y")
{
    Products.inputProducts(products);
}
//Sorting list by price for Level 2 in checkpoint
Console.WriteLine("My Products - Sorted by Low price to high");
List<Products> sortedPrice =products.OrderBy( products=> products.Price).ToList();
foreach (Products prod in sortedPrice)
{
    Console.WriteLine(prod.Category.PadRight(10) + prod.ProductName.PadRight(10)
        + prod.Price.ToString().PadRight(10));
}
//Sum of all the prices
double sumPrice = sortedPrice.Sum(sortedPrice =>sortedPrice.Price);
Console.WriteLine("Sum of all the prices is:" + sumPrice);
Console.ReadLine();

Console.WriteLine("Do you want to search any product(y/n)?");
string searchProduct = Console.ReadLine();
if (searchProduct.ToLower().Trim() == "y")
{

    //Level 4- search product
    Console.WriteLine ("Enter the Product name to search");
    string productname = Console.ReadLine();

    var queryfindproductname = from result in products
                               where result.ProductName == productname 
                               select result;

    
    foreach (var productGroup in queryfindproductname)
    {
        Console.WriteLine(productGroup.Category.PadRight(10) + productGroup.ProductName.PadRight(10)
        + productGroup.Price.ToString().PadRight(10));
    }
}
class Products
{
    public Products(string category, string productname, double price)
    {
        Category = category;
        ProductName = productname;
        Price = price;
    }
    public string Category { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    //function to input products from the user and add it to the list
    public static void inputProducts(List<Products> products)
    {
        while (true)
        {
            Console.WriteLine("Enter Category");
            string cat = Console.ReadLine();
            if (cat.ToLower().Trim() == "q")
            {
                break;
            }
            Console.WriteLine("Enter Product Name");
            string prodname = Console.ReadLine();
            if (prodname.ToLower().Trim() == "q")
            {
                break;
            }
            Console.WriteLine("Enter Price");
            string price = Console.ReadLine();
            if (price.ToLower().Trim() == "q")
            {
                break;
            }
            Products prod = new Products(cat, prodname, Convert.ToDouble(price));
            products.Add(prod);
        }
    }
}

