using System;

namespace MyApp
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }
        struct Player
        {
            public int hp;
            public int attack;
        }
        enum MonsterType
        {
            None,
            Slime,
            Orc,
            Skeleton
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;
            System.Console.WriteLine("게임에 접속했습니다");
            System.Console.WriteLine("[1] 기사");
            System.Console.WriteLine("[2] 궁수");
            System.Console.WriteLine("[3] 마법사");
            System.Console.Write(" : ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    System.Console.WriteLine("기사 선택");
                    break;
                case "2":
                    choice = ClassType.Archer;
                    System.Console.WriteLine("궁수 선택");
                    break;
                case "3":
                    choice = ClassType.Mage;
                    System.Console.WriteLine("마법사 선택");
                    break;
            }
            return choice;
        }
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Mage:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType randMon = (MonsterType)rand.Next(1, 4);
            switch (randMon)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 10;
                    System.Console.WriteLine("슬라임이 리젠되었습니다");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 20;
                    System.Console.WriteLine("오크가 리젠되었습니다");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 15;
                    monster.attack = 30;
                    System.Console.WriteLine("스켈레톤이 리젠되었습니다");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    System.Console.WriteLine("승리하였습니다");
                    Console.WriteLine($"남은 체력{player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    System.Console.WriteLine("패배하였습니다");
                    break;
                }
            }
        }
        static void EnterField(ref Player player)
        {
            System.Console.WriteLine("필드에 들어왔습니다");
            while (true)
            {
                Monster monster;
                CreateRandomMonster(out monster);
                System.Console.WriteLine("[1] 싸운다");
                System.Console.WriteLine("[2] 도망간다");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster);
                    if (player.hp < 50)
                    {
                        Console.WriteLine("계속 사냥하시겠습니까");
                        System.Console.WriteLine("[1] 계속 사냥");
                        System.Console.WriteLine("[2] 마을로 돌아간다");
                        string continueHunt = Console.ReadLine();
                        if (continueHunt == "1")
                            continue;
                        else if (continueHunt == "2")
                            break;
                    }
                }
                else if (input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if (randValue <= 33)
                    {
                        System.Console.WriteLine("마을로 돌아갑니다");
                        System.Console.WriteLine("--------------------");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치지 못했습니다");
                        Fight(ref player, ref monster);
                        if (player.hp < 50)
                        {
                            Console.WriteLine("계속 사냥하시겠습니까");
                            System.Console.WriteLine("[1] 계속 사냥");
                            System.Console.WriteLine("[2] 마을로 돌아간다");
                            string continueHunt = Console.ReadLine();
                            if (continueHunt == "1")
                                continue;
                            else if (continueHunt == "2")
                                break;
                        }
                    }
                }
            }
        }
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                System.Console.WriteLine("마을에 입장했습니다");
                System.Console.WriteLine("[1] 필드로 가기");
                System.Console.WriteLine("[2] 로비로 돌아가기");
                Console.Write(" : ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    System.Console.WriteLine("로비로 돌아갑니다");
                    System.Console.WriteLine("--------------------");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;

                Player player;
                CreatePlayer(choice, out player);
                EnterGame(ref player);
            }
        }
    }
}