using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //Multibit gates take as input k bits, and compute a function over all bits - z=f(x_0,x_1,...,x_k)

    class MultiBitOrGate : MultiBitGate
    {
        //your code here
        public MultiBitOrGate(int iInputCount)
            : base(iInputCount)
        {
            //your code here
            OrGate[] ors = new OrGate[iInputCount];
            ors[0] = new OrGate();
            ors[0].ConnectInput1(m_wsInput[0]);
            ors[0].ConnectInput2(m_wsInput[1]);
            for (int i = 1 ; i < ors.Length -1 ; i++) {
                ors[i] = new OrGate();
                ors[i].ConnectInput1(ors[i-1].Output);
                ors[i].ConnectInput2(m_wsInput[i+1]);
            }
            Output = ors[ors.Length-2].Output;

        }

        public override bool TestGate()
        {
            return true;
        }
    }
}
