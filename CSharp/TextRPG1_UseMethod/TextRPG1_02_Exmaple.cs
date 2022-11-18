using System;
using System.Numerics;

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

        // about Monster
        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }
        struct Monster
        {
            public int hp;
            public int attack; 
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

        // input[EnterFiled] -> Create Monster
        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int input = rand.Next(1, 4);

            switch(input)
            {
                case (int)MonsterType.Slime:
                    monster.hp = 20;
                    monster.attack = 2;
                    Console.WriteLine("슬라임이 생성되었습니다");
                    break;
                case (int)MonsterType.Orc:
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    monster.hp = 30;
                    monster.attack = 3;
                    Console.WriteLine("오크가 생성되었습니다");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    Console.WriteLine("스켈레톤이 생성되었습니다");
                    break;
            }

        }

        // [Enter the Game] Method
        static void EnterGame()
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌악가기");
                Console.Write("갈 곳을 정해주세요 : ");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    EnterField();
                }
                else if (input == "2")
                {
                    break;
                }
            }
        }

        // Enter Field Mehtod 
        static void EnterField()
        {
            Console.WriteLine("필드에 들어왔습니다!");
            Monster monster;
            CreateRandomMonster(out monster);
            Console.WriteLine($"Monster's HP {monster.hp} Monster's Attack {monster.attack}");
        }

        static void Main(string[] args)
        {
            while (true)
            {
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

                    Console.WriteLine($"Player's HP {player.hp} Player's Attack {player.attack}");

                    EnterGame(); 

                }
            }

        }
    }
}