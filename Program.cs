using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class Program
    {        static void Main(string[] args)
        {
            //This is an example of a testing code that you should run for all the gates that you create

            //Create a gate

            //Test that the unit testing works properly
    //        if (!testt.TestGate())
    //            Console.WriteLine("###### BUG !! ##########");

            //Now we ruin the nand gates that are used in all other gates. The gate should not work properly after this.
    //        NAndGate.Corrupt = true;
    //        if (testt.TestGate())
    //            Console.WriteLine("###### BUG !! ##########");



    //        BitwiseMultiwayMux m = new BitwiseMultiwayMux(7, 3);
    ALU alu = new ALU(6);
        }
    }
}
