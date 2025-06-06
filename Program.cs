Console.WriteLine("Bem-Vindo ao sistema internacional de armazenamento de dado de urso");

while (true)
{
    Console.WriteLine("Quantos ursos você ira cadastrar?");
    int ursos = int.Parse(Console.ReadLine()!);
    int[] peso = new int[ursos];
    string[] sexoUrso = new string[ursos];
    Console.WriteLine("Por favor digite o peso dos ursos um a um: ");
    for (int i = 0; i < ursos; i++)
    {
        peso[i] = Convert.ToInt32(Console.ReadLine()!);


        
        for (int j = 0; j < ursos; j++)
        {
            Console.WriteLine("Por favor digite o sexo do Urso");
            Console.WriteLine("Onde F é igual a Feminino e M é igual a Masculino:");
            sexoUrso[j] = Console.ReadLine()!;
        }
        
    }
    Console.WriteLine($"O peso dos ursos são {peso.Length}");
    Console.WriteLine($"O sexo dos ursos são {sexoUrso.Length}");
    Console.WriteLine("Encerra");
    break;
}