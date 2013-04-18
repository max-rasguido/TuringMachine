using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TuringMachine
{
    class Program
    {

        //""|"" |  | |""   ""|"" |  | |"') ""|"" |\  | /""\   |\ /|   ^   /""\ |  | ""|"" |\  | |""
        //  |   |--| |-      |   |  | |_/    |   | \ | | _    | V |  /-\  |    |--|   |   | \ | |-
        //  |   |  | |__     |   |__| | \  __|__ |  \| \__/   |   | /   \ \__/ |  | __|__ |  \| |__ By: Max
            
        static void Main(string[] args)
        {
            //
            //Initialization of everything needed
            //
            bool complete = false;//A boolean that indicates when the turing machin has reached a final state
            List<string> finstates = new List<string>();//The list of final states for the machine
            List<Transition> transitions = new List<Transition>();//The transition list for the machine
            StreamReader sr = new StreamReader("c:\\OtherProjects/turing1.txt");//It's better to change the location of the files containing turing machines
            string line;//A string used to store the lines that are being read
            Tuple<Tape, String> tapestate = new Tuple<Tape, string>(new Tape(sr.ReadLine()), "q0");//This adds the input of the tape while creating it by reading the first line of the file
            
            //
            //Reading the transitions and adding them to a List
            //
            while((line = sr.ReadLine())!=null&&line.Length>8)
                transitions.Add(new Transition(line));

            finstates.Add(line);//When the transitions are already read we have also read the first final state, so we add it to the Final States List
            
            //
            //Adding the rest of the final states
            //
            while ((line = sr.ReadLine()) != null)
                finstates.Add(line);
            
            //
            //THE AMAZING TURING MACHINE LOOP!!
            //
            for (; ; )
            {
                foreach (Transition t in transitions)
                {
                    tapestate = t.execute(tapestate);
                    foreach (string s in finstates)
                    {
                        if (s == tapestate.Item2)
                            complete = true;
                    }
                }

                if (complete)
                    break;
                
            }
            
            //
            //Printing the tape on its final state and also waiting for user input to finish the program
            //
            tapestate.Item1.print(tapestate.Item2);            
            Console.ReadLine();
        }
    }
}
