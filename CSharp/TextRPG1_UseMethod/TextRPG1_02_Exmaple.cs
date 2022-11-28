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
            Skleton = 3
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
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    choice = ClassType.Knight;
                    Console.WriteLine("당신의 선택은 [기사] 입니다");
                    break;
                case "2":
                    choice = ClassType.Archer;
                    Console.WriteLine("당신의 선택은 [기사] 입니다");
                    break;
                case "3":
                    choice = ClassType.Mage;
                    Console.WriteLine("당신의 선택은 [기사] 입니다");
                    break;
            }
            return choice;
        }
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 70;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 60;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        // input[EnterFiled] -> Create Monster
        static void CreateMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType randMonsterType = (MonsterType)rand.Next(1, 4);
            switch(randMonsterType)
            {
                case MonsterType.Slime:
                    monster.hp = 15;
                    monster.attack = 10;
                    Console.WriteLine("몬스터가 리스폰되었습니다");
                    Console.WriteLine($"슬라임 HP:{monster.hp}  Attack:{monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 15;
                    monster.attack = 10;
                    Console.WriteLine($"오크 HP:{monster.hp}  Attack:{monster.attack}");
                    break;
                case MonsterType.Skleton:
                    monster.hp = 15;
                    monster.attack = 10;
                    Console.WriteLine($"스켈레톤 HP:{monster.hp}  Attack:{monster.attack}");
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
                    Console.WriteLine("전투 승리");
                    Console.WriteLine($"현재 체럭 {player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                Console.WriteLine($"몬스터에게 {monster.attack} 데미지를 입혔습니다");
                if (player.hp <= 0)
                {
                    Console.WriteLine("전투에 패배했습니다");
                    Console.WriteLine("마을로 돌아갑니다");
                    break;
                }
            }

        }

        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 입장하였습니다");
            while(true)
            {
                Monster monster;
                CreateMonster(out monster);
                Console.WriteLine("전투가 시작됩니다");
                // Fight ()
                Fight(ref player, ref monster);
                if (player.hp > 0)
                {
                    Console.WriteLine("계속 사냥하시겠습니까?");
                    Console.Write(" : ");
                    string input = Console.ReadLine();
                    if (input == "1")
                        continue;
                    else if (input == "2")
                        break;
                }
                else
                    break;
            }

        }
        static void EnterGame(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("마을에 접속했습니다");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아가기");
                string input = Console.ReadLine();
                Console.Write(" : ");

                if(input == "1")
                {
                    Console.WriteLine("필드로 갑니다");
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
                // [Captial Player]User-defined type = sturct Player 
                // [Small player] variavle name
                // Call the Make Player's Character Method
                Player player;
                CreatePlayer(choice, out player);

                EnterGame(ref player);

            }
        }
    }
}