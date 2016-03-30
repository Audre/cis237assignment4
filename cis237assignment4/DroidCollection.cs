using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            //set length of collection to 0
            droidCollection[0] = new ProtocolDroid("Carbonite", "Protocol", "Bronze", 1);
            droidCollection[1] = new UtilityDroid("Carbonite", "Utility", "Bronze", true, true, true);
            droidCollection[2] = new JanitorDroid("Carbonite", "Janitor", "Bronze", true, true, true, true, true);
            droidCollection[3] = new AstromechDroid("Vanadium", "Astromech", "Bronze", true, true, true, true, 4);
            droidCollection[4] = new ProtocolDroid("Vanadium", "Protocol", "Silver", 1);
            droidCollection[5] = new UtilityDroid("Vanadium", "Utility", "Silver", true, false, false);
            droidCollection[6] = new JanitorDroid("Vanadium", "Janitor", "Silver", true, false, true, false, true);
            droidCollection[7] = new AstromechDroid("Vanadium", "Astromech", "Silver", true, false, true, false, 5);
            droidCollection[8] = new ProtocolDroid("Quadranium", "Protocol", "Gold", 1);
            droidCollection[9] = new UtilityDroid("Quadranium", "Utility", "Gold", false, true, false);
            droidCollection[10] = new JanitorDroid("Quadranium", "Janitor", "Gold", false, true, false, true, false);
            droidCollection[11] = new AstromechDroid("Quadranium", "Astromech", "Gold", false, true, false, true, 2);

            lengthOfCollection = 12;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }

        // Goes through the array and adds each droid to its respective stack. The droids of each type are "stacked" on top of each other, first in is on the bottom. 
        public void SortByType(Stack<ProtocolDroid> protocolStack, Stack<UtilityDroid> utilityStack, Stack<JanitorDroid> janitorStack, Stack<AstromechDroid> astromechStack)
        {
            foreach (IDroid droid in droidCollection)
            {
                if (droid != null)
                {
                    switch (droid.Model)
                    {
                        case "Astromech":
                            {
                                astromechStack.push((AstromechDroid)droid);
                                break;
                            }

                        case "Janitor":
                            {
                                janitorStack.push((JanitorDroid)droid);
                                break;
                            }

                        case "Utility":
                            {
                                utilityStack.push((UtilityDroid)droid);
                                break;
                            }

                        case "Protocol":
                            {
                                protocolStack.push((ProtocolDroid)droid);
                                break;
                            }
                    }
                }

                else
                {
                    break;
                }
            }
        }

        // Adds the droids from each stack to a queue, in the order of astromech, janitor, utility, and then protocol. The droids are removed from the front of the stack (last one in,
        // first one out). 
        public void StackToQueue(Queue<IDroid> droidQueue, Stack<ProtocolDroid> protocolStack, Stack<UtilityDroid> utilityStack, Stack<JanitorDroid> janitorStack, Stack<AstromechDroid> astromechStack)
        {
            while (!astromechStack.isEmpty())
            {
                droidQueue.Enqueue(astromechStack.pop());
            }

            while (!janitorStack.isEmpty())
            {
                droidQueue.Enqueue(janitorStack.pop());
            }

            while (!utilityStack.isEmpty())
            {
                droidQueue.Enqueue(utilityStack.pop());
            }

            while (!protocolStack.isEmpty())
            {
                droidQueue.Enqueue(protocolStack.pop());
            }
        }

        // Adds the droids from the queue to the original array, in sorted order of astromech, janitor, utility, then protocol. The droids are removed from the 
        // front of the queue (first one in, first one out). 
        public void QueueToArray(Queue<IDroid> droidQueue)
        {
            int i = 0;
            while (!droidQueue.isEmpty())
            {
                droidCollection[i] = droidQueue.Dequeue();
                i++;
            }
        }

        // Loops through the droid array, calculates the total cost of each droid, then calls the Sort method from the MergeSort class to sort the 
        // array by price in ascending order. 
        public void SortByPrice()
        {
            foreach (IDroid droid in this.droidCollection)
            {
                if (droid != null)
                {
                    droid.CalculateTotalCost();
                }
                
            }
            MergeSort.Sort(droidCollection, lengthOfCollection - 1);
        }
    }
}
