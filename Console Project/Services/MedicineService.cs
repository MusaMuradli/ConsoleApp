using Console_Project.Exceptions;
using Console_Project.Models;

namespace Console_Project.Services;

public class MedicineService
{
    public void CreateMedicine(Medicine medicine)
    {
        bool existCategory = false;
        foreach (var category in DB.Categories)
        {
            if (category.Id == medicine.CategoryId)
            {
                existCategory = true;
                break;
            }
        }
        if (!existCategory)
        {
            throw new NotFoundException("Qeyd olunmuş category tapılmamışdır");
        }
        Array.Resize(ref DB.Medicines, DB.Medicines.Length + 1);
        DB.Medicines[DB.Medicines.Length - 1] = medicine;
    }

    public Medicine[] GetAllMedicines()
    {
        return DB.Medicines;
    }

    public Medicine GetMedicineById(int id)
    {
        foreach (var medicine in DB.Medicines)
        {
            if (medicine.Id == id)
            {
                return medicine;
            }

        }
        throw new NotFoundException("Bu Id-li medicine tapilmadi");

    }
    public Medicine GetMedicineByName(string name)
    {
        foreach (var medicine in DB.Medicines)
        {
            if (medicine.Name == name)
            {
                return medicine;
            }

        }
        throw new NotFoundException("Bu Adlı medicine tapilmadi");

    }

    public Medicine[] GetMedicineByCategory(int categoryId)
    {
        int count = 0;
        foreach (var medicine in DB.Medicines)
        {
            if (medicine.CategoryId == categoryId)
            {
                count++;
            }
        }

        Medicine[] newMedicine = new Medicine[count];
        int index = 0;
        foreach (var item in DB.Medicines)
        {
            if (item.CategoryId == categoryId)
            {
                newMedicine[index++] = item;
            }
        }
        return newMedicine;
    }

    public void RemoveMedicine(int id)
    {
        for (int i = 0; i < DB.Medicines.Length; i++)
        {
            if (DB.Medicines[i].Id == id)
            {
                for (int j = i; j < DB.Medicines.Length - 1; j++)
                {
                    DB.Medicines[j] = DB.Medicines[j + 1];
                }
                Array.Resize(ref DB.Medicines, DB.Medicines.Length - 1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Removdan sonra medicinler>>>>");
                Console.ResetColor();
                foreach (var item in DB.Medicines)
                {
                    Console.WriteLine($"Id:{item.Id} = Name:{item.Name}");
                }
                return;
            }

        }
        throw new NotFoundException("Verilmiş id-li medicine tapılmadı");
    }
    public void UpdateMedicine(int id, Medicine newMedicine)
    {
        for (int i = 0; i < DB.Medicines.Length; i++)
        {
            if (DB.Medicines[i].Id == id)
            {
                DB.Medicines[i].Name = newMedicine.Name;
                DB.Medicines[i].Price = newMedicine.Price;
                DB.Medicines[i].CategoryId = newMedicine.CategoryId;

                return;
            }
        }
        throw new NotFoundException("Tapilmadi");
    }

}
