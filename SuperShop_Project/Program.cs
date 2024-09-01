using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Pattern;
using Repository_Domain;

namespace SuperShop_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();
                Console.WriteLine("================= Super Store =================");
                Console.WriteLine("Press 1: To View Products");
                Console.WriteLine("Press 2: To Add a New Product");
                Console.WriteLine("Press 3: To Update a Product");
                Console.WriteLine("Press 4: To Delete a Product");
                Console.WriteLine("Press 5: To Exit");
                string inputKey = Console.ReadLine();
                Console.Clear();

                IProductRepository productRepository = RepositoryFactory.Create<IProductRepository>(ContextTypes.XMLSource);

                switch (inputKey)
                {
                    case "1":
                        ViewProducts(productRepository);
                        break;
                    case "2":
                        AddProduct(productRepository);
                        break;
                    case "3":
                        UpdateProduct(productRepository);
                        break;
                    case "4":
                        DeleteProduct(productRepository);
                        break;
                    case "5":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        static void ViewProducts(IProductRepository productRepository)
        {
            var products = productRepository.GetAll();

            Console.WriteLine("================= Products =================");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId},Product Name: {product.ProductName},Category: {product.Category},Unit Price: {product.UnitPrice:C}");
            }

            Console.Write("Press any key to go back");
            Console.ReadKey();
        }

        static void AddProduct(IProductRepository productRepository)
        {
            Product newProduct = new Product();

            Console.Write("Enter Product Name: ");
            newProduct.ProductName = Console.ReadLine();

            Console.Write("Enter Product Category: ");
            newProduct.Category = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            decimal.TryParse(Console.ReadLine(), out decimal price);
            newProduct.UnitPrice = price;

            try
            {
                productRepository.Insert(newProduct);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.Write("Press any key to go back");
            Console.ReadKey();
        }

        static void UpdateProduct(IProductRepository productRepository)
        {
            Console.Write("Enter the ID of the product to update: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var existingProduct = productRepository.Get(productId);

                if (existingProduct != null)
                {
                    Console.Write("Enter new Product Name: ");
                    existingProduct.ProductName = Console.ReadLine();

                    Console.Write("Enter new Product Category: ");
                    existingProduct.Category = Console.ReadLine();

                    Console.Write("Enter new Product Price: ");
                    decimal.TryParse(Console.ReadLine(), out decimal newPrice);
                    existingProduct.UnitPrice = newPrice;

                    try
                    {
                        productRepository.Update(existingProduct);
                        Console.WriteLine("Product updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Product with ID {productId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for product ID.");
            }

            Console.Write("Press any key to go back");
            Console.ReadKey();
        }

        static void DeleteProduct(IProductRepository productRepository)
        {
            Console.Write("Enter the ID of the product to delete: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                try
                {
                    if (productRepository.Delete(productId))
                    {
                        Console.WriteLine("Product deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID {productId} not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for product ID.");
            }

            Console.Write("Press any key to go back");
            Console.ReadKey();
        }
    }
}
