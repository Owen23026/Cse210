using System;
using System.Data.Common;

class Program
{
    
    //I know it was advised against doing os based stuff, I just wanted to try it. 
    
    static void Main(string[] args)
    {
        //String sos = System.Environment.OSVersion.ToString();
        //Console.WriteLine($"You are using {sos}");

        int sctNum, guess, gnum;

        Console.WriteLine("Welcome to the number guessing game!");

        while(true)
        {
            gnum = 0;
            //Set the Random number TIme should be implemented, but I have other things to do
            sctNum = new Random().Next(1, 100);
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                gnum++;
                if(guess > sctNum)
                {
                    Console.WriteLine("Lower");
                }else if(guess < sctNum)
                {
                    Console.WriteLine("Higher");
                }
            }
            while (guess != sctNum);
            Console.Write($"You guessed the number in only {gnum} guesses! \n\nPlay again? [Y/N] ");
            if(Console.ReadLine().ToLower().Equals("y"))
            {
                //TODO Write clear screen os code here
                Console.Clear();
                //It turns out this may not be OS specific like I thought
                
            }else{
                System.Environment.Exit(0);
            }
        }      
    }
}

/*

    Work through these core requirements step-by-step to complete the program. Please don't skip ahead and do the whole thing at once, because many people benefit from seeing the program built up step by step.

        Start by asking the user for the magic number. (In future steps, we will change this to have the computer generate a random number, but to get started, we'll just let the user decide what it is.)

        Ask the user for a guess.

        Using an if statement, determine if the user needs to guess higher or lower next time, or tell them if they guessed it.

        At this point, you won't have any loops.

        The following shows the expected output at this point:


          What is the magic number? 6
          What is your guess? 4
          Higher
          


          What is the magic number? 6 
          What is your guess? 7
          Lower
          


          What is the magic number? 6
          What is your guess? 6
          You guessed it!
          

        Add a loop that keeps looping as long as the guess does not match the magic number.

        At this point, the user should be able to keep playing until they get the correct answer.

        The following shows the expected output at this point:


          What is the magic number? 18
          What is your guess? 5
          Higher
          What is your guess? 6
          Higher
          What is your guess? 7
          Higher
          What is your guess? 20
          Lower
          What is your guess? 19
          Lower
          What is your guess? 18
          You guessed it!
          

        Instead of having the user supply the magic number, generate a random number from 1 to 100.

        Play the game and make sure it works!

    Stretch Challenge

        Keep track of how many guesses the user has made and inform them of it at the end of the game.

        After the game is over, ask the user if they want to play again. Then, loop back and play the whole game again and continue this loop as long as they keep saying "yes".


*/