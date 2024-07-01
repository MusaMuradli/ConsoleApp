
using Console_Project.Models;

namespace Console_Project.Services;

public class MedicineService
{
    public void CreateMedicine(Medicine medicine)
    {
        Array.Resize(ref DB.Medicines, DB.Medicines.Length + 1);
        DB.Medicines[DB.Medicines.Length - 1]= medicine;
        
    }
    public Medicine[] GetAllMedicines()
    {
        return DB.Medicines;
    }
}
