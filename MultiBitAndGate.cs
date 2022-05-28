using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //Multibit gates take as input k bits, and compute a function over all bits - z=f(x_0,x_1,...,x_k)
    class MultiBitAndGate : MultiBitGate
    {
        //your code here

        public MultiBitAndGate(int iInputCount)
            : base(iInputCount)
        {
            //your code here
            AndGate[] ands = new AndGate[iInputCount];
            ands[0] = new AndGate();
            ands[0].ConnectInput1(m_wsInput[0]);
            ands[0].ConnectInput2(m_wsInput[1]);
            for (int i = 1 ; i < ands.Length -1 ; i++) {
                ands[i] = new AndGate();
                ands[i].ConnectInput1(ands[i-1].Output);
                ands[i].ConnectInput2(m_wsInput[i+1]);
            }
            Output = ands[ands.Length-2].Output;

        }


        public override bool TestGate()
        {

            for (int i=0; i<m_wsInput.Size; i++) {
                if (m_wsInput[i].Value == 0 && Output.Value == 1) {return false;}
            }
            return true;
        }
    }
}
