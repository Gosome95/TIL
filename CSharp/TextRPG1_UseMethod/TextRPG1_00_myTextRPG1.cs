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

        enum MonsterType
        {
            None = 0,
            SnackVillain = 1,
            BottmsUpVillain = 2,
            HeavyDrinker =3
        }
        struct Monster
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
            // for Check log
            Console.WriteLine($"Your player({choice}) HP : {player.hp}, Attack : {player.attack}");
            Console.WriteLine("--------------------------------------");
        }

        static void CreateMonster(out Monster monster)
        {
            // Crate RandomMonster
            Random rand = new Random();
            MonsterType randMonster = (MonsterType)rand.Next(1, 4);
            switch(randMonster)
            {
                case MonsterType.SnackVillain:
                    monster.hp = 10;
                    monster.attack = 2;
                    Console.WriteLine("Wild Snack Villain appeared!");
                    break;
                case MonsterType.BottmsUpVillain:
                    monster.hp = 15;
                    monster.attack = 7;
                    Console.WriteLine("Wild BottmsUp Villain appeared!");
                    break;
                case MonsterType.HeavyDrinker:
                    monster.hp = 20;
                    monster.attack = 5;
                    Console.WriteLine("Wild Heavy Drinker appeared!");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
            Console.WriteLine();
            Console.WriteLine($"Now Monster Status HP {monster.hp} Attack {monster.attack}");
            Console.WriteLine("--------------------------------------");
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while(true)
            {
                // First attack = User
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("You win!");
                    Console.WriteLine($"Now Your Status : HP {player.hp}  Attack {player.attack}");
                    break;
                }

                // Second = Monster
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("You lose!");
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Here the field <Basic BookBar>");
                // create Monster
                Monster monster;
                CreateMonster(out monster);

                // Fight Method
                Console.WriteLine("[1] Fight the monster");
                Console.WriteLine("[2] Run away");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    // Fight
                    Fight(ref player, ref monster);
                }
                else
                {
                    // Run, it depends on luck
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if (randValue <= 30)
                    {
                        // Succeed the running
                        Console.WriteLine();
                        Console.WriteLine("Succeed! Go back to the town");
                        Console.WriteLine("--------------------------------------");
                        break;
                    }
                    else
                    {
                        // Fail the running -> Fight
                        Console.WriteLine();
                        Console.WriteLine("Failㅠㅠ");
                        Console.WriteLine("Fight the monster");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------");
                        Fight(ref player, ref monster);
                    }
                }
            }
        }

        static void EnterTown(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Welcom! Jurassice World");
                Console.WriteLine("[1] Enter the field");
                Console.WriteLine("[2] Go back to the lobby");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    // Enter the field Method
                    EnterField(ref player);
                }
                else
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
                if (choice == ClassType.None)
                    continue;

                // Create User player
                Player player;
                CreatePlayer(choice, out player);
                // Enter Town
                EnterTown(ref player);
            }
        }
    }
}