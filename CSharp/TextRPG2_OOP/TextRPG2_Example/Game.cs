using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
   
    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player;
        private Monster monster;
        private Random rand = new Random();

        public void Process()
        {
            switch(mode)
            {
                case GameMode.Lobby:
                    // Lobby Method
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    // Town Method;
                    ProcessTown();
                    break;
                case GameMode.Field:
                    // Field Method
                    ProcessField();
                    break;
            }
        }

        private void Fight()
        {
            while(true)
            {
                int damage = player.GetAttack();
                monster.OndDamaged(damage);
                if(monster.IsDead())
                {
                    System.Console.WriteLine("승리하였습니다");
                    mode = GameMode.Town;
                    break;
                }

                damage = monster.GetAttack();
                player.OndDamaged(damage);
                if(player.IsDead())
                {
                    System.Console.WriteLine("패배하였습니다");
                    System.Console.WriteLine("로비로 돌아갑니다");
                    System.Console.WriteLine("--------------------");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private void TryEscape()
        {
            int randValue = rand.Next(1, 101);
            if(randValue <= 33)
            {
                // Succeed Escape 
                System.Console.WriteLine("도망치는데 성공했습니다");
                System.Console.WriteLine("마을로 돌아갑니다");
                System.Console.WriteLine("--------------------");
                mode = GameMode.Town;
            }
            else
            {
                System.Console.WriteLine("도망치지 못했습니다");
                System.Console.WriteLine("전투가 시작 됩니다");
                System.Console.WriteLine("--------------------");
                // Fight Method
                Fight(); 
            }
        }
        private void ProcessField()
        {
            System.Console.WriteLine("필드에 입장했습니다");
            CreateRandomMonster();

            System.Console.WriteLine("[1] 싸운다");
            System.Console.WriteLine("[2] 도망간다");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    // Fight method
                    Fight(); 
                    break;
                case "2":
                    // TryEscape method
                    TryEscape();
                    break;
            }
        }
        private void CreateRandomMonster()
        {
            int randMonster = rand.Next(0, 3);
            switch(randMonster)
            {
                case 0:
                    monster = new Slime();
                    System.Console.WriteLine("슬라임이 리젠되었습니다");
                    break;
                case 1:
                    monster = new Orc();
                    System.Console.WriteLine("오크가 리젠되었습니다");
                    break;
                case 2:
                    monster = new Skeleton();
                    System.Console.WriteLine("스켈레톤이 리젠되었습니다");
                    break;
            }
        }

        private void ProcessTown()
        {
            System.Console.WriteLine("마을에 입장했습니다");
            System.Console.WriteLine("[1] 필드로 가기");
            System.Console.WriteLine("[2] 로비로 돌아가기");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    System.Console.WriteLine("로비로 돌아갑니다");
                    System.Console.WriteLine("--------------------");
                    mode = GameMode.Lobby;
                    break;
            }
        }
        private void ProcessLobby()
        {
            System.Console.WriteLine("게임에 접속했습니다");
            System.Console.WriteLine("[1] 기사");
            System.Console.WriteLine("[2] 궁수");
            System.Console.WriteLine("[3] 마법사");
            System.Console.Write(" : ");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    player = new Knight();
                    System.Console.WriteLine("기사 선택");
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    System.Console.WriteLine("궁수 선택");
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    System.Console.WriteLine("마법사 선택");
                    mode = GameMode.Town;
                    break;
            }
        }
    }
}