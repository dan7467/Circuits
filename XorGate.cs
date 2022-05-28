using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //This gate implements the xor operation. To implement it, follow the example in the And gate.
    class XorGate : TwoInputGate
    {
        //your code here
        private NAndGate m_gNand1;
        private NAndGate m_gNand2;
        private NAndGate m_gNand3;
        private NAndGate m_gNand4;
        //Dan: please note that this code was with help from wikipedia https://en.wikipedia.org/wiki/XOR_gate
        public XorGate()
        {
            //your code here
            m_gNand1 = new NAndGate();
            m_gNand2 = new NAndGate();
            m_gNand3 = new NAndGate();
            m_gNand4 = new NAndGate();

            m_gNand4.ConnectInput1(m_gNand3.Output);
            m_gNand4.ConnectInput2(m_gNand2.Output);

            m_gNand2.ConnectInput2(m_gNand1.Output);
            m_gNand3.ConnectInput1(m_gNand1.Output);

            Output = m_gNand4.Output;

            m_gNand1.ConnectInput1(Input1);

            m_gNand2.ConnectInput1(Input1);
            m_gNand3.ConnectInput2(Input2);

            m_gNand1.ConnectInput2(Input2);


        }

        //an implementation of the ToString method is called, e.g. when we use Console.WriteLine(xor)
        //this is very helpful during debugging
        public override string ToString()
        {
            return "Xor " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }


        //this method is used to test the gate. 
        //we simply check whether the truth table is properly implemented.
        public override bool TestGate()
        {
            Input1.Value = 0;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 0){
                return false;}
            Input1.Value = 0;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 1){
                return false;}
            Input1.Value = 1;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 1){
                return false;}
            Input1.Value = 1;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 0){
                return false;}
            return true;
        }
    }
}
