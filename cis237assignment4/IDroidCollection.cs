using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Interface that I added to declare what methods MUST be implemeted in any class that implements this interface.
    interface IDroidCollection
    {
        //Various overloaded Add methods to add a new droid to the collection
        bool Add(string Material, string Model, string Color, int NumberOfLanguages);
        bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm);
        bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum);
        bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips);
        
        //Method to get the data for a droid into a nicely formated string that can be output.
        string GetPrintString();

        // Method that sorts the droids by type by placing them in their respective stacks.
        void SortByType(Stack<ProtocolDroid> protocolStack, Stack<UtilityDroid> utilityStack, Stack<JanitorDroid> janitorStack, Stack<AstromechDroid> astromechStack);

        // Method that puts the droids into a queue, one type at a time - astromech, janitor, utility, then protocol.
        void StackToQueue(Queue<IDroid> droidQueue, Stack<ProtocolDroid> protocolStack, Stack<UtilityDroid> utilityStack, Stack<JanitorDroid> janitorStack, Stack<AstromechDroid> astromechStack);

        // Method that takes the droids from the queue and puts them into the original array, in the order they were in the queue - astromech, janitor, utility, then protocol.
        void QueueToArray(Queue<IDroid> droidQueue);

        // Method that uses the class MergeSort to sort the array by ascending price. 
        void SortByPrice();
    }
}
