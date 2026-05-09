using StoreManagementSystem.Abstracts;

namespace StoreManagementSystem.Models
{
    public class Clothing : Product // الوراثة
    {
        private string size;
        private string material;

        public string Size // خاصية اضافية
        {
            get { return size; }
            set { size = value; }
        }

        public string Material // خاصية اضافية
        {
            get { return material; }
            set { material = value; }
        }

        public Clothing( // معلومات المنتج
            int id,
            string name,
            decimal price,
            int quantity,
            string size,
            string material
        ) : base(id, name, price, quantity)
        {
            this.size = size;
            this.material = material;
        }

        public override decimal CalculateFinalPrice() // override لتابع حساب السعر النهائي
        {
            return Price - (Price * 0.10m); // خصم 10 بالمية
        }
    }
}