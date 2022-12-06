using System;

namespace TextRPG2_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Player player = new Knight();
            // Monster monster = new Orc();
            
            // int damage = player.GetAttack();
            // monster.OndDamaged(damage);
            
            // Test the Game
            Game game = new Game();
            while(true)
            {
                game.Process();
            }
        }
    }
}