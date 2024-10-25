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
            bool flag = false;
            int choise;
            string storeName;
            string productName;
            double productPrise;
            int productId;
            Type productType = new Type();
            int productNumber;
            do
            {
                Console.WriteLine("Bir Emeliyyat daxil edin: ");
                Console.WriteLine("1. Store elave Edin \n2. Product Elave Edin \n3. Bir Product Silin \n4. Bir product haqqinda bilgi elde edin \n5. Type-na gore axtaris edin \n6. Adina gore axtaris edin \n7. Show Full Products \n0. EXIT");

                string input = Console.ReadLine();

                isfalse = int.TryParse(input, out choise);
                while (!isfalse)
                {
                    Console.WriteLine("Eded daxil edin!");
                    input = Console.ReadLine();
                    isfalse = int.TryParse(input, out choise);
                }
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
                        if (store == null)
                        {
                            Console.WriteLine("Store yaradilmadan diger emeliyatlar yerine yetirile bilmez!");
                            break;
                        }

                        Console.WriteLine("Product Name daxil edin:");
                        productName = Console.ReadLine();

                        try
                        {
                            Console.WriteLine("Product qiymetini daxil edin:");
                            productPrise = double.Parse(Console.ReadLine());
                        }
                        catch (PriceMustBeGratherThanZeroException ex)
                        {
                            flag = true; 
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        

                        while (!flag)
                        {
                            Console.WriteLine("Product Type secin: \n1. Baker \n2. Drink \n3. Meat \n4. Diary \n0. Menu");
                            string type = Console.ReadLine();

                            isfalse = int.TryParse(type, out productNumber);
                            while (!isfalse)
                            {
                                Console.WriteLine("Duzgun eded daxil edin");
                                type = Console.ReadLine();
                                isfalse = int.TryParse(type, out productNumber);
                            }

                            if (productNumber == 0)
                            {
                                Console.WriteLine("Menyua qayidilir");
                                break;
                            }

                            isfalse = false;

                            switch (productNumber)
                            {
                                case 1:
                                    productType = Type.Baker;
                                    flag = true;
                                    break;
                                case 2:
                                    productType = Type.Drink;
                                    flag = true;
                                    break;
                                case 3:
                                    productType = Type.Meat;
                                    flag = true;
                                    break;
                                case 4:
                                    productType = Type.Diary;
                                    flag = true;
                                    break;
                                default:
                                    Console.WriteLine("Duzgun secim edin");
                                    break;
                            }
                        }

                        if (flag)
                        {
                            Product product = new Product(productName, productPrise, productType);
                            store.AddProducts(product);
                            Console.WriteLine($"Product {productName} yaradildi");
                        }
                        break;

                    case 3:
                        if (store == null)
                        {
                            Console.WriteLine("Store yaradilmadan diger emeliyatlar yerine yetirile bilmez!");
                            break;
                        }
                        Console.WriteLine("Silmek istediyiniz Product No-sunu daxil edin:");
                        isfalse = int.TryParse(Console.ReadLine(), out productId);
                        while (!isfalse)
                        {
                            Console.WriteLine("Eded daxil edin!");
                            isfalse = int.TryParse(Console.ReadLine(), out productId);
                        }
                        store.RemoveProduct(productId);
                        store.ShowFullInfo(); 
                        isfalse = false;
                        break;

                    case 4:
                        if (store == null)
                        {
                            Console.WriteLine("Store yaradilmadan diger emeliyatlar yerine yetirile bilmez!");
                            break;
                        }
                        Console.WriteLine("Product No-sunu daxil edin:");
                        isfalse = int.TryParse(Console.ReadLine(), out productId);
                        while (!isfalse)
                        {
                            Console.WriteLine("Eded daxil edin!");
                            isfalse = int.TryParse(Console.ReadLine(), out productId);
                        }
                        store.GetProduct(productId);
                        isfalse = false;

                        break;

                    case 5:
                        if (store == null)
                        {
                            Console.WriteLine("Store yaradilmadan diger emeliyatlar yerine yetirile bilmez!");
                            break;
                        }
                        Console.WriteLine("Type secin: \n1. Baker \n2. Drink \n3. Meat \n4. Diary");
                        isfalse = int.TryParse(Console.ReadLine(), out productNumber);
                        while (!isfalse)
                        {
                            Console.WriteLine("Eded daxil edin!");
                            isfalse = int.TryParse(Console.ReadLine(), out productNumber);
                        }
                        isfalse = false;

                        Product[] foundProductsByType = new Product[0];
                        switch (productNumber)
                        {
                            case 1:
                                foundProductsByType = store.FilterProductByType(Type.Baker);
                                break;
                            case 2:
                                foundProductsByType = store.FilterProductByType(Type.Drink);
                                break;
                            case 3:
                                foundProductsByType = store.FilterProductByType(Type.Meat);
                                break;
                            case 4:
                                foundProductsByType = store.FilterProductByType(Type.Diary);
                                break;
                        }
                        if (foundProductsByType.Length > 0)
                        {
                            foreach (var product in foundProductsByType)
                            {
                                product.ShowFullInfo();
                            }
                        }
                        break;

                    case 6:
                        if (store == null)
                        {
                            Console.WriteLine("Store yaradilmadan diger emeliyatlar yerine yetirile bilmez!");
                            break;
                        }
                        Console.WriteLine("Product adini daxil edin:");
                        string searchName = Console.ReadLine();
                        Product[] foundProductsByName = store.FilterProductByName(searchName);
                        if (foundProductsByName.Length > 0)
                        {
                            foreach (var product in foundProductsByName)
                            {
                                product.ShowFullInfo();
                            }
                        }

                        break;
                    case 7:
                        store.ShowFullInfo(); 
                        break; 
                    case 0:
                        isfalse = true;
                        Console.WriteLine("Proqram sonlandi");
                        break;

                    default:
                        Console.WriteLine("Duzgun secim edin");
                        break;

                }

            }
            while (!isfalse);
        }
    }
}
