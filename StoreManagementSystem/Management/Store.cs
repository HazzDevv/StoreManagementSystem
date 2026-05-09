using StoreManagementSystem.Abstracts;
using System;

namespace StoreManagementSystem.Management
{
    public delegate void NotificationHandler(string message); // استخدامdelegate لاطلاق اشعار

    public class Store
    {
        private List<Product> products; // عرض قائمة من المنتجات

        public event NotificationHandler ProductAdded; // اشعار يطلق عند اضافة منتج

        public event NotificationHandler OutOfStock; // اشعار يطلق عند انتهاء كمية منتج

        public Store()
        {
            products = new List<Product>(); // تهيئة القائمة
        }

        public void AddProduct(Product product) // تابع اضافة منتج
        {
            products.Add(product);

            ProductAdded?.Invoke(
                $"Product added: {product.Name}" // اطلاق الحدث
            );
        }

        public void DisplayProducts() // تابع اظهار المنتجات مع السعر النهائي الخاص بكل منتج
        {
            foreach (Product product in products)
            {
                product.DisplayInfo();

                Console.WriteLine(
                    $"Final Price: {product.CalculateFinalPrice()}"
                );

                Console.WriteLine("-------------------");
            }
        }

        public void SellProduct(int productId, int quantity) // تابع بيع المنتج
        {
            foreach (Product product in products)
            {
                if (product.Id == productId) // التحقق من وجود المنتج بالفعل
                {
                    if (product.Quantity >= quantity) // التحقق اذا كان موجود في الكمية
                    {
                        product.Quantity -= quantity; // اذا تحقق الشرط السابق تنقص الكمية

                        Console.WriteLine(
                            $"{quantity} item(s) sold from {product.Name}" // رسالة بعد بيع المنتج
                        );

                        if (product.Quantity == 0) // في حال انتهت الكمية
                        {
                            OutOfStock?.Invoke(
                                $"{product.Name} is out of stock!" // اطلاق اشعار انتهاء الكمية
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "Not enough quantity available." // عدم وجود كمية كافية
                        );
                    }

                    return;
                }
            }

            Console.WriteLine("Product not found."); // المنتج غير موجود
        }
    }
}