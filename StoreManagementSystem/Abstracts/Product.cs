using StoreManagementSystem.Interfaces;

namespace StoreManagementSystem.Abstracts
{
    public abstract class Product : IProductActions // انشاء الكلاس المجرد للمنتجات
    { // تعريف الحقول الخاصة
        private int id; // معرف المنتج
        private string name; // الاسم
        private decimal price; // السعر
        private int quantity; // الكمية

        public static int TotalProducts { get; private set; } // تعريف القيم المشتركة بين جميع المنتجات
        
        // الخصائص
        public int Id
        {
            get { return id; } // لايوجد set لأن المعرف لا يمكن ان يغير بعد الانشاء
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Product(int id, string name, decimal price, int quantity) // استقبال البيانات وتعبئة الحقول المناسبة
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;

            TotalProducts++; // اضافة منتج لعدد المنتجات
        }

        public void DisplayInfo() // تنفيذ للتابع الموجود في Interface لعرض معلومات المنتج
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Quantity: {Quantity}");
        }

        public abstract decimal CalculateFinalPrice(); // دالة مجردة لحساب السعر النهائي
    }
}