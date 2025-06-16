// Console.WriteLine("Bem-Vindo ao sistema internacional de armazenamento de dado de urso");

// while (true)
// {
//     Console.WriteLine("Quantos ursos você ira cadastrar?");
//     int ursos = int.Parse(Console.ReadLine()!);
//     int[] peso = new int[ursos];
//     string[] sexoUrso = new string[ursos];
//     Console.WriteLine("Por favor digite o peso dos ursos um a um: ");
//     for (int i = 0; i < ursos; i++)
//     {
//         peso[i] = Convert.ToInt32(Console.ReadLine()!);
//         for (int j = 0; j < ursos; j++)
//         {
//             Console.WriteLine("Por favor digite o sexo do Urso");
//             Console.WriteLine("Onde F é igual a Feminino e M é igual a Masculino:");
//             sexoUrso[j] = Console.ReadLine()!;
//         }
//     }
//     Console.WriteLine($"O peso dos ursos são {peso.Length}");
//     Console.WriteLine($"O sexo dos ursos são {sexoUrso.Length}");
//     Console.WriteLine("Encerra");
//     break;
// }

using System.Text.RegularExpressions; //lib da list

Console.Clear();
Console.WriteLine("Bem-Vindo(a) ao sistema internacional de armazenamento de dados de ursos selvagens!\n");

double maiorPeso = 0;
char sexoMaiorPeso = ' ';

string[] categoria = { "ML", "L", "M", "P", "MP" }; // array de categoria de pesos

(int PesoMinimo, int PesoMaximo)[] intervalosPeso = {  
    (1, 50),
    (51, 100),
    (101, 150),
    (151, 200),
    (201, 250)
};
// cria um array com duas condiçoes e recebe em 1 indice, doi valores que sao intervalos tipo 1, 50 é de 1, 2, 3, 4, ... 50 e ele cai no indice 0 que é o msm indice da primeira categoria

List<(double peso, char sexo)> ursos = new(); // funçao nova, cria uma lista (ao que eu entendi é tipo um array) que armazena duas variaveis, peso e sexo e o nome é ursos

while (true)
{
    Console.Write("Por favor, Informe o peso do urso (Kg):");
    if (!double.TryParse(Console.ReadLine(), out double peso)) continue; // função nova, se cair na condição ele quebra o loop e volta pro inicio

    if (peso <= 0)
        break;

    if (peso > 250)
    {
        break;
    }

    char sexo;
    while (true)
    {
        Console.Write("Por favor, Informe o sexo(F/M) do urso: ");
        string teste = Console.ReadLine()!.ToUpper().Trim();
        if (teste == "M" || teste == "F")
        {
            sexo = teste[0];
            break;
        }
        Console.WriteLine("Sexo inválido");
    }

    ursos.Add((peso, sexo));

    if (peso > maiorPeso)
    {
        maiorPeso = peso;
        sexoMaiorPeso = sexo;
    }

    string cat = saberCategoria(peso, intervalosPeso, categoria);
    Console.WriteLine($"\nUrso registrado - Peso: {peso} Kg | Sexo: {sexo} | Categoria: {cat} \n");
}

Console.WriteLine("\nInformações do urso mais pesado:");
Console.WriteLine($"Sexo: {sexoMaiorPeso}");
Console.WriteLine($"Peso: {maiorPeso}Kg");

string saberCategoria(double peso, (int min, int max)[] intervalos, string[] categorias)
{
    for (int i = 0; i < intervalos.Length; i++)
    {
        if (peso >= intervalos[i].min && peso <= intervalos[i].max)
        {
            return categorias[i];
        }
    }
    return "Sem Categoria";
}


// foreach (var urso in ursos)
// {
//     string categoriaUrso = saberCategoria(urso.peso, intervalosPeso, categoria);
//     Console.WriteLine($"Peso: {urso.peso} kg | Sexo: {urso.sexo} | Categoria: {categoriaUrso}");
// }