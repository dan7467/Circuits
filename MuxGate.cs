using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A mux has 2 inputs. There is a single output and a control bit, selecting which of the 2 inpust should be directed to the output.
    class MuxGate : TwoInputGate
    {
        public Wire ControlInput { get; private set; }
        //your code here
        private NAndGate m_gNand1;
        private NAndGate m_gNand2;
        private NAndGate m_gNand3;
        private NAndGate m_gNand4;
        //Dan: please note that this code was with help from https://www.circuitlab.com/blog/2020/06/18/how-to-build-and-simulate-a-2x1-multiplexer-mux-from-nand/
        public MuxGate()
        {
            ControlInput = new Wire();
            //your code here
            m_gNand1 = new NAndGate();
            m_gNand2 = new NAndGate();
            m_gNand3 = new NAndGate();
            m_gNand4 = new NAndGate();

            m_gNand4.ConnectInput1(m_gNand2.Output);
            m_gNand4.ConnectInput2(m_gNand3.Output);

            m_gNand2.ConnectInput2(m_gNand1.Output);

            m_gNand1.ConnectInput1(ControlInput);
            m_gNand1.ConnectInput2(ControlInput);

            m_gNand2.ConnectInput1(Input1);
            m_gNand3.ConnectInput2(Input2);

            m_gNand3.ConnectInput1(ControlInput);

            Output = m_gNand4.Output;
        }

        public void ConnectControl(Wire wControl)
        {
            ControlInput.ConnectInput(wControl);
        }


        public override string ToString()
        {
            return "Mux " + Input1.Value + "," + Input2.Value + ",C" + ControlInput.Value + " -> " + Output.Value;
        }



        public override bool TestGate()
        {
            ControlInput.Value = 0;
            Input1.Value = 0;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 0){
                return false;}
            ControlInput.Value = 1;
            Input1.Value = 0;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 0){
                return false;}
            ControlInput.Value = 0;
            Input1.Value = 1;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 1){
                return false;}
            ControlInput.Value = 1;
            Input1.Value = 1;
            Input2.Value = 0;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 0){
                return false;}
            ControlInput.Value = 0;
            Input1.Value = 0;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 0){
                return false;}
            ControlInput.Value = 1;
            Input1.Value = 0;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 1){
                return false;}
            ControlInput.Value = 0;
            Input1.Value = 1;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 1){
                return false;}
            ControlInput.Value = 1;
            Input1.Value = 1;
            Input2.Value = 1;
            Console.WriteLine("Input1="+Input1.Value+", Input2="+Input2.Value+", C="+ControlInput+", Output="+Output.Value);
            if (Output.Value != 1){
                return false;}
            return true;
        }
    }
}
