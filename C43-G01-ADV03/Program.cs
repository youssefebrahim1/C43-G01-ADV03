using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        #region Given a Queue, implement a function to reverse the elements of a queue using a stack.

        Queue<int> NumberQueue = new Queue<int>();
        NumberQueue.AddToEnd(100);
        NumberQueue.AddToEnd(200);
        NumberQueue.AddToEnd(300);
        NumberQueue.AddToEnd(400);
        NumberQueue.AddToEnd(500);

        Console.WriteLine("The Queue in original order:");
        DisplayQueue(NumberQueue);
        ReverseQueue(NumberQueue);
            Console.WriteLine("The Queue in Reversed order:");
        DisplayQueue(NumberQueue);
        #endregion

        #region Given a Stack, implement a function to check if a string of parentheses is balanced using a stack.

        string input1 = "[()]{}";
        string input2 = "[(])";
        string input3 = "({[]})";
        string input4 = "({[}])";
        Console.WriteLine($"Is \"{input1}\" balanced? {IsBalanced(input1)}");
        Console.WriteLine($"Is \"{input2}\" balanced? {IsBalanced(input2)}");
        Console.WriteLine($"Is \"{input3}\" balanced? {IsBalanced(input3)}");
        Console.WriteLine($"Is \"{input4}\" balanced? {IsBalanced(input4)}");
        #endregion
    }

    #region functions for q1 and q2
    static void ReverseQueue(Queue<int> queue)
    {
        Stack<int> tempStack = new Stack<int>();
        while (queue.Count > 0)
        {
            tempStack.Push(queue.RemoveFromFront());
        }
        while (tempStack.Count > 0)
        {
            queue.AddToEnd(tempStack.Pop());
        }
    }
    static void DisplayQueue(Queue<int> queue)//displaying
    {
        foreach (var item in queue)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    //q2
    static bool IsBalanced(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in input)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char top = stack.Pop();

            if (!IsMatchingPair(top, ch))
             {
                    return false;
              }
            }
        }
        return stack.Count == 0;
    }
    static bool IsMatchingPair(char opening, char closing)
    {
        return (opening == '(' && closing == ')') ||
               (opening == '{' && closing == '}') ||
               (opening == '[' && closing == ']');
    }
}
//q1
public static class QueueExtensions
{
    public static void AddToEnd(this Queue<int> queue, int item)
    {
        queue.Enqueue(item); 
    }

    public static int RemoveFromFront(this Queue<int> queue)
    {
        return queue.Dequeue(); 
    }
    #endregion

}