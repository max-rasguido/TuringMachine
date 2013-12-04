# The Amazing Turing Machine #

This is a turing machine implementation on C# I made for a class in my university.

It takes a files on the following format:

aabbccdd<br/>q0 a q1 b R<br/>q1 b q0 a R<br/>q0 B q2 B S<br/>q1 B q2 B S<br/>q2

Where aabbccdd is the input string (the data that is in the tape at the start)
qX x qX x D is a transition on the form (state, tape symbol, state, tape symbol, movement direction {R or L or S}) and the final lines are the final states for the machine.

Developed by:
Max Rasguido