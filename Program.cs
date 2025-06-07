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

using System.Collections.Generic; //lib da list


Console.WriteLine("Bem-Vindo ao sistema internacional de armazenamento de dado de urso");

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
    Console.WriteLine("peso:");
    if (!double.TryParse(Console.ReadLine(), out double peso)) continue; // função  nova, se cair na condição ele quebra o loop e volta pro inicio

    if (peso <= 0 || peso > 250) // se cair nessas condições ele acaba o codigo e nao roda nada pra baixo
    {
        break;
    }
}
