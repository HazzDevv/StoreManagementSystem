namespace StoreManagementSystem.Interfaces //كل ملفات الواجهات ستكون ضمن هذا ال namespace
{
    public interface IProductActions // تعريف عام ليستطيع أي كلاس تطبيقه
    {
        void DisplayInfo(); // دالة لعرض معلومات المنتج
        decimal CalculateFinalPrice(); // دالة لحساب السعر النهائي
    }
}