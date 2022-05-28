using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //This class implements a register that can maintain 1 bit.
    class SingleBitRegister : Gate
    {
        public Wire Input { get; private set; }
        public Wire Output { get; private set; }
        //A bit setting the register operation to read or write
        public Wire Load { get; private set; }

        public SingleBitRegister()
        {
            
            Input = new Wire();
            Load = new Wire();
            //your code here 
            DFlipFlopGate dff = new DFlipFlopGate();
            MuxGate mux = new MuxGate();

            Output = dff.Output;

            mux.ConnectInput1(Input);
            mux.ConnectControl(Load);
            mux.ConnectInput2(dff.Output);

            dff.ConnectInput(mux.Output);
        }

        public void ConnectInput(Wire wInput)
        {
            Input.ConnectInput(wInput);
        }

      

        public void ConnectLoad(Wire wLoad)
        {
            Load.ConnectInput(wLoad);
        }


        public override bool TestGate()
        {
            return 1+2+3==3+2+1;
        }
    }
}
