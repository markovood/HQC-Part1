namespace MinesGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public static class MinesEntry
    {
        private const int MAX_MOVES = 35;
        private static string command = string.Empty;
        private static char[,] playingField = CreatePlayingField();
        private static char[,] bombsField = SpreadBombs();
        private static int pointCounter = 0;
        private static bool boom = false;
        private static List<Score> champions = new List<Score>(6);
        private static int row = 0;
        private static int column = 0;
        private static bool allBombsRevealed = false;

        public static void Main()
        {
            InitializeDefaultConsoleWindow();
            PrintWelcomeMessage();

            PrintSideMenu();
            PrintField(playingField);

            do
            {
                ReadCommand();
                if (IsTurnCommand(command))
                {
                    command = "turn";
                }

                switch (command)
                {
                    case "top":
                        ExecuteTopCommand();
                        break;
                    case "restart":
                        ExecuteRestartCommand();
                        continue;
                    case "exit":
                        ExecuteExitCommand();
                        break;
                    case "turn":
                        ExecuteTurnCommand();
                        break;
                    default:
                        Console.WriteLine("Error! Invalid command!");
                        break;
                }

                if (boom)
                {
                    ExecuteBoom();
                }

                if (allBombsRevealed)
                {
                    ExecuteAllBombsRevealed();
                }
            }
            while (command != "exit");

            PrintGoodbyeMessage();
        }

        private static void InitializeDefaultConsoleWindow()
        {
            Console.Title = "Mines";

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.SetWindowSize(100, 25);
            Console.SetBufferSize(100, 25);
        }

        private static void PrintWelcomeMessage()
        {
            string[] welcomeMsgs = "Let's play \"Mines\"!.Try to find all cells without mines!.Good Luck!.Ready??? (press any key)"
                .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < welcomeMsgs.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3, 10);
                for (int j = 0; j < welcomeMsgs[i].Length; j++)
                {
                    Thread.Sleep(100);
                    Console.Write(welcomeMsgs[i][j]);
                }

                Thread.Sleep(1000);
                if (i != welcomeMsgs.Length - 1)
                {
                    Console.Clear();
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void PrintSideMenu()
        {
            // split console window with a vertical line
            int maxWindowRows = Console.WindowHeight;
            for (int row = 0; row < maxWindowRows; row++)
            {
                Console.SetCursorPosition(55, row);
                Console.WriteLine("|");
            }

            Console.SetCursorPosition(75, 0);
            Console.Write("Menu".ToUpper());

            Console.SetCursorPosition(65, 3);
            Console.WriteLine("Commands: ");
            Console.SetCursorPosition(65, 4);
            Console.WriteLine("top - shows rating chart");
            Console.SetCursorPosition(65, 5);
            Console.WriteLine("restart - starts new game");
            Console.SetCursorPosition(65, 6);
            Console.WriteLine("exit - closes the game");
        }

        private static void PrintField(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.SetCursorPosition(10, 1);
            Console.Write("    0 1 2 3 4 5 6 7 8 9");
            Console.SetCursorPosition(10, 2);
            Console.Write("   ---------------------");
            Console.SetCursorPosition(10, 3);
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", field[row, col]));
                }

                Console.Write("|");
                Console.SetCursorPosition(10, row + 4);
            }

            Console.Write("   ---------------------\n\n");
        }

        private static void ReadCommand()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(" Enter command or row and column separated by a space: ");
            ClearLine();
            Console.SetCursorPosition(20, 11);
            command = Console.ReadLine().Trim();
        }

        private static bool IsTurnCommand(string command)
        {
            if (command.Length >= 3 && command[1] == ' ')
            {
                if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                    row <= playingField.GetLength(0) &&
                    column <= playingField.GetLength(1))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private static void ExecuteTopCommand()
        {
            ClearLine();
            PrintRating(champions);
        }

        private static void ExecuteRestartCommand()
        {
            Console.Clear();
            playingField = CreatePlayingField();
            bombsField = SpreadBombs();
            PrintSideMenu();
            PrintField(playingField);
            boom = false;
        }

        private static void ExecuteExitCommand()
        {
            Console.SetCursorPosition(20, 11);
            Console.Write("Bye, bye, bye!");
            Thread.Sleep(1000);
        }

        private static void ExecuteTurnCommand()
        {
            if (bombsField[row, column] != '*')
            {
                PlayTurn(playingField, bombsField, row, column);
                pointCounter++;

                if (MAX_MOVES == pointCounter)
                {
                    allBombsRevealed = true;
                }
                else
                {
                    Console.Clear();
                    PrintSideMenu();
                    PrintField(playingField);
                }
            }
            else
            {
                boom = true;
            }
        }

        private static void ExecuteBoom()
        {
            PrintField(bombsField);
            Console.WriteLine(" Booooom! You died with {0} points. Enter nickname:     ", pointCounter);
            ClearLine();
            Console.SetCursorPosition(20, 11);
            string nickname = Console.ReadLine();
            Score currentScore = new Score(nickname, pointCounter);

            AddToTop5(currentScore);

            champions = champions.OrderByDescending(r => r.Points).ThenByDescending(r => r.Name).ToList();
            PrintRating(champions);

            playingField = CreatePlayingField();
            bombsField = SpreadBombs();
            pointCounter = 0;
            boom = false;
        }

        private static void ExecuteAllBombsRevealed()
        {
            Console.SetCursorPosition(0, 10);
            string clearRestOfLine = new string(' ', 18);
            Console.Write(" BRAVOOOS! You've revealed all bombs.{0}", clearRestOfLine);
            PrintField(bombsField);

            Console.SetCursorPosition(0, 11);
            ClearLine();
            Console.SetCursorPosition(0, 11);
            Console.Write(" Enter your name, dude: ");
            string name = Console.ReadLine();

            Score points = new Score(name, pointCounter);
            champions.Add(points);

            PrintRating(champions);

            playingField = CreatePlayingField();
            bombsField = SpreadBombs();
            pointCounter = 0;
            allBombsRevealed = false;
        }

        private static void PrintGoodbyeMessage()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 3, 10);
            Console.Write("Made in Bulgaria");
            string laugh = " - Uauahahahahaha!";
            for (int i = 0; i < laugh.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(laugh[i]);
            }

            Thread.Sleep(1500);
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, 10);
            Console.WriteLine("See you!");
            Thread.Sleep(1000);
        }

        private static void AddToTop5(Score currentScore)
        {
            if (champions.Count < 5)
            {
                champions.Add(currentScore);
            }
            else
            {
                for (int i = 0; i < champions.Count; i++)
                {
                    if (champions[i].Points < currentScore.Points)
                    {
                        champions.Insert(i, currentScore);
                        champions.RemoveAt(champions.Count - 1);
                        break;
                    }
                }
            }
        }

        private static void ClearLine()
        {
            Console.Write(new string(' ', 54));
        }

        private static void PrintRating(List<Score> points)
        {
            Console.WriteLine("\n Points:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    ClearLine();
                    Console.SetCursorPosition(0, i + 14);
                    Console.WriteLine(" {0}. {1} --> {2} points", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty chart!");
            }
        }

        private static void PlayTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char bombsCount = CountBombsArroundPosition(bombs, row, column);
            bombs[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static char[,] CreatePlayingField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] playingField = new char[fieldRows, fieldColumns];

            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    playingField[i, j] = '?';
                }
            }

            return playingField;
        }

        private static char[,] SpreadBombs()
        {
            Random randomGenerator = new Random();

            int rows = 5;
            int columns = 10;
            char[,] playingField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> bombsCells = new List<int>();
            while (bombsCells.Count < 15)
            {
                int randomCellNumber = randomGenerator.Next(50);
                if (!bombsCells.Contains(randomCellNumber))
                {
                    bombsCells.Add(randomCellNumber);
                }
            }

            foreach (int bombCell in bombsCells)
            {
                int row = bombCell / columns;
                int col = bombCell % columns;
                if (col == 0 && bombCell != 0)
                {
                    row--;
                    col = columns;
                }
                else
                {
                    col++;
                }

                playingField[row, col - 1] = '*';
            }

            return playingField;
        }

        private static char CountBombsArroundPosition(char[,] field, int row, int column)
        {
            // Every if group was extracted to a separate method to reduce complexity...
            int count = 0;

            count += CountAboveCurrentPosition(field, row, column);
            count += CountBelowCurrentPosition(field, row, column);
            count += CountOnTheLeftOfCurrentPosition(field, row, column);
            count += CountOnTheRightOfCurrentPosition(field, row, column);
            count += CountUpperLeftHandCorner(field, row, column);
            count += CountUpperRightHandCorner(field, row, column);
            count += CountBottomLeftHandCorner(field, row, column);
            count += CountBottomRightHandCorner(field, row, column);

            return char.Parse(count.ToString());
        }

        private static int CountBottomRightHandCorner(char[,] field, int row, int column)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (field[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountBottomLeftHandCorner(char[,] field, int row, int column)
        {
            int count = 0;
            int rows = field.GetLength(0);

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (field[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountUpperRightHandCorner(char[,] field, int row, int column)
        {
            int count = 0;
            int columns = field.GetLength(0);

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (field[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountUpperLeftHandCorner(char[,] field, int row, int column)
        {
            int count = 0;

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (field[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountOnTheRightOfCurrentPosition(char[,] field, int row, int column)
        {
            int count = 0;
            int columns = field.GetLength(1);

            if (column + 1 < columns)
            {
                if (field[row, column + 1] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountOnTheLeftOfCurrentPosition(char[,] field, int row, int column)
        {
            int count = 0;

            if (column - 1 >= 0)
            {
                if (field[row, column - 1] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountBelowCurrentPosition(char[,] field, int row, int column)
        {
            int count = 0;
            int rows = field.GetLength(0);

            if (row + 1 < rows)
            {
                if (field[row + 1, column] == '*')
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountAboveCurrentPosition(char[,] field, int row, int column)
        {
            int count = 0;

            if (row - 1 >= 0)
            {
                if (field[row - 1, column] == '*')
                {
                    count++;
                }
            }

            return count;
        }
    }
}