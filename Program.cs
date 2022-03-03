using System;

namespace MemoryGame
{
    class Program
    {
        // variable to save what difficult player choose
        static string? difficult;
        static int guessChances;

        // get all words from file as array of string

        static string[] allWordsArr = readWordsFromFile();

        //making array for level easy
        static string[] arrForEasyLvl = { "X", "X", "X", "X", "X", "X", "X", "X" };

        //making array for level hard
        static string[] arrForHardLvl = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };

        //making words list to push them random words
        static List<string> wordsArrayLineA = new List<string>();
        static List<string> wordsArrayLineB = new List<string>();

        // variable holding state of game (end or not end xD)
        static bool isEnd = false;

        static bool playAgain = false;
       


        static void Main(string[] args)
        {


            do
            {

                chooseDifficult();

                if (difficult == "easy")
                {
                    drawsRandomWords(4);
                    while (isEnd == false)
                    {
                        showEasyBoard();
                        Console.WriteLine("\n");
                        Console.WriteLine("Choose which number you would like to uncover in line A: (example 2)");
                        var lineA = int.Parse(Console.ReadLine());
                        arrForEasyLvl[lineA - 1] = wordsArrayLineA[lineA - 1];
                        showEasyBoard();
                        Console.WriteLine("\n");
                        Console.WriteLine("Choose which number you would like to uncover in line B: (example 2)");
                        var lineB = int.Parse(Console.ReadLine());
                        arrForEasyLvl[lineB + 3] = wordsArrayLineB[lineB - 1];
                        showEasyBoard();
                        if (arrForEasyLvl[lineA - 1] != arrForEasyLvl[lineB + 3])
                        {
                            guessChances--;
                            if (guessChances == 0)
                            {
                                isEnd = true;
                                Console.WriteLine("The end! You loose! Bye! :)");
                                Console.WriteLine("Do you want to play again ? yes/no");
                                var answer = Console.ReadLine();
                                if (answer == "yes")
                                {
                                    playAgain = true;
                                }
                            }
                            arrForEasyLvl[lineA - 1] = "X";
                            arrForEasyLvl[lineB + 3] = "X";
                        }
                        if (!arrForEasyLvl.Contains("X"))
                        {
                            isEnd = true;
                            Console.Clear();
                            Console.WriteLine("You win! The game is over, you can start game again.");
                            Console.WriteLine("Do you want to play again ? yes/no");
                            var answer = Console.ReadLine();
                            if (answer == "yes")
                            {
                                playAgain = true;
                            }
                        }
                    }
                }
                else
                {
                    drawsRandomWords(8);
                    while (isEnd == false)
                    {
                        showHardBoard();
                        Console.WriteLine("\n");
                        Console.WriteLine("Choose which number you would like to uncover in line A: (example 2)");
                        var lineA = int.Parse(Console.ReadLine());
                        arrForHardLvl[lineA - 1] = wordsArrayLineA[lineA - 1];
                        showHardBoard();
                        Console.WriteLine("\n");
                        Console.WriteLine("Choose which number you would like to uncover in line B: (example 2)");
                        var lineB = int.Parse(Console.ReadLine());
                        arrForHardLvl[lineB + 7] = wordsArrayLineB[lineB - 1];
                        showHardBoard();
                        if (arrForHardLvl[lineA - 1] != arrForHardLvl[lineB + 7])
                        {
                            guessChances--;
                            if (guessChances == 0)
                            {
                                isEnd = true;
                                Console.WriteLine("The end! You loose! Bye! :)");
                                Console.WriteLine("Do you want to play again ? yes/no");
                                var answer = Console.ReadLine();
                                if (answer == "yes")
                                {
                                    playAgain = true;
                                }
                            }
                            arrForHardLvl[lineA - 1] = "X";
                            arrForHardLvl[lineB + 3] = "X";
                        }
                        if (!arrForHardLvl.Contains("X"))
                        {
                            isEnd = true;
                            Console.Clear();
                            Console.WriteLine("You win! The game is over, you can start game again.");
                            Console.WriteLine("Do you want to play again ? yes/no");
                            var answer = Console.ReadLine();
                            if (answer == "yes")
                            {
                                playAgain = true;
                            }
                        }
                    }
                }
            } while (playAgain == true);

            

        }


        // Read words from file as array of string
        static string[] readWordsFromFile()
        {
            return System.IO.File.ReadAllLines("Words.txt");
        }
  
        // choosing level (easy/hard) function
        static void chooseDifficult()
        {
            var isCorrectChoose = false;
            while (isCorrectChoose == false)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("\n");
                Console.WriteLine("Please choose which difficult would you like to play: (easy/hard)");
                Console.WriteLine("\n");
                Console.WriteLine("---------------------------------");
                var userInput = Console.ReadLine();
                if (userInput == "easy")
                {
                    difficult = "easy";
                    guessChances = 10;
                    isCorrectChoose = true;
                }
                else if (userInput == "hard")
                {
                    difficult = "hard";
                    guessChances = 15;
                    isCorrectChoose = true;
                }
                else
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("\n");
                    Console.WriteLine("You have to choose easy or hard!!! Press enter to try again:");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        // making board for level easy
        static void showEasyBoard()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine($"Level: {difficult}");
            Console.WriteLine($"Guess chances: {guessChances}");
            Console.WriteLine("\n\n");
            Console.WriteLine("   1  2  3  4");
            Console.WriteLine("A  {0}  {1}  {2}  {3}", arrForEasyLvl[0], arrForEasyLvl[1], arrForEasyLvl[2], arrForEasyLvl[3]);
            Console.WriteLine("B  {0}  {1}  {2}  {3}", arrForEasyLvl[4], arrForEasyLvl[5], arrForEasyLvl[6], arrForEasyLvl[7]);
            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------");
        }

        //making board for level hard
        static void showHardBoard()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine($"Level: {difficult}");
            Console.WriteLine($"Guess chances: {guessChances}");
            Console.WriteLine("\n\n");
            Console.WriteLine("   1  2  3  4  5  6  7  8");
            Console.WriteLine("A  {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}", arrForHardLvl[0], arrForHardLvl[1], arrForHardLvl[2], arrForHardLvl[3], arrForHardLvl[4], arrForHardLvl[5], arrForHardLvl[6], arrForHardLvl[7]);
            Console.WriteLine("B  {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}", arrForHardLvl[8], arrForHardLvl[9], arrForHardLvl[10], arrForHardLvl[11], arrForHardLvl[12], arrForHardLvl[13], arrForHardLvl[14], arrForHardLvl[15]);
            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------");
        }

        // draws random words from words array
        static void drawsRandomWords(int numberOfWords)
        {
            // creating a new object based on an instance of the class Random (i need this for generation random number for draws words)
            Random rnd = new Random();
            for (int i = 0; i < numberOfWords; i++)
            {
                int randomNumber = rnd.Next(1, allWordsArr.Length - 1);
                wordsArrayLineA.Add(allWordsArr[randomNumber]);
                wordsArrayLineB.Add(allWordsArr[randomNumber]);
            }
        }
    }
}