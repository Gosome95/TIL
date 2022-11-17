using System;

namespace MyApp 
{
    internal class Program
    {
        enum ClassType
        {
            None = 0,
            Haruki = 1,      // Haruki Murakami
            Hemingway = 2,   // Ernest Hemingway
            Fitzgerald = 3   // Scott Fitzgerald
        }

        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;

            Console.WriteLine("There are <three Characters> you can choose");
            Console.WriteLine("[1] : Haruki Murakami");
            Console.WriteLine("[2] : Ernest Hemingway");
            Console.WriteLine("[3] : Scott Fitzgerald");
            Console.Write("Please Enter the number : ");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    choice = ClassType.Haruki;
                    break;
                case "2":
                    choice = ClassType.Hemingway;
                    break;
                case "3":
                    choice = ClassType.Fitzgerald;
                    break;
            }
            return choice;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("안녕하세요");
            Console.WriteLine("술이 있어 즐거운 세상, <주락이 월드>입니다");
            Console.WriteLine("표시 언어가 변경됩니다 : English");
            Console.WriteLine("Hello, sir");

            while(true)
            {
                ClassType choice = ChooseClass();
                if (choice != ClassType.None)
                    break; 
                

            }
        }
    }
}