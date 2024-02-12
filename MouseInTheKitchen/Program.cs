namespace MouseInTheKitchen;
public class Program
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        char[,] matrix = new char[dimensions[0], dimensions[1]];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            char[] input = Console.ReadLine().ToCharArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = input[j];
            }
        }

        int currentRow = 0;
        int currentCol = 0;
        int cheeseCount = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'M')
                {
                    currentRow = i;
                    currentCol = j;
                }
                if (matrix[i, j] == 'C')
                {
                    cheeseCount++;
                }
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "danger")
        {
            if (command == "up")
            {
                if (currentRow == 0)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    PrintMatrix(matrix);
                    return;
                }
                else
                {
                    if (matrix[currentRow - 1, currentCol] == 'C')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow--;
                        matrix[currentRow, currentCol] = 'M';
                        cheeseCount--;
                        if (cheeseCount == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[currentRow - 1, currentCol] == 'T')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow--;
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("Mouse is trapped!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else if (matrix[currentRow - 1, currentCol] == '@')
                    {
                        continue;
                    }
                    else if (matrix[currentRow - 1, currentCol] == '*')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow--;
                        matrix[currentRow, currentCol] = 'M';
                        continue;
                    }
                }
            }
            else if (command == "down")
            {
                if (currentRow == matrix.GetLength(0) - 1)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    PrintMatrix(matrix);
                    return;
                }
                else
                {
                    if (matrix[currentRow + 1, currentCol] == 'C')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow++;
                        matrix[currentRow, currentCol] = 'M';
                        cheeseCount--;
                        if (cheeseCount == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[currentRow + 1, currentCol] == 'T')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow++;
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("Mouse is trapped!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else if (matrix[currentRow + 1, currentCol] == '@')
                    {
                        continue;
                    }
                    else if (matrix[currentRow + 1, currentCol] == '*')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow++;
                        matrix[currentRow, currentCol] = 'M';
                        continue;
                    }
                }
            }
            else if (command == "right")
            {
                if (currentCol == matrix.GetLength(1) - 1)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    PrintMatrix(matrix);
                    return;
                }
                else
                {
                    if (matrix[currentRow, currentCol + 1] == 'C')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol++;
                        matrix[currentRow, currentCol] = 'M';
                        cheeseCount--;
                        if (cheeseCount == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[currentRow, currentCol + 1] == 'T')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol++;
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("Mouse is trapped!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else if (matrix[currentRow, currentCol + 1] == '@')
                    {
                        continue;
                    }
                    else if (matrix[currentRow, currentCol + 1] == '*')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol++;
                        matrix[currentRow, currentCol] = 'M';
                        continue;
                    }
                }
            }
            else if (command == "left")
            {
                if (currentCol == 0)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    PrintMatrix(matrix);
                    return;
                }
                else
                {
                    if (matrix[currentRow, currentCol - 1] == 'C')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol--;
                        matrix[currentRow, currentCol] = 'M';
                        cheeseCount--;
                        if (cheeseCount == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[currentRow, currentCol - 1] == 'T')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol--;
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("Mouse is trapped!");
                        PrintMatrix(matrix);
                        return;
                    }
                    else if (matrix[currentRow, currentCol - 1] == '@')
                    {
                        continue;
                    }
                    else if (matrix[currentRow, currentCol - 1] == '*')
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol--;
                        matrix[currentRow, currentCol] = 'M';
                        continue;
                    }
                }
            }
        }

        Console.WriteLine("Mouse will come back later!");
        PrintMatrix(matrix);

    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}