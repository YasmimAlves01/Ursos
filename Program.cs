double pesoUrso;
string sexoUrso;

Console.WriteLine("Bem-Vindo ao sistema internacional de armazenamento de dado de urso");

while (true)
{

    for (pesoUrso = 0; pesoUrso <= 250; pesoUrso++)
    {
        Console.WriteLine("Por favor digite o peso do urso: ");
        pesoUrso = Convert.ToDouble(Console.ReadLine()!);

        Console.WriteLine("Por favor digite o sexo do Urso");
        Console.WriteLine("Onde F é igual a Feminino e M é igual a Masculino:");
        sexoUrso = Console.ReadLine()!.ToUpper();
    }
    Console.WriteLine("Encerra");
    break;
}