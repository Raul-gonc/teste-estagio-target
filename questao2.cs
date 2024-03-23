using System;

public class Questao2
{
    public static void Main(string[] args)
    {
        int n = 0;
        Console.WriteLine(n + (IsInFib(n) ? " faz parte" : " nao faz parte") + " da sequencia de Fibonacci.");
        
        n = 6;
        Console.WriteLine(n + (IsInFib(n) ? " faz parte" : " nao faz parte") + " da sequencia de Fibonacci.");
        
        n = 8;
        Console.WriteLine(n + (IsInFib(n) ? " faz parte" : " nao faz parte") + " da sequencia de Fibonacci.");
    }
    
    public static bool IsInFib(int n)
    {
        if (n == 0 || n == 1)
        {
            return true;
        }
        
        int a = 0, b = 1;
        while (b < n)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }
        
        return b == n;
    }
}