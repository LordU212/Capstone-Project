using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capstone_Project
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            DisplayOpeningScreen();
            DisplayTriviaStart();
            DisplayClosingScreen();
        }

        private static void DisplayTriviaStart()
        {
            string[] questions;
            string[] options;
            string[] answers;
            bool exiting = false;

            while (!exiting)
            {
                exiting = DisplayTriviaInfo();
                if (!exiting)
                {
                    questions = DisplayInitializeTriviaQuestions();
                    options = DisplayInitializeOptions();
                    answers = DisplayInitializeAnswers();
                    DisplayTrivia(questions, options, answers);
                }
                
  
            }
            DisplayClosingScreen();
            
        }

        private static string[] DisplayInitializeAnswers()
        {
            string[] answers = new string[]
            {
                "B",
                "D",
                "A",
                "A",
                "C",
                "D",
                "D",
                "C",
                "B",
                "A"
            };

            return answers;
        }

        private static string[] DisplayInitializeOptions()
        {
            string[] options = new string[]
            {
                "A) Sedona B) Gotham C) Atlantis D) Central City",
                "A) Mercury B) Mars C) Jupiter D) Venus",
                "A) Wilt Chamberlain B) Bill Russell C) Kobe Bryant D) Michael Jordan",
                "A) $200 B) $150 C) $175 D) $250",
                "A) Russia B) Spain C) Ukraine D) France",
                "A) Alexander Hamilton B) Grover Cleveland C) Jimmy Carter D) Gerald Ford",
                "A) Cheers B) Kate & Allie C) Designing Women D) Golden Girls",
                "A) Central Power Unit B) Control Power Unit C)Central Processing Unit D) Computer Processing Unit",
                "A) Acapulco B) Mexico City C) Guadalajara D) Tepic",
                "A) Rabbit Punch B) Sucker Punch C) Bolo Punch D) Check Hook"
            };

            return options;
        }

        private static void DisplayTrivia(string[] questions, string[] options, string[] answers)
        {
            bool failed = false;
            int indexNumber = 0;

            DisplayHeader("Trivia Game");

            while (!failed)
            {
                for (int index = 0; index < questions.Length; index++)
                {
                    Console.Clear();
                    indexNumber = index;
                    Console.WriteLine($"Question {index + 1}: {questions[index]}");
                    Console.WriteLine();
                    Console.WriteLine(options[index]);

                    failed = DisplayValidateTriviaAnswer(options, answers, indexNumber, failed);
                    if (failed)
                    {
                        DisplayGameOver();
                    }
                }

                DisplayVictoryPage();
            }
            
        }

        private static void DisplayVictoryPage()
        {
            DisplayHeader("Winner!");
            Console.Clear();
            Console.WriteLine("Congratulations on completing the trivia quiz! Your check for 1 million dollars will be sent shortly!");
            Console.WriteLine();
            Console.WriteLine("Press 'E' to end the application, or any other key to try again!");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.E)
            {
                Environment.Exit(0);
            }
            else
            {
                DisplayTriviaStart();
            }
        }

        private static void DisplayGameOver()
        {
            
            DisplayHeader("Game Over");

            Console.WriteLine("You failed the Trivia game");
            Console.WriteLine();
            Console.WriteLine("Press 'E' to end the application, or any other key to try again!");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.E)
            {
                Environment.Exit(0);
            }
            else
            {
                DisplayTriviaStart();
            }
        }

        private static bool DisplayValidateTriviaAnswer(string[] options, string[] answers, int indexNumber, bool failed)
        {
            
            

            string userResponse = Console.ReadLine().ToUpper();
            if (userResponse == answers[indexNumber])
            {
                Console.WriteLine("Correct!");
                failed = false;
            }
            else
            {
                Console.WriteLine("That is incorrect");
                failed = true;
            }

            DisplayContinuePrompt();
            return failed;
        }

        private static string[] DisplayInitializeTriviaQuestions()
        {
            string[] questions = new string[]
            {
            "Which fictional city is the home of Batman?",
            "Which planet is closest to Earth?",
            "Who is the only basketball player to score 100 points in a single NBA game?",
            "In the classic board game Monopoly, how much does it cost to buy a railroad?",
            "What is the largest country located entirely within Europe?",
            "Who became both a vice president and president of the United States without ever being elected to either office?",
            "What 1985-1992 sitcom earned Emmy awards for its four stars, all women over the age of 50?",
            "What do the letters CPU stand for when referring to the 'brains' of a computer?",
            "Tenochtitlan, founded in 1324, is now known as what city?",
            "In boxing, what is the term for an illegal punch to the back of the head or base of the skull?" 
            };



            return questions;
        }

        private static bool DisplayTriviaInfo()
        {
            Console.Clear();
            bool exiting = false;
            DisplayHeader("Who Wants to be a Millionaire");

            Console.WriteLine("\t\tWelcome to who wants to be a Millionaire!");
            Console.WriteLine();
            Console.WriteLine("In this game, you will be asked 10 trivia questions. These will be asked in order of increased difficulty, and if you get " +
                "them all right - you will win 1 MILLION (theoretical) dollars!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue, or 'Q' to quit the application");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Q)
            {
                exiting = true;
            }
            
           

            DisplayContinuePrompt();
            return exiting;
        }


        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tHello, and welcome to my Capstone Project.");
            Console.WriteLine();
            Console.WriteLine("The purpose of this project is to allow the user to play a short trivia game where if they get a question wrong, they" +
                "lose, so they must answer all correctly to win.");

            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThanks for playing my trivia game!");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }
    }
}
