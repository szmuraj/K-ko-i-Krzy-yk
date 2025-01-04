using System;

class Program
{
    static char[,] board = new char[3, 3]; // Plansza 3x3
    static char currentPlayer = 'X'; // Gracz X zaczyna

    static void Main()
    {
        InitializeBoard();
        PrintBoard();

        while (true)
        {
            Console.WriteLine($"Tura gracza {currentPlayer}: Podaj współrzędne (wiersz, kolumna) - oddziel spacją:");

            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2 ||
                !int.TryParse(coordinates[0], out int row) || !int.TryParse(coordinates[1], out int col) ||
                row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
            {
                Console.WriteLine("Niepoprawny ruch! Spróbuj ponownie.");
                continue;
            }

            board[row, col] = currentPlayer;
            PrintBoard();

            if (CheckWin())
            {
                Console.WriteLine($"Gracz {currentPlayer} wygrał!");
                break;
            }

            if (CheckDraw())
            {
                Console.WriteLine("Remis!");
                break;
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' '; // Pusty znak dla każdej komórki
            }
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i);
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {board[i, j]}");
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer || board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer) return true;
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer || board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer) return true;

        return false;
    }

    static bool CheckDraw()
    {
        foreach (var cell in board) { if (cell == ' ') return false; }
        return true;
    }
}