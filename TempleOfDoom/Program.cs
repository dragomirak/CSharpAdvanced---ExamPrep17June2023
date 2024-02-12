
namespace TempleOfDoom;
public class Program
{
    static void Main()
    {
        Queue<int> tools = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        Stack<int> substances = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));
        List<int> challenges = new List<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        bool isFound = false;

        while (tools.Count > 0 && substances.Count > 0)
        {
            int result = tools.Peek() * substances.Peek();
            int challenge = challenges.FirstOrDefault(x => x == result);
            if (challenge != default)
            {
                challenges.Remove(challenge);
                tools.Dequeue();
                substances.Pop();
            }
            else
            {
                int tool = tools.Dequeue() + 1;
                tools.Enqueue(tool);
                int substance = substances.Pop() - 1;
                if (substance > 0)
                {
                    substances.Push(substance);
                }
            }

            if (challenges.Count == 0)
            {
                isFound = true;
                break;
            }
        }

        if (isFound)
        {
            Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
        }
        else
        {
            Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
        }

        if (tools.Count > 0)
        {
            Console.Write("Tools: ");
            while (tools.Count > 1)
            {
                Console.Write($"{tools.Dequeue()}, ");
            }
            Console.Write($"{tools.Dequeue()}");
            Console.WriteLine();
        }

        if (substances.Count > 0)
        {
            Console.Write("Substances: ");
            while (substances.Count > 1)
            {
                Console.Write($"{substances.Pop()}, ");
            }
            Console.Write($"{substances.Pop()}");
            Console.WriteLine();
        }

        if (challenges.Count > 0)
        {
            Console.Write("Challenges: ");
            for (int i = 0; i < challenges.Count - 1; i++)
            {
                Console.Write($"{challenges[i]}, ");
            }
            Console.Write(challenges.Last());
        }
    }
}
