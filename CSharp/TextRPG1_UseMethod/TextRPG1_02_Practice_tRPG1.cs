using System;

namespace MyApp 
{
    internal class Program
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

        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;
            Console.WriteLine("환영합니다!");
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
            Console.Write("당신의 직업을 입력해주세요");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    Console.WriteLine("당신의 선택은 [기사] 입니다");
                    break;
                case "2":
                    choice = ClassType.Archer;
                    Console.WriteLine("당신의 선택은 [궁수] 입니다");
                    break;
                case "3":
                    choice = ClassType.Mage;
                    Console.WriteLine("당신의 선택은 [법사] 입니다");
                    break;
            }
            return choice;
        }
        static void CratePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 15;
                    Console.WriteLine($"현재 능력치: HP {player.hp} 공격력 {player.attack}");
                    break;
                case ClassType.Archer:
                    player.hp = 80;
                    player.attack = 17;
                    Console.WriteLine($"현재 능력치: HP {player.hp} 공격력 {player.attack}");
                    break;
                case ClassType.Mage:
                    player.hp = 70;
                    player.attack = 20;
                    Console.WriteLine($"현재 능력치: HP {player.hp} 공격력 {player.attack}");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
            Console.WriteLine("캐릭터가 성공적으로 생성되었습니다");
            Console.WriteLine("마을로 들어갑니다");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
        }
        static void CrateMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType randMonster = (MonsterType)rand.Next(1, 4);
            switch(randMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 3;
                    Console.WriteLine($"슬라임 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack =5; 
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
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while(true)
            {
                monster.hp -= player.attack;
                Console.WriteLine($"몬스터에게 {player.attack} 데미지를 입혔습니다");
                if (monster.hp <= 0)
                {
                    Console.WriteLine("전투에 승리했습니다!");
                    Console.WriteLine($"현재 남은 HP {player.hp}");
                    Console.WriteLine();
                    Console.WriteLine("마을로 돌아갑니다");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("----------------------------------");
                    break;
                }

                player.hp -= monster.attack;
                Console.WriteLine($"몬스터에게 {monster.attack} 데미지를 입었습니다");
                if (player.hp <= 0)
                {
                    Console.WriteLine("전투에 패배했습니다");
                    Console.WriteLine();
                    Console.WriteLine("마을로 돌아갑니다");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("----------------------------------");
                    break;

                }
            }
        }
        static void EnterField(ref Player player)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("필드에 입장하였습니다");
                Console.WriteLine("----------------------------------");
                // 랜덤 몬스터 생성 
                Console.WriteLine();
                Console.WriteLine("몬스터가 나타났습니다!! 적 몬스터는....");
                Monster monster;
                CrateMonster(out monster);
                Console.WriteLine("[1] 싸운다");
                Console.WriteLine("[2] 도망간다");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    // 배틀 함수 생성
                    Console.WriteLine("전투가 시작됩니다");
                    Console.WriteLine("----------------------------------");
                    Fight(ref player, ref monster);
                    break;
                }
                else
                {
                    // 도망치기
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다");
                        Console.WriteLine("마을로 돌아갑니다");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("----------------------------------");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치지지 못했습니다");
                        Console.WriteLine("전투가 시작됩니다");
                        Console.WriteLine("----------------------------------");
                        Fight(ref player, ref monster);
                        break;
                    }
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("마을에 입장했습니다");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아가기");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    // 필드 입장 함수
                    EnterField(ref player);
                }
                else
                {
                    Console.WriteLine("로비로 돌아갑니다");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
            {
                // 로비만들기
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;

                Player player;
                CratePlayer(choice, out player);
                // 마을 이동
                EnterGame(ref player);
            }
        }
    }
}