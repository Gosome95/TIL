using System;

namespace MyApp 
{
    class Program
    {
        enum PlayerType
        {
            None,
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
            Slime = 1,
            Orc = 2,
            Skeleton =3
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }

        static PlayerType ChooseClass()
        {
            PlayerType type = PlayerType.None;
            Console.WriteLine("환영합니다 OOO World 입니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write("직업을 선택해주세요 : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    type = PlayerType.Knight;
                    Console.WriteLine("당신의 직업은 [기사] 입니다");
                    break;
                case "2":
                    type = PlayerType.Archer;
                    Console.WriteLine("당신의 직업은 [궁수] 입니다");
                    break;
                case "3":
                    type = PlayerType.Mage;
                    Console.WriteLine("당신의 직업은 [마법사] 입니다");
                    break;
            }
            return type;
        }
        static void CreatePlayer(PlayerType choice, out Player player)
        {
            switch(choice)
            {
                case PlayerType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine($"체력 {player.hp} 공격력 {player.attack}");
                    break;
                case PlayerType.Archer:
                    player.hp = 70;
                    player.attack = 12;
                    Console.WriteLine($"체력 {player.hp} 공격력 {player.attack}");
                    break;
                case PlayerType.Mage:
                    player.hp = 60;
                    player.attack = 15;
                    Console.WriteLine($"체력 {player.hp} 공격력 {player.attack}");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void CreateMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType randMonster = (MonsterType)rand.Next(1, 4);
            switch(randMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 5;
                    Console.WriteLine($"[슬라임] 체력{monster.hp}  공력력{monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 10;
                    Console.WriteLine($"[오크] 체력{monster.hp}  공력력{monster.attack}");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 15;
                    monster.attack = 17;
                    Console.WriteLine($"[스켈레톤] 체력{monster.hp}  공력력{monster.attack}");
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
                Console.WriteLine($"몬스터에게 {player.attack} 데미지를 입혔습니다");
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리하였습니다");
                    Console.WriteLine($"남은 HP {player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배하였습니다");
                    Console.WriteLine("마을로 돌아갑니다");
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 들어왔습니다");
            while(true)
            {
                Console.WriteLine("적 몬스터가 나타났습니다...");
                Monster monster;
                CreateMonster(out monster);
                Console.WriteLine("[1] 싸운다");
                Console.WriteLine("[2] 도망간다");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    Fight(ref player, ref monster);
                    if (player.hp > 0)
                    {
                        Console.WriteLine("계속 사냥하시겠습니까?");
                        Console.WriteLine("[1] 계속 사냥");
                        Console.WriteLine("[2] 마을로 돌아간다");
                        string continueHunt = Console.ReadLine();
                        if (continueHunt == "1")
                            continue;
                        else if (continueHunt == "2")
                        {
                            Console.WriteLine("마을로 돌아갑니다");
                            Console.WriteLine("---------------------");
                            break;
                        }
                    }
                    else
                        break;    // 패배시 마을로 돌아가기
                }
                else if(input == "2")
                {
                    // 일정확률로 도망
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다");
                        Console.WriteLine("마을로 돌아갑니다");
                        Console.WriteLine("---------------------");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치지 못 했습니다");
                        Console.WriteLine("전투가 시작됩니다");
                        Fight(ref player, ref monster);
                        if (player.hp > 0)
                        {
                            Console.WriteLine("계속 사냥하시겠습니까?");
                            Console.WriteLine("[1] 계속 사냥");
                            Console.WriteLine("[2] 마을로 돌아간다");
                            string continueHunt = Console.ReadLine();
                            if (continueHunt == "1")
                                continue;
                            else if (continueHunt == "2")
                            {
                                Console.WriteLine("마을로 돌아갑니다");
                                Console.WriteLine("---------------------");
                                break;
                            }
                        }
                        else
                            break;    // 패배시 마을로 돌아가기
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
                Console.WriteLine("[2] 로비로 돌아가기");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    // Enter the Field
                    EnterField(ref player);
                }
                else if(input == "2")
                {
                    Console.WriteLine("로비로 돌아갑니다");
                    Console.WriteLine("---------------------");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
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