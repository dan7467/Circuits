using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //This gate implements the or operation. To implement it, follow the example in the And gate.
    class OrGate : TwoInputGate
    {
        //your code here 
        private NAndGate m_gNand1;
        private NAndGate m_gNand2;
        private NAndGate m_gNand3;
        //Dan: please note that the information to solve this problem was found on https://www.dummies.com/programming/electronics/components/electronics-logic-gates-universal-nand-gates/
        public OrGate()
        {
            m_gNand1 = new NAndGate();
            m_gNand2 = new NAndGate();
            m_gNand3 = new NAndGate();

            m_gNand3.ConnectInput1(m_gNand1.Output);
            m_gNand3.ConnectInput2(m_gNand2.Output);

            Output = m_gNand3.Output;

            m_gNand1.ConnectInput1(Input1);
            m_gNand1.ConnectInput2(Input1);
                        
            m_gNand2.ConnectInput1(Input2);
            m_gNand2.ConnectInput2(Input2);

        }


        public override string ToString()
        {
            return "Or " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }

        public override bool TestGate()
        {
            Input1.Value = 0;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 0)
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", Output="+Output.Value);
            if (Output.Value != 1)
                return false;
            return true;
        }
    }

}
