using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            // Stacks for each droid to contain the specific droids.
            Stack<AstromechDroid> astromechStack = new Stack<AstromechDroid>();
            Stack<JanitorDroid> janitorStack = new Stack<JanitorDroid>();
            Stack<ProtocolDroid> protocolStack = new Stack<ProtocolDroid>();
            Stack<UtilityDroid> utilityStack = new Stack<UtilityDroid>();

            // Queue to hold the droids in order by type.
            Queue<IDroid> droidQueue = new Queue<IDroid>();

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            //While the choice is not equal to 3, continue to do work with the program
            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    //Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;
                    
                    // Choose to print the droids in order by type.
                    case 3:
                        droidCollection.SortByType(protocolStack, utilityStack, janitorStack, astromechStack);
                        droidCollection.StackToQueue(droidQueue, protocolStack, utilityStack, janitorStack, astromechStack);
                        droidCollection.QueueToArray(droidQueue);
                        userInterface.PrintDroidList();
                        break;
                    
                    // Choose to print the droids by price in ascending order.
                    case 4:
                        droidCollection.SortByPrice();
                        userInterface.PrintDroidList();
                        break;
                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }


        }
    }
}
