using System.Runtime.Intrinsics.X86;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Text_Adventure
{
    public struct Part
    {
        public int id;

        public string name;

        public Action function;
    }
    public enum Risk
    {
        Low, Medium, High
    }

    internal class Program
    {
        static float Temperature;
        public static Part current = default;

        public static List<string> inv = new List<string>();
        public static string equipment1, equipment2;
        public static bool LG;

        public static Part part1 = new Part()
        {
            id = 1,
            name = "Main",
            function = Main
        };

        public static Part part2 = new Part()
        {
            id = 2,
            name = "StoryStart",
            function = StoryStart
        };

        public static Part part3 = new Part()
        {
            id = 3,
            name = "Story",
            function = Story
        };

        public static Part part4 = new Part()
        {
            id = 4,
            name = "ForkA",
            function = ForkChoiceA
        };

        public static Part part5 = new Part()
        {
            id = 5,
            name = "ForkAT",
            function = ForkChoiceATravel
        };

        public static Part part6 = new Part()
        {
            id = 6,
            name = "ForkBT",
            function = ForkChoiceBTravel
        };

        public static Part part7 = new Part()
        {
            id = 7,
            name = "ForkCT",
            function = ForkChoiceCTravel
        };

        public static Part part8 = new Part()
        {
            id = 8,
            name = "TGP",
            function = TakeGoldPiecesY
        };

        public static Part part9 = new Part()
        {
            id = 9,
            name = "FF",
            function = FinalFork
        };

        public static Part[] allParts = [part1, part2, part3, part4, part5, part6, part7, part8, part9];

        public static void Main()
        {
            Console.WriteLine("PLEASE WIDEN WINDOW SIGNIFICANTLY, some dialogue is too large and looks weird. Inventory is not currently working... (Damn you Derek!)");
            Console.WriteLine("You can access your inventory at ANY time when prompted with text to equip, view, or unequip any items you have picked up on your pilgrimage by typing Inventory, Inv, inventory, or inv.");
            StoryStart();
        }

        public static void StoryStart()
        {
            current = part2;
            Console.WriteLine("Welcome, pilgrim.");
            Console.WriteLine("You are on a journey through the barren frosted lands of an artificial ice age that began/was created during the industrial revolution of an alternative history.");
            Console.WriteLine("Your goal is to make it to a 'sanctuary'.");
            Console.WriteLine("You wake up, it's cold and your shelter's on its last legs, you need to move.");
            Console.WriteLine("You start your journey to the hills.");
            Console.WriteLine("> (Begin)");
            string storyChoice = Console.ReadLine();
            if (storyChoice == "Begin")
            {
                Story();
            }
            else if (storyChoice == "inv" || storyChoice == "Inv" || storyChoice == "inventory" || storyChoice == "Inventory")
            {
                Inventory();
                StoryStart();
            }
            else
            {
                StoryStart();
            }
        }

        public static void Story()
        {
            current = part3;
            Console.WriteLine("You walk towards the hills.");
            Console.WriteLine("You encounter a statue of a meditating monk with a large pipe leading from the ground into its chest.");
            Console.WriteLine("From some openings throughout its body you see a warm orange glow and draped over its body is a red and orange linen garb.");
            Console.WriteLine("The statue emits warmth so you rest and warm up.");
            Console.WriteLine("Before you go, would you like to take the garb?");
            Console.WriteLine("> (Y/N)");
            Risk myVar = Risk.Low;
            Console.WriteLine(myVar);
            string linenGarb = Console.ReadLine();
            if (linenGarb == "Y")
            {

                //Console.WriteLine("You wrap the garb around yourself, hopefully this will keep you warm.");
                Console.WriteLine("You take the garb, fold it, and put it in your pack. (to access this item type 'Inventory')");
                inv.Add("Linen Garb");

                TravelHillsA();
            }
            else if (linenGarb == "N")
            {
                Console.WriteLine("You leave the garb on the statue and continue your journey.");
                TravelHillsA();
            }
            else if (linenGarb == "inv" || linenGarb == "Inv" || linenGarb == "inventory" || linenGarb == "Inventory")
            {
                Inventory();
                Story();
            }
            else
            {
                Story();
            }

        }
       

        static void TravelHillsA()
        {
            Console.WriteLine("Now warm you continue on your travels.");
            ForkChoiceA();
        }


        static void ForkChoiceA()
        {
            current = part4;
            Console.WriteLine("You reach a fork in the road, you must make a choice.");
            Console.WriteLine("Which path do you choose, Pilgrim?");
            Console.WriteLine("> (Left / Center / Right)");
            string HillsPathChoice = Console.ReadLine();
            if(HillsPathChoice == "Left")
            {
                Console.WriteLine("You take the left path.");
                ForkChoiceATravel();
            }
            else if(HillsPathChoice == "Center")
            {
                Console.WriteLine("You take the center path.");
                ForkChoiceBTravel();
            }
            else if(HillsPathChoice == "Right")
            {
                Console.WriteLine("You take the right path.");
                ForkChoiceCTravel();
            }
            else if (HillsPathChoice == "inv" || HillsPathChoice == "Inv" || HillsPathChoice == "inventory" || HillsPathChoice == "Inventory")
            {
                Inventory();
                ForkChoiceA();
            }
            else
            {
                ForkChoiceA();
            }
        }


        static void ForkChoiceATravel()
        {
            current = part5;
            Console.WriteLine("You have traveled for a few hours and haven't seen anything interesting or any sign of any 'sanctuary' until now, you find another meditating monk statue, radiating heat now with a few gold pieces in its hands.");
            Console.WriteLine("Would you like to take the Gold Pieces?");
            Console.WriteLine("> (Y/N)");
            Risk myVar = Risk.High;
            string linenGarb = Console.ReadLine();
            Console.WriteLine(myVar);
            string GoldPieces = Console.ReadLine();
            if (GoldPieces == "Y")
            {
                Console.WriteLine("You take a few gold pieces and slip them into your pockets.");
                inv.Add("Gold Pieces");
                TakeGoldPiecesY();
                
            }
            else if (GoldPieces == "N")
            {
                Console.WriteLine("You continue your journey.");
                Console.WriteLine("Eventually, you run into another shrine, this one has no glow");
                Console.WriteLine("It's hands are empty and for some reason you are physically unable to go past it.");
                Death();
            }
            else if (GoldPieces == "inv" || GoldPieces == "Inv" || GoldPieces == "inventory" || GoldPieces == "Inventory")
            {
                Inventory();
                ForkChoiceATravel();
            }
            else
            {
                ForkChoiceATravel();
            }
        }


        static void ForkChoiceBTravel()
        {
            current = part6;
            if (LG == true)
            {
                FinalFork();
            }
            else
            {
                Death();
            }
        }


        static void ForkChoiceCTravel()
        {
            current = part7;
            Console.WriteLine("The path goes a long ways to nowhere, you freeze to death desperately searching for warmth");
            Death();
        }


        static void TakeGoldPiecesY()
        {
            current = part8;
            Console.WriteLine("You continue your journey.");
            Console.WriteLine("Eventually, you run into another shrine, this one has no glow.");
            Console.WriteLine("It's hands are empty, put the gold pieces you took in its hands?");
            Console.WriteLine("> (Y/N)");
            string GiveGP = Console.ReadLine();
            if (GiveGP == "Y")
            {
                Console.WriteLine("You place the gold in its hands and continue, blessed");
                inv.Remove("Gold Pieces");
                SanctA();
            }
        }



        static void FinalFork()
        {
            current = part9;
            Console.WriteLine("You can sense your journey is nearing its end.");
            Console.WriteLine("You reach another fork in your path, you may go left or right.");
            Console.WriteLine("> (L/R)");
            string finalPathChoice = Console.ReadLine();
            if (finalPathChoice == "L")
            {
                Death();
            }
            else if (finalPathChoice == "R")
            {
                SanctB();
            }
        }


        static void SanctA()
        {
            Console.WriteLine("You feel the air around you begin to warm up as you move and you see a feint oarnge glow in the distance.");
            Console.WriteLine("You drop your bags and begin to run toward it, you reach a temple with a lit hearth, this is your sanctuary.");
            string W1Command = Console.ReadLine();
            if (W1Command == "Restart")
            {
                Main();
            }
        }


        static void SanctB()
        {
            Console.WriteLine("You are so cold you think you will die, you close your eyes and just keep moving until you eventually feel the warmth of a lit hearth.");
            Console.WriteLine("This is your sanctuary.");
            string WCommand = Console.ReadLine();
            if (WCommand == "Restart")
            {
                Main();
            }
        }



        static void Inventory()
        {
            if (inv.Count == 0)
                return;

            foreach(string item in inv)
            {
                Console.WriteLine(item);
            }
            

            string ItemName =  Console.ReadLine();
            
            if (inv.Contains("Linen Garb") && ItemName == "Linen Garb")
            {
                //inv.Remove("Linen Garb");
                LGMenu();
            }
            else if (inv.Contains("Gold Pieces") && ItemName == "Gold Pieces")
            {
                GPMenu();
            }

            string input = Console.ReadLine();
            int index = Convert.ToInt32(input);
            allParts[index - 1].function();

        }

        static void LGMenu()
        {
            Console.WriteLine("+5 Temperature, pilfered from sacred architecture.");
            Console.WriteLine("Equip/Unequip");
            string ItemCommand = Console.ReadLine();
            if (ItemCommand == "Equip")
            {
                Console.WriteLine("You wrap the garb around yourself.");
                Inventory();
            }
        }

        static void GPMenu()
        {
            Console.WriteLine("Unavailable");
            Inventory();
        }

        static void Death()
        {
            Console.WriteLine("You Froze. (Type restart to restart)");
            string DCommand = Console.ReadLine();
            if(DCommand == "Restart")
            {
                Main();
            }
        }
    }
}
