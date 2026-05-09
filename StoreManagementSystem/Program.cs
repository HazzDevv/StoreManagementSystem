using StoreManagementSystem.Abstracts; // استخدام الملفات التي قمنا بانشائها
using StoreManagementSystem.Management;
using StoreManagementSystem.Models;
using StoreManagementSystem.Utilities;

namespace StoreManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            store.ProductAdded += ShowNotification; // اطلاق اشعار عند اضافة منتج
            store.OutOfStock += ShowNotification; // اطلاق اشعار عند نفاذ كمية منتج

            if ( // التحقق اذا كانت معلومات المنتج صالحة للادخال
                Validator.IsValidName("Laptop") &&
                Validator.IsValidPrice(1500) &&
                Validator.IsValidQuantity(5)
            )
            {
                Electronics laptop = new Electronics( // انشاء منتج جديد من نوع Electronics
                    1, // المعرف
                    "Laptop", // الاسم
                    1500, // السعر
                    5, // الكمية
                    24 // أشهر الكفالة
                );

                store.AddProduct(laptop); // اضافة المنتج الى المتجر
            }

            Clothing shirt = new Clothing(
                2,
                "Shirt",
                50,
                10,
                "Large", // مواصفات اضافية للمنتج معرفة مسبقا
                "Cotton"
            );

            Food burger = new Food(
                3,
                "Burger",
                20,
                2,
                DateTime.Now.AddDays(7) // تاريخ انتهاء الصلاحية
            );
            if (
                Validator.IsValidName("Phone") &&
                Validator.IsValidPrice(67) &&
                Validator.IsValidQuantity(21)
            )
            {
                Electronics phone = new Electronics(
                    4,
                    "Phone",
                    67,
                    21,
                    24
                );

                store.AddProduct(phone);
            }
            store.AddProduct(shirt);
            store.AddProduct(burger);

            Console.WriteLine("\nAll Products:");
            store.DisplayProducts(); // استدعاء تابع عرض المنتجات

            Console.WriteLine("\nSelling Products:\n");

            store.SellProduct(3, 1); // بيع المنتج رقم 3 مرة واحدة

            store.SellProduct(3, 1); // بيع المنتج رقم 3 مرة واحدة

            Console.WriteLine(
                $"\nTotal Products Created: {Product.TotalProducts}" // عرض كمية المنتجات المنشئة في المتجر
            );
        }

        static void ShowNotification(string message) // تابع اظهار الاشعار
        {
            Console.WriteLine($"[Notification]: {message}");
        }
    }
}