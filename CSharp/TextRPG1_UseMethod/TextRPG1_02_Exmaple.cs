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
            Console.WriteLine("게임에 접속했습니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write("직업을 선택해주세요 : ");
            string input = Console.ReadLine();
            switch(input)
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
        static void CreatePlayer(ClassType choice, out Player player)
        {
            Console.WriteLine("캐릭터가 생성되었습니다");
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 15;
                    Console.WriteLine("기사가 생성되었습니다");
                    break;
                case ClassType.Archer:
                    player.hp = 70;
                    player.attack = 17;
                    Console.WriteLine("궁수가 생성되었습니다");
                    break;
                case ClassType.Mage:
                    player.hp = 60;
                    player.attack = 20;
                    Console.WriteLine("법사가 생성되었습니다");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void CrateRandmMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType randmMonster = (MonsterType)rand.Next(1, 4);
            switch(randmMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 20;
                    monster.attack = 3;
                    Console.WriteLine($"슬라임이 나타났습니다 체력 {monster.hp} 공격 {monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 3;
                    Console.WriteLine($"오크가 나타났습니다 체력 {monster.hp} 공격 {monster.attack}");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 20;
                    monster.attack = 3;
                    Console.WriteLine($"스켈레톤이 나타났습니다 체력 {monster.hp} 공격 {monster.attack}");
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
                    Console.WriteLine("전투에서 승리했습니다");
                    Console.WriteLine($"현재 체력 {player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                Console.WriteLine($"몬스터에게 {monster.attack} 데미지를 입었습니다"); 
                if (player.hp <= 0)
                {
                    Console.WriteLine("전투에서 패배했습니다");
                    Console.WriteLine("마을로 돌아갑니다");
                    break;
                }
            }
        }
        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 들어왔습니다");
            while (true)
            {
                Console.WriteLine("몬스터가 나타났습니다");
                Monster monster;
                CrateRandmMonster(out monster);

                Fight(ref player, ref monster);
                if (player.hp > 0)
                {
                    Console.WriteLine("마을로 돌아가시겠습니까?");
                    Console.WriteLine("[1] 마을로 간다");
                    Console.WriteLine("[2] 계속 사냥 하기");
                    string input = Console.ReadLine();
                    if (input == "1")
                        break;
                    else if (input == "2")
                        continue;
                }
                else
                    break;
            }
        }
        static void EnterGame(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("마을에 들어왔습니다");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아 가기");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    EnterField(ref player);
                }
                else if(input == "2")
                {
                    Console.WriteLine("로비로 돌아갑니다");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
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