using System;
using System.Diagnostics;


public class Questao5
{
    public static void Main(string[] args)
    {
        string teste = "banaana";
        Console.WriteLine("String original: " + teste);
        Console.WriteLine("String invertida(Teste metodo Inverter): " + Inverter(teste));
        Console.WriteLine("String invertida(Teste metodo InverterMelhor): " + InverterMelhor(teste));
        
        
        //Gerar uma String de 100 mil caracteres para testar os metodos
        string input = gerarString(100000);
        Console.WriteLine("teste com string de 100mil caracteres");
        
        //medir e imprimir os tempos para o inverter normal
        Stopwatch tempoinverter = new Stopwatch(); 
        tempoinverter.Start();
        Inverter(input);
        tempoinverter.Stop();
        Console.WriteLine("Tempo inverter: " + tempoinverter.ElapsedMilliseconds + " milissegundos");
        
        //medir e imprimir os tempos para o inverterMelhor
        Stopwatch tempoinverterMelhor = new Stopwatch(); 
        tempoinverterMelhor.Start();
        InverterMelhor(input);
        tempoinverterMelhor.Stop();
        Console.WriteLine("Tempo InverterMelhor: " + tempoinverterMelhor.ElapsedMilliseconds + " milissegundos");
        
    }
    
    //maneira mais basica de fazer utilizando apenas concatenação, normalmente não é um problema, mas em c# é, pois as string aqui são imutaveis então ao usar concatenação estamos recriando a string varias vezes.
    public static string Inverter(string input)
    {
        int tamanho = input.Length;
        string invertida = "";
        for(int i = tamanho; i > 0; i--){
            invertida += input[i - 1];
        }
        return invertida;
    }
    
    //metodo alternativo, ao usarmos um array de char o problema da imutabilidade some, então o tempo de execução cai drasticamente, tambem fiz uma logica simples para só precisar percorrer a metade do caminho ao trabalhar as duas pontas da string ao mesmo tempo.
    public static string InverterMelhor(string input)
    {
        char[] arrayAux = input.ToCharArray(); // Converte a string em um array de caracteres
        int i = 0;
        int j = input.Length - 1;
        
        //vai até o meio da string
        while (i < j)
        {
            //troca o primeiro e o ultimo
           arrayAux[i] = input[j];
           arrayAux[j] = input[i];
            
            //muda os referenciais de primeiro e ultimo
            i++;
            j--;
        }
        
        return new string(arrayAux);
    }
    
    //metodo auxiliar só para gerar uma string maior
    public static string gerarString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // 
        
        char[] randomChars = new char[length];
        
        for (int i = 0; i < length; i++)
        {
            randomChars[i] = chars[random.Next(chars.Length)];
        }
        
        return new string(randomChars);
    }
}