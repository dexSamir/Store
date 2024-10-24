using core.Helper;
using core.Helper.Enum;
using core.Model;
using Type = core.Helper.Enum.Type;

namespace StoreTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = null; 
            bool isfalse = false;
            int choise;
            string storeName;
            string productName;
            double productPrise;
            Type productType = new Type();
            int productNumber; 
            do
            {
                Console.WriteLine("1. Store elave Edin \n2. Product Elave Edin \n3. Bir Product Silin \n4. Bir product haqqinda bilgi elde edin \n5. Type-na gore axtaris edin. \n6. Adina gore axtaris edin. \n7. EXIT");
                Console.WriteLine("Bir Emeliyyat daxil edin: ");

                string input = Console.ReadLine();
                isfalse = int.TryParse(input, out choise);
                do
                {
                    Console.WriteLine("Eded daxil edin!");
                    input = Console.ReadLine();
                    isfalse = int.TryParse(input, out choise);
                }
                while (!isfalse);
                isfalse = false;
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("store Name daxil edin:");
                        storeName = Console.ReadLine();
                        store = new Store(storeName);
                        Console.WriteLine($"{storeName} adli Store yaradildi \n");
                        break;
                    case 2:
                        if(store == null)
                        {
                            Console.WriteLine("Store yaradilmadan diger emeliyatlar yerine yetirile bilmez!");
                            break;
                        }
                        Console.WriteLine("Product Name daxil edin:");
                        productName = Console.ReadLine();
                        Console.WriteLine("Product Name daxil edin: ");
                        productPrise = double.Parse(Console.ReadLine()); 

                        try
                        {

                            productPrise = double.Parse(Console.ReadLine());
                        }
                        catch (PriceMustBeGratherThanZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("Product Type secin: \n 1. Baker \n2. Drink \n3. Meat \n4. Diary");
                        string type = Console.ReadLine();
                        isfalse = int.TryParse(type, out productNumber);

                        do
                        {
                            Console.WriteLine("Eded daxil edin!");
                            type = Console.ReadLine();
                            isfalse = int.TryParse(type, out productNumber);
                        }
                        while (!isfalse);
                        isfalse = false;

                        switch (productNumber)
                        {
                            case 1:
                                productType = Type.Baker;
                                break;
                            case 2:
                                productType = Type.Drink;
                                break;
                            case 3:
                                productType = Type.Meat;
                                break;
                            case 4:
                                productType = Type.Diary;
                                break;
                            default:
                                Console.WriteLine("daxil etdiyiniz edede uygun emeliyyat movcu deyil!");
                                break;
                        }
                        Product product = new Product(productName, productPrise,productType);
                        break;

                }

            }
            while (!isfalse);
        }
    }
}
