using StoreManagementSystem.Abstracts;

namespace StoreManagementSystem.Models
{
    public class Electronics : Product // الوراثة
    {
        private int warrantyMonths; // التغليف

        public int WarrantyMonths // استخدام property لتعديل قيمة WarrantyMonths
        {
            get { return warrantyMonths; }
            set { warrantyMonths = value; }
        }

        public Electronics( // معلومات المنتج
            int id,
            string name,
            decimal price,
            int quantity,
            int warrantyMonths // خاصة اضافية لقسم الالكترونيات
        ) : base(id, name, price, quantity)
        {
            this.warrantyMonths = warrantyMonths;
        }

        public override decimal CalculateFinalPrice() // override لتابع حساب السعر النهائي
        {
            return Price + (Price * 0.15m); // السعر بعد حساب الكفالة
        }
    }
}