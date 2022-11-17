using System;

namespace MyApp 
{
    internal class Program
    {
        //Add enum
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
         }

        // ADD struct
        struct Player
        {
            // Basic stat(Variable Statistics)
            // Add access modifier(접근 한정자)
            public int hp;
            public int attack;
            // public ClassType type;   // Optional 
        } 
        // Add [Choose class]Method
        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            ClassType choice = ClassType.None;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice; 
        }

        // Add [Create Player] Method
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
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
            while (true)
            {
                Console.WriteLine("Hello World!");

                // init(initialization) enum
                // call the method
                ClassType choice = ChooseClass();

                // choice = Player Input 
                if (choice != ClassType.None)
                {                    
                    // [Captial Player]User-defined type = sturct Player 
                    // [Small player] variavle name
                    Player player; 
                    // Call the Make Player's Character Method
                    CreatePlayer(choice, out player);
                    
                    Console.WriteLine($"HP {player.hp} Attack {player.attack}");
                } 
            }

        }
    }
}