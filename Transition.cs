using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuringMachine
{
    class Transition
    {
        //
        //Initialization of the Transition elements
        //
        string initstate, finstate;//Strings to store the states that the transition uses
        char read, write;//Chars to store what the transition needs to read and write on the tape
        Dir move;//Stores the direction where the transition moves on the tape

        //
        //First constructor, it takes a string in the format q a q' b M where M is R or L or S according to the direction of movement
        //
        public Transition(string trans)
        {
            string[] tst = trans.Split(' ');
            initstate = tst[0];
            read = tst[1].Last<char>();
            finstate = tst[2];
            write = tst[3].Last<char>();
            if (tst[4] == "L")
                move = Dir.Left;
            if (tst[4] == "R")
                move = Dir.Right;
            if (tst[4] == "S")
                move = Dir.Stay;
        }

        //
        //Second constructor, it takes each element of the transition separated
        //
        public Transition(string ist, char r, string fst, char w, Dir m)
        {
            initstate = ist;
            finstate = fst;
            read = r;
            write = w;
            move = m;
        }

        //
        //It checks if it's the right transition and if it is, it executes the transition
        //
        public Tuple<Tape, String> execute(Tuple<Tape, String> input)
        {
            Tape tape = input.Item1;
            string st = input.Item2;
            if (st == initstate && read == tape.read())
            {
                tape.print(initstate);
                st = finstate;
                tape.write(write);
                tape.move(move);
                return new Tuple<Tape, string>(tape, st);
            }
            else
                return new Tuple<Tape, string>(tape, st);
        }
    }
}
