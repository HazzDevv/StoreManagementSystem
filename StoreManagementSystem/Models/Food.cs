using StoreManagementSystem.Abstracts;
using System;

namespace StoreManagementSystem.Models
{
    public class Food : Product // الوراثة
    {
        private DateTime expiryDate; // التغليف

        public DateTime ExpiryDate // خاصية اضافية
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public Food( // معلومات المنتج
            int id,
            string name,
            decimal price,
            int quantity,
            DateTime expiryDate
        ) : base(id, name, price, quantity)
        {
            this.expiryDate = expiryDate;
        }

        public override decimal CalculateFinalPrice() // override لتابع حساب السعر النهائي
        {
            return Price - (Price * 0.05m); // تاريخ انتهاء الصلاحية
        }
    }
}