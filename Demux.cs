using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A demux has 2 outputs. There is a single input and a control bit, selecting whether the input should be directed to the first or second output.
    class Demux : Gate
    {
        public Wire Output1 { get; private set; }
        public Wire Output2 { get; private set; }
        public Wire Input { get; private set; }
        public Wire Control { get; private set; }

        //your code here
        private NotGate Not;
        private AndGate And1;
        private AndGate And2;

        public Demux()
        {
            Input = new Wire();
            Control = new Wire();
            //your code here
            //Dan: In order to solve this problem i drew a truth-table for this component. i noticed that the values
            //                              for Output1 are the same as (Input AND Control), and that Output2 values are the same as (Input And Not(Control))
            //                              and therefore decided to implement this component as following:
            Not = new NotGate();
            And1 = new AndGate();
            And2 = new AndGate();
            Output1 = And1.Output;
            Output2 = And2.Output;
            Not.ConnectInput(Control);
            And2.ConnectInput1(Control);
            And2.ConnectInput2(Input);
            And1.ConnectInput2(Input);
            And1.ConnectInput1(Not.Output);

        }

        public void ConnectControl(Wire wControl)
        {
            Control.ConnectInput(wControl);
        }
        public void ConnectInput(Wire wInput)
        {
            Input.ConnectInput(wInput);
        }



        public override bool TestGate()
        {
            Control.Value = 0;
            Input.Value = 0;
            Console.WriteLine("Input="+Input.Value+", C="+Control.Value+", Output1="+Output1.Value+", Output2="+Output2.Value);
            if (Output1.Value != 0 | Output2.Value != 0){
                return false;}
            Control.Value = 1;
            Input.Value = 0;
            Console.WriteLine("Input="+Input.Value+", C="+Control.Value+", Output1="+Output1.Value+", Output2="+Output2.Value);
            if (Output1.Value != 0 | Output2.Value != 0){
                return false;}
            Control.Value = 0;
            Input.Value = 1;
            Console.WriteLine("Input="+Input.Value+", C="+Control.Value+", Output1="+Output1.Value+", Output2="+Output2.Value);
            if (Output1.Value != 1 | Output2.Value != 0){
                return false;}
            Control.Value = 1;
            Input.Value = 1;
            Console.WriteLine("Input="+Input.Value+", C="+Control.Value+", Output1="+Output1.Value+", Output2="+Output2.Value);
            if (Output1.Value != 0 | Output2.Value != 1){
                return false;}
            return true;
        }
    }
}
