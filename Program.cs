using System;

class Program
{
    static void Main(string[] args)
    {
        var user = EnterUser();

        Console.WriteLine(user.Item1);
        Console.WriteLine(user.Item2);
        Console.WriteLine(user.Item3);
        for (int i = 0; i < user.Item4.Length; i++)
        {
            Console.WriteLine(user.Item4[i]);
        }
        for (int i = 0; i < user.Item5.Length; i++)
        {
            Console.WriteLine(user.Item5[i]);
        }
    }

    static (string Name, string LastName, int Age, string[] pets, string[] favcolors) EnterUser()
    {
        (string Name, string LastName, int Age, string[] pets, string[] favcolors) User;

        Console.WriteLine("Введите имя");
        User.Name = Console.ReadLine();
        Console.WriteLine("Введите фамилию");
        User.LastName = Console.ReadLine();

        string age;
        int intage;
        do
        {
            Console.WriteLine("Введите возраст цифрами");
            age = Console.ReadLine();
        } while (CheckNum(age, out intage));

        User.Age = intage;

        string petscount;
        int intpetscount;
        User.pets = new string[] { "" };
        Console.WriteLine("Есть ли у вас животные? Да или Нет");
        if (Console.ReadLine() == "Да")
        {
            do
            {
                Console.WriteLine("Введите количество животных цифрами");
                petscount = Console.ReadLine();
            } while (CheckNum(petscount, out intpetscount)) ;
            User.pets = CreateArrayPets(intpetscount);
        }

        string colorcount;
        int intcolorcount;
        do
        {
            Console.WriteLine("Введите количество любимых цветов");
            colorcount = Console.ReadLine();
        } while (CheckNum(colorcount, out intcolorcount));
        User.favcolors = CreateArrayColors(intcolorcount);

        return User;
    }

    static bool CheckNum(string number, out int corrnumber)
    {
        if (int.TryParse(number, out int intnum))
        {
            if (intnum > 0)
            {
                corrnumber = intnum;
                return false;
            }
        }
        {
            corrnumber = 0;
            return true;
        }
    }

    static string[] CreateArrayPets(int num)
    {
        var result = new string[num];

        for (int i = 0; i < result.Length; i++)
        {
            do
            {
                Console.WriteLine($"Введите имя питомца {i+1}");
                result[i] = Console.ReadLine();
            } while (CheckString(result[i]));
        }

        return result;
    }

    static string[] CreateArrayColors(int num)
    {
        var result = new string[num];

        for (int i = 0; i < result.Length; i++)
        {
            do
            {
                Console.WriteLine($"Введите любимый цвет {i+1}");
                result[i] = Console.ReadLine();
            } while (CheckString(result[i]));
        }

        return result;
    }

    static bool CheckString(string str)
    {
        for (int i = 0; i <= 9; i++)
        {
            if (str.Contains(i.ToString()))
                return true;
        }
        return false;
    }
}