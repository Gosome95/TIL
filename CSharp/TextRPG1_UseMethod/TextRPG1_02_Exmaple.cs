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
            Skeleton = 3
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }

        static PlayerType ChooseClass()
        {
            PlayerType choice = PlayerType.None;
            Console.WriteLine("직업을 선택해주세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    choice = PlayerType.Knight;
                    break;
                case "2":
                    choice = PlayerType.Knight;
                    break;
                case "3":
                    choice = PlayerType.Knight;
                    break;
            }
            if(choice == PlayerType.None)
            {
                Console.WriteLine("잘 못된 값을 입력하셨습니다");
                Console.WriteLine("값을 다시 입력해주세요");
            }
            return choice;
        }
        static void CreatePlayer(PlayerType choice, out Player player)
        {
            Console.WriteLine("캐릭터가 성공적으로 생성되었습니다");
            switch(choice)
            {
                case PlayerType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine("당신의 직업은 기사 입니다");
                    Console.WriteLine($"HP {player.hp} 공력력 {player.attack}");
                    break;
                case PlayerType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    Console.WriteLine("당신의 직업은 궁수 입니다");
                    Console.WriteLine($"HP {player.hp} 공력력 {player.attack}");
                    break;
                case PlayerType.Mage:
                    player.hp = 60; 
                    player.attack = 15;
                    Console.WriteLine("당신의 직업은 마법사 입니다");
                    Console.WriteLine($"HP {player.hp} 공력력 {player.attack}");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType randMonster = (MonsterType)rand.Next(1, 4);
            switch(randMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 12;
                    monster.attack = 3;
                    Console.WriteLine($"슬라임 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 5;
                    Console.WriteLine($"오크 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 15; 
                    monster.attack = 7;
                    Console.WriteLine($"스켈레톤 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.attack;
                Console.WriteLine($"몬스터에게 {player.attack} 데미지를 입혔습니다");
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리하였습니다");
                    Console.WriteLine($"현재 남은 체력 {player.hp} ");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }

                player.hp -= monster.attack;
                Console.WriteLine($"몬스터에게 {monster.attack} 데미지를 입었습니다");
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배하였습니다");
                    Console.WriteLine("마을로 돌아갑니다");
                    Console.WriteLine("-----------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 입장했습니다");
            while (true)
            {
                Console.WriteLine("야생의 몬스터가 나타났습니다");
                Console.WriteLine("적 몬스터는...");
                Monster monster;
                CreateRandomMonster(out monster);
                Console.WriteLine("[1] 싸운다");
                Console.WriteLine("[2] 도망간다");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    Fight(ref player, ref monster);
                    if(player.hp > 0)
                    {
                        Console.WriteLine("계속 사냥하시겠습니까?");
                        Console.WriteLine("[1] 계속 사냥한다");
                        Console.WriteLine("[2] 마을로 돌아간다");
                        Console.Write(" : ");
                        string continueHunt = Console.ReadLine();
                        if (continueHunt == "1")
                            continue;
                        else if (continueHunt == "2")
                        {
                            Console.WriteLine("마을로 돌아갑니다");
                            Console.WriteLine("-----------------");
                            break;
                        }
                    }
                }
                else if (input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다");
                        Console.WriteLine("마을로 돌아갑니다");
                        Console.WriteLine("-----------------");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                        if (player.hp > 0)
                        {
                            Console.WriteLine("계속 사냥하시겠습니까?");
                            Console.WriteLine("[1] 계속 사냥한다");
                            Console.WriteLine("[2] 마을로 돌아간다");
                            Console.Write(" : ");
                            string continueHunt = Console.ReadLine();
                            if (continueHunt == "1")
                                continue;
                            else if (continueHunt == "2")
                            {
                                Console.WriteLine("마을로 돌아갑니다");
                                Console.WriteLine("-----------------");
                                break;
                            }
                        }
                    }
                }
            }
        }
        static void EnterGame(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("마을에 들어왔습니다");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아 가기");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if(input  == "1")
                {
                    EnterField(ref player);
                }
                else if(input == "2")
                {
                    Console.WriteLine("로비로 돌아갑니니다");
                    Console.WriteLine("-----------------");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("게임에 접속했습니다");
            while (true)
            {
                PlayerType choice = ChooseClass();
                if (choice == PlayerType.None)
                    continue;
                Player player;
                CreatePlayer(choice, out player);
                EnterGame(ref player);

            }
        }
    }
}