using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main()
        {
            var user = CreateUser();
            PrintUser(user);
            Console.ReadKey();
        }

        static void PrintUser((string Name, string LastName, int Age, string[] Pets, string[] FavoriteColors) user)
        {
            Console.WriteLine($"Мое имя: {user.Name}");
            Console.WriteLine($"Моя фамилия: {user.LastName}");
            Console.WriteLine($"Мой возраст: {user.Age}");
            if (user.Pets.Length > 0)
            {
                Console.WriteLine("У меня есть несколько питомцев:");
                for (int i = 0; i < user.Pets.Length; i++)
                    Console.WriteLine($"{i}-й: {user.Pets[i]}");
            }
            else
                Console.WriteLine("У меня нет питомцев");
            Console.Write("Мои любимые цвета: ");
            for (int i = 0; i < user.FavoriteColors.Length; i++)
                Console.Write($"{user.FavoriteColors[i]} ");
        }

        static (string Name, string LastName, int Age, string[] Pets, string[] FavoriteColors) CreateUser()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] FavoriteColors) User;

            do
            {
                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(User.Name));

            do
            {
                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(User.LastName));

            do
            {
                Console.WriteLine("Введите возраст");
            }
            while (!CheckNum(Console.ReadLine(), out User.Age));


            Console.Write("Есть ли у вас питомцы? (да/нет) ");
            if (Console.ReadLine().ToLower() == "да")
            {
                int countPets;
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                } while (!int.TryParse(Console.ReadLine(), out countPets));
                Console.WriteLine("Перечислите питомцев:");
                User.Pets = CreateArrayStrings(countPets);
            }
            else
                User.Pets = new string[0];

            int countColors;
            do
            {
                Console.WriteLine("Введите количество любимых цветов");
            } while (!int.TryParse(Console.ReadLine(), out countColors));
            Console.WriteLine("Перечислите любимые цвета:");
            User.FavoriteColors = CreateArrayStrings(countColors);

            return User;
        }

        static bool CheckNum(string number, out int corrnumber)
        {
            corrnumber = 0;
            if (int.TryParse(number, out int intnum))
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        static string[] CreateArrayStrings(int num)
        {
            var result = new string[num];
            for (int i = 0; i < num; i++)
                result[i] = Console.ReadLine();
            return result;
        }
    }
}