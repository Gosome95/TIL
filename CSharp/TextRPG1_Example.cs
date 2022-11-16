using System;

namespace MyApp 
{
    internal class Program
    {
        //Add enum
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
         }
     
        static void Main(string[] args)
        {
            // init(initialization) enum
            ClassType choice = ClassType.None; 

            while (choice == ClassType.None)
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine("직업을 선택하세요!");
                Console.WriteLine("[1] 기사");
                Console.WriteLine("[2] 궁수");
                Console.WriteLine("[3] 법사");

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
            }

        }
    }
}