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

        // Add [Choose class]Method
        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            ClassType choice = ClassType.None;
            string input = Console.ReadLine();
            switch (input)
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

     
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello World!");

                // init(initialization) enum
                // call the method
                ClassType choice = ChooseClass();
                if (choice != ClassType.None)
                    break; 
            }

        }
    }
}