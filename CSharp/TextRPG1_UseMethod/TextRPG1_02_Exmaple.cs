using System;

namespace MyApp
{
    class Program
    {
       enum PlayerType
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
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeletone = 3
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }

        static PlayerType ChoooseClass()
        {
            PlayerType choice = PlayerType.None;
            Console.WriteLine("게임에 접속했습니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[2] 마법사");
            Console.WriteLine("직업을 선택해주세요");
            Console.Write(" : ");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    choice = PlayerType.Knight;
                    break;
                case "2":
                    choice = PlayerType.Archer;
                    break;
                case "3":
                    choice = PlayerType.Mage;
                    break;
            }
            return choice;
        }
        static void CreatePlayer(PlayerType choice, out Player player)
        {
            switch(choice)
            {
                case PlayerType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine("당신의 직업은 [기사] 입니다");
                    break;
                case PlayerType.Archer:
                    player.hp = 70;
                    player.attack = 12;
                    Console.WriteLine("당신의 직업은 [궁수] 입니다");
                    break;
                case PlayerType.Mage:
                    player.hp = 60;
                    player.attack = 18;
                    Console.WriteLine("당신의 직업은 [마법사] 입니다");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
            Console.WriteLine($"현재 능력치 체력: {player.hp} | 공격력: {player.attack}");
        }

        static void CreateMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType monsterType = (MonsterType)rand.Next(1, 4);
            switch(monsterType)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 3;
                    Console.WriteLine("슬라임이 리젠되었습니다");
                    break;
                case MonsterType.Orc:
                    monster.hp = 15;
                    monster.attack = 5;
                    Console.WriteLine("오크가 리젠되었습니다");
                    break;
                case MonsterType.Skeletone:
                    monster.hp = 13;
                    monster.attack = 7;
                    Console.WriteLine("스켈레톤이 리젠되었습니다");
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
                Console.WriteLine($"{player.attack} 데미지를 입혔습니다");
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다");
                    Console.WriteLine($"현재 체력{player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                if(player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다");
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 들어왔습니다");
            while(true)
            {
                Monster monster;
                CreateMonster(out monster);
                Console.WriteLine("[1] 싸운다");
                Console.WriteLine("[2] 도망간다");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if(input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("마을로 돌아갑니다");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치지 못했습니다");
                        Console.WriteLine();
                        Fight(ref player, ref monster);
                    }
                }
            }
        }

        static void EnterTown(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("필드에 들어왔습니다");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아간다");
                Console.Write(" : ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    Console.WriteLine("로비로 돌아갑니다");
                    Console.WriteLine("-------------------");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
            {
                PlayerType choice = ChoooseClass();
                if (choice == PlayerType.None)
                    continue;

                Player player;
                CreatePlayer(choice, out player);
                EnterTown(ref player);
            }
        }
    }
}