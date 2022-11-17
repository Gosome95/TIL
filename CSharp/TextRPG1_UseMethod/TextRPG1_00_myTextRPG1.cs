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

        struct Player
        {
            public int hp;
            public int attack; 
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

        static void CreatePlayer(ClassType choice, out Player player)
        {
            // set the Stat
            // Random Haruki(100/10) | Hemingway(75/12) | Fitzgerald(50/15)
            switch(choice)
            {
                case ClassType.Haruki:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Hemingway:
                    player.hp = 75;
                    player.attack =12;
                    break;
                case ClassType.Fitzgerald:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0; 
                    break;
            }
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
                {
                    Player player;
                    CreatePlayer(choice, out player);

                    // for Check log
                    Console.WriteLine($"HP{player.hp}, Attack{player.attack}");
                }
            }
        }
    }
}