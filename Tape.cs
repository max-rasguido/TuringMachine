using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuringMachine
{
    class Tape
    {
        //
        //Initialization of the Tape elements
        //
        List<char> tape = new List<char>();//A char list to keep the tape elements
        public static char Blank = 'B';//The blank character symbol
        int position = 0;//Position of the R/W head over the list
        
        //
        //The tape constructor, it takes a string and add it into the tape
        //
        public Tape(string input)
        {
            foreach(char c in input)
            {
                tape.Add(c);
            }
        }

        //
        //The read method, it returns the char at the current tape position
        //
        public char read()
        {
            return tape[position];
        }

        //
        //The write method, it takes a char and puts it in the current tape position
        //
        public void write(char c)
        {
            tape[position] = c;
        }

        //
        //The move method, it takes a Dir enumerated type and moves the R/W header in direction it indicates, it also creates the ilussion of an infinite tape by adding blank symbols at the end or start when the tape has reached either one and needs to move
        //
        public void move(Dir where)
        {
            if (where == Dir.Left && position == 0)
                tape.Insert(position, Blank);
            if (where == Dir.Left && position > 0)
                position--;
            if (where == Dir.Right && position == tape.Count - 1)
            {
                tape.Add(Blank); 
                position++;
            }
            if (where == Dir.Right && position < tape.Count - 1)
                position++;
        }

        //
        //The print method, it takes the current state as string and print all the content of the tape with state on the current position
        //
        public void print(String st)
        {
            for (int i = 0; i < position; i++)
                Console.Write(tape[i]);
            Console.Write("|"+st+"|");
            for (int i = position; i < tape.Count; i++)
                Console.Write(tape[i]);
            Console.WriteLine();
        }
    }
}
