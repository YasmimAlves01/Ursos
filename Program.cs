Console.Clear();
Console.WriteLine("Bem-Vindo(a) ao sistema internacional de armazenamento de dados de ursos selvagens!\n");

int contM = 0, contF = 0; // variaveis de contagem de ursos dos dois sexos
double maiorPeso = 0, somaM = 0, somaF = 0;  // variaveis de contagem do urso com maior peso, e a quantidade dos ursos dos dois sexos
char sexoMaiorPeso = ' '; //char do maior peso inicia como vazio e é substituido com o char do sexo do urso com maior peso

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
{ // = a true obriga a cair nno while
    Console.Write("Por favor, Informe o peso do urso (Kg): ");
    if (!double.TryParse(Console.ReadLine(), out double peso)) continue; // função nova, se cair na condição ele quebra o loop e volta pro inicio

    if (peso <= 0 || peso > 250) // se o urso inserido tiver peso igual a 0, maior que 250ou peso negativo, cai no break e nao executa o while
        break;

    char sexo; //cria a variavel sexo como um char
    while (true)
    { //caso o codigo nao caia no break ele obriga a cair no while
        Console.Write("Por favor, Informe o sexo(F/M) do urso: ");
        string sexoDigitado = Console.ReadLine()!.ToUpper().Trim(); // cria uma varivael do tipo string
        if (sexoDigitado == "M" || sexoDigitado == "F"){ //se sexo for igual a m ou f ele pega o indice 0 da string, que a primeira letra e adiciona a varivel do tipo char
            sexo = sexoDigitado[0];
            break; //cai no brak e volta pro while de cima
        }
        Console.WriteLine("Sexo inválido");//caso o sexo nao seja nenhuma das alternativas, ele apararece a mensagem de sexo invalido e pede pro usuario digitar dnv
    }

    ursos.Add((peso, sexo)); //caso passe pelo dois whiles, adiciona na lista com peso e sexo

    //ele pega o valor do peso digitado, compara para ver o valor atual do maior peso, se for maior ele substitui o peso e o sexo do urso
    if (peso > maiorPeso){
        maiorPeso = peso;
        sexoMaiorPeso = sexo;
    }

    //pega os ursos de sexo = M e calcula que a soma de pesos masculino é igual ao valor da somma de pesos masculinos atual + o peso digitado e acrescenta urso do sexo M
    if (sexo == 'M'){
        somaM += peso;
        contM++;
        
    //se nao for do sexo = M, calcula que a soma de pesos feminino é igual ao valor da soma de pesos feminino atual + o peso digitado e acrescenta urso do sexo F    
    }else{
        somaF += peso;
        contF++;
    }

    string cat = saberCategoria(peso, intervalosPeso, categoria);
    Console.WriteLine($"\nUrso registrado - Peso: {peso} Kg | Sexo: {sexo} | Categoria: {cat} \n");
}

Console.Clear();

Console.WriteLine($"\nTotal de Ursos Registrados: {ursos.Count}\n");

Console.WriteLine("Informações do urso mais pesado:");
Console.Write($"Sexo: {sexoMaiorPeso} | ");
Console.Write($"Peso: {maiorPeso}Kg\n");

Console.WriteLine("\nMédia de peso por sexo:");

if (contM > 0){
    Console.Write($"Machos: {(somaM / contM):F2} kg | ");
}else{
    Console.Write("Machos: Não possui registros  | ");
}

if (contF > 0){
    Console.WriteLine($"Fêmeas: {(somaF / contF):F2} kg\n");
}else{
    Console.Write("Fêmeas: Não possui registro\n");
}

int[] machos = new int[categoria.Length];
int[] femeas = new int[categoria.Length];
int[] total = new int[categoria.Length];

foreach (var urso in ursos)
{
    int indice = obterIndiceCategoria(urso.peso, intervalosPeso);
    if (indice >= 0)
    {
        total[indice]++;
        if (urso.sexo == 'M')
            machos[indice]++;
        else
            femeas[indice]++;
    }
}

histograma("Ursos Machos", machos, categoria);
histograma("Ursos Fêmeas", femeas, categoria);
histograma("Ursos (todos)", total, categoria);

Console.WriteLine("Aperte em qualquer tecla para encerrar o programa!");
Console.ReadKey();

int obterIndiceCategoria(double peso, (int min, int max)[] intervalos)
{
    for (int i = 0; i < intervalos.Length; i++)
        if (peso >= intervalos[i].min && peso <= intervalos[i].max)
            return i;
    return -1;
}

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

void histograma(string titulo, int[] dados, string[] categorias)
{
    Console.WriteLine($"\n--- {titulo} ---");
    Console.WriteLine("    +...10...20...30...40...50...60...70...80...90..100");
    for (int i = 0; i < categorias.Length; i++)
        Console.WriteLine($"{categorias[i],-4}|{new string('*', dados[i])}");
}
