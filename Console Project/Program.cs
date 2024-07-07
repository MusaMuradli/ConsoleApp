using Console_Project;
using Console_Project.Exceptions;
using Console_Project.Models;
using Console_Project.Services;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Channels;

UserService userService = new UserService();
MedicineService medicineService = new MedicineService();
CategoryService categoryService = new CategoryService();


//restart:
//Console.WriteLine("Menu 1: ");
//Console.WriteLine("1.User Registration");
//Console.WriteLine("2.User Login");
//Console.WriteLine("0.Exit");
//Console.WriteLine("Enter your choice: ");


//string menyuStart = Console.ReadLine();

//switch (menyuStart)
//{
//    case "1":
//    bash:
//        Console.WriteLine("Enter the fullname");
//        string fullname = Console.ReadLine();
//        try
//        {
//            if (fullname.Length < 4)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Ad minimum 4 herfden ibaret olmalıdır.");
//            }
//            if (fullname.Length > 10)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Ad maksimum 10 herfden ibaret olmalıdır.");
//            }
//            if (!fullname.Any(char.IsUpper))
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Adda en azı bir böyük herf olmalıdır.");
//            }
//            if (!fullname.Any(char.IsLower))
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Adda en azı bir kiçik herf olmalıdır.");
//            }

//            Console.WriteLine("Daxil edilen ad: " + fullname);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Xeta: " + ex.Message);
//            Console.ResetColor();
//            goto bash;
//        }
//    emailBash:
//        Console.WriteLine("Enter the email");
//        string email = Console.ReadLine();
//        string pattern = @"^[a-z0-9._%+-]+@gmail\.com$";

//        if (Regex.IsMatch(email, pattern))
//        {

//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Email yanlışdır. Email @gmail.com ile bitmeli ve böyük herf olmamalıdır.");
//            Console.ResetColor();
//            goto emailBash;
//        }
//    passwordBash:
//        Console.WriteLine("Enter the password");
//        string password = "";
//        ConsoleKeyInfo key;
//        do
//        {
//            key = Console.ReadKey(true);

//            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
//            {
//                password += key.KeyChar;
//                Console.Write("*");
//            }
//            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
//            {
//                password = password.Substring(0, (password.Length - 1));
//                Console.Write("\b \b");
//            }
//        }
//        while (key.Key != ConsoleKey.Enter);
//        Console.WriteLine();
//        try
//        {
//            if (password.Length < 5)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Parol minimum 5 simvoldan ibaret olmalıdır.");
//            }
//            if (password.Length > 10)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Parol maksimum 10 simvoldan ibaret olmalıdır.");
//            }
//            if (!password.Any(char.IsDigit))
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                throw new Exception("Parolda en azı bir reqem olmalıdır.");
//            }

//            User user = new(fullname, email, password);
//            userService.AddUser(user);
//            goto restart;

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Xeta: " + ex.Message);
//            Console.ResetColor();
//            goto passwordBash;
//        }
//    case "2":
//        User adminUser = null;
//        while (adminUser == null)
//        {
//            Console.WriteLine("ENTER EMAIL: ");
//            string confimEmail = Console.ReadLine();
//            Console.WriteLine("ENTER PASSWORD: ");
//            string confimPassword = Console.ReadLine();
//            try
//            {
//                adminUser = userService.Login(confimEmail, confimPassword);
//                Console.WriteLine("Girish olundu: \n");
//                break;
//            }
//            catch (NotFoundException q)
//            {
//                Console.WriteLine(q.Message);
//            }
//        }

//        break;
//    case "0":
//        return;
//    default:
//        goto restart;
//}

bool stop = false;
menyu1:
Console.WriteLine("Menu:");
Console.WriteLine("1. Create Category"); //+
Console.WriteLine("2. Gett all Categories");//+
Console.WriteLine("3. Create Medicine"); //+
Console.WriteLine("4. List All Medicines");//+
Console.WriteLine("5. Get Medicine By Id");//+
Console.WriteLine("6. Get Medicine By Name");//+
Console.WriteLine("7. Get Medicine By Category");
Console.WriteLine("8. Remove Medicine");
Console.WriteLine("9. Update Medicine");
Console.WriteLine("10. Exit");
Console.WriteLine("11. Menyu goster:");
menyu2:
while (!stop)
{
    string getStart = Console.ReadLine();
    switch (getStart)
    {
        case "1":
            Category category = new Category();
            Console.WriteLine("Kateqoriya adi daxil edin");
            category.Name = Console.ReadLine();
            categoryService.CreateCategory(category);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{category.Name} adli category elave olundu");
            Console.ResetColor();
            Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
            break;
        case "2":
            categoryService.GetAllCategories();
            goto menyu1;
            break;
        case "3":
            if (DB.Categories.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Hec bir kategoriya movcud deil");
                Console.ResetColor();
                Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
                break;

            }
            Console.WriteLine("Medicine adi daxil edin");
            string name = Console.ReadLine();
            Console.WriteLine("Qiymet daxil edin");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Kateqoruya id daxil edin");
            foreach (var item in DB.Categories)
            {
                Console.WriteLine(item);
            }
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("User id daxil edin");
            int userId = int.Parse(Console.ReadLine());
            Medicine medicine = new Medicine(name, price, categoryId, userId);
            medicineService.CreateMedicine(medicine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{medicine.Name} adli medicine elave olundu");
            Console.ResetColor();
            Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
            break;
        case "4":
            Medicine[] med = medicineService.GetAllMedicines();
            foreach (var item in med)
            {
                Category category1 = new();

                foreach (var c in DB.Categories)
                {
                    if (c.Id == item.CategoryId)
                    {
                        category1 = c;
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Medicine Id = {item.Id}, Medicine Name - {item.Name}, Medicine Price - {item.Price}, Medicine Category - {category1.Name}");
                Console.ResetColor();

            }
            Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
            break;
        case "5":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medicine Id daxil edin.....");
            Console.ResetColor();
            try
            {
                int id = int.Parse(Console.ReadLine());
                medicineService.GetMedicineById(id);
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in DB.Medicines)
                {
                    Category category1 = new();

                    foreach (var c in DB.Categories)
                    {
                        if (c.Id == item.CategoryId)
                        {
                            category1 = c;
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Medicine name: {item.Name}, Price: {item.Price}, Category Name:{category1.Name}");
                    Console.ResetColor();
                    Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
                    break;
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Xeta baş verdi: {ex.Message}");
                Console.ResetColor();
                goto menyu1;
            }
            break;
        case "6":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medicine Name daxil edin.....");
            Console.ResetColor();
            foreach (var item in DB.Medicines)
            {
                Console.WriteLine(item.Name);
            }
            try
            {
                string medicineName = Console.ReadLine();
                medicineService.GetMedicineByName(medicineName);
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in DB.Medicines)
                {
                    Category category1 = new();

                    foreach (var c in DB.Categories)
                    {
                        if (c.Id == item.CategoryId)
                        {
                            category1 = c;
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Medicine name: {item.Name}, Price: {item.Price}, Category Name:{category1.Name}");
                    Console.ResetColor();
                    Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
                    break;
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Xeta baş verdi: {ex.Message}");
                Console.ResetColor();
                goto menyu1;
            }
            break;
        case "7":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medicine kateqoriyasi daxil edin.....");
            Console.ResetColor();
            foreach (var item in DB.Categories)
            {
                Console.WriteLine($"Category ID:{item.Id}, name:{item.Name}");
            }
            try
            {
                Console.WriteLine("Kateqoriya ID-ni daxil edin:");
                int medicineCategoryId = int.Parse(Console.ReadLine());
                Medicine[] medicines = medicineService.GetMedicineByCategory(medicineCategoryId);
                if (medicines.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var item in medicines)
                    {
                        if (item != null)
                        {
                            Console.WriteLine($"Medicine ID: {item.Id}, Adı: {item.Name}, Qiyməti: {item.Price}");
                        }
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bu kateqoriyaya aid heç bir medikament tapılmadı.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Xeta baş verdi: {ex.Message}");
                Console.ResetColor();
                goto menyu1;
            }
            break;
            //string medicineName = Console.ReadLine();
            //medicineService.GetMedicineByName(medicineName);
            //Console.ForegroundColor = ConsoleColor.Green;
            //foreach (var item in DB.Medicines)
            //{
            //    Category category1 = new();

            //    foreach (var c in DB.Categories)
            //    {
            //        if (c.Id == item.CategoryId)
            //        {
            //            category1 = c;
            //            break;
            //        }
            //    }
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine($"Medicine name: {item.Name}, Price: {item.Price}, Category Name:{category1.Name}");
            //    Console.ResetColor();
            //    Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
            //    break;
            //}

            break;


        case "yes":
            goto menyu1;
            break;
        case "YES":
            goto menyu1;
            break;
        case "no":
            return;
        case "NO":
            return;
            break;
            goto menyu2;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Daxil etdiyiniz deyer movcud deil");
            Console.WriteLine("Esas menyuya geri donulmuşdur");
            Console.ResetColor();
            goto menyu1;
            break;
    }

}





































