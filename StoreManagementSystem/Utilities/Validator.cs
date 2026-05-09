namespace StoreManagementSystem.Utilities
{
    public static class Validator // كلاس من نوع static لا يمكن انشاء اغراض منه
    {
        public static bool IsValidName(string name) // تحقق من أن الاسم ليس فارغ وليس فقط مسافات
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public static bool IsValidPrice(decimal price) // تحقق من ان السعر أكبر تماما من الصفر
        {
            return price > 0;
        }

        public static bool IsValidQuantity(int quantity) // تحقق أن الكمية ليست سالبة
        {
            return quantity >= 0;
        }
    }
}