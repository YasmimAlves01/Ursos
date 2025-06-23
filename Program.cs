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

    string cat = saberCategoria(peso, intervalosPeso, categoria); //usando a função de saber categoria para mostrar a categoria do urso inserido
    Console.WriteLine($"\nUrso registrado - Peso: {peso} Kg | Sexo: {sexo} | Categoria: {cat} \n"); //mostrando as informações do urso registrado
}

Console.Clear();

Console.WriteLine($"\nTotal de Ursos Registrados: {ursos.Count}\n");//conta o total de indices dentro da lista e mostra a quantidade de ursos registrados

Console.WriteLine("Informações do urso mais pesado:");
if (sexoMaiorPeso == ' '){
   Console.WriteLine("Sexo: Não possui registro | Peso: Não possui registro\n");//mostra a mensagem caso nenhum urso tenha sido registrado
}
else{
    Console.Write($"Sexo: {sexoMaiorPeso} | Peso: {maiorPeso}Kg\n");//mostra o sexo e o peso do urso mais pesado registrado
}

Console.WriteLine("Média de peso por sexo:");

if (contM > 0){ //se tiver mais de um urso macho registrado ele faz a média
    Console.Write($"Machos: {(somaM / contM):F2} kg | "); //pega a soma de todos os pesos e divide pela quantidade de ursos
}else{
    Console.Write("Machos: Não possui registros  | "); // se nao tiver urso macho, ele mostra a mensagem que nao possui registro
}

if (contF > 0){ //se tiver mais de um urso femea registrado ele faz a média
    Console.WriteLine($"Fêmeas: {(somaF / contF):F2} kg\n");//pega a soma de todos os pesos e divide pela quantidade de ursos
}else{
    Console.WriteLine("Fêmeas: Não possui registro\n"); // e nao tiver urso femea, ele mostra a mensagem que nao possui registro
}

int[] machos = new int[categoria.Length];
int[] femeas = new int[categoria.Length];
int[] total = new int[categoria.Length];

foreach (var urso in ursos)
{
    int indice = obterIndiceCategoria(urso.peso, intervalosPeso);
    if (indice >= 0){
        total[indice]++;
        if (urso.sexo == 'M'){
            machos[indice]++;
        }
        else{
            femeas[indice]++;
        }
            
    }
}

gerarTabelaDistribuicao(machos, femeas, total, categoria);
histograma("Ursos Machos", machos, categoria);
histograma("Ursos Fêmeas", femeas, categoria);
histograma("Ursos (todos)", total, categoria);

Console.WriteLine("\nAperte em qualquer tecla para encerrar o programa!");
Console.ReadKey();

//função que mostra uma tabela com a distribuição de ursos por categoria de peso
void gerarTabelaDistribuicao(int[] machos, int[] femeas, int[] total, string[] categorias)
{
    //soma a quantidade total de ursos, machos e fêmeas
    int totalUrsos = total.Sum();
    int totalMachos = machos.Sum();
    int totalFemeas = femeas.Sum();

    //monta o a primeira linha de cabeçalho e a linha final da tabela com os totais e as porcentagens de 100%
    string cabecalho = "| " + "Categoria".PadRight(13) + "Ursos".PadRight(10) + "Ursos(%)".PadRight(12) + "Machos".PadRight(10) + "Machos(%)".PadRight(12)  + "Fêmeas".PadRight(10) + "Fêmeas(%)".PadLeft(10) + " |";
    string totalLinha = "| " + "Total".PadRight(9) + " " + totalUrsos.ToString().PadLeft(6) + " " + "100%".PadLeft(12) + " " + totalMachos.ToString().PadLeft(9) + " " + "100%".PadLeft(12) + " " + totalFemeas.ToString().PadLeft(8) + " " + "100%".PadLeft(12) + "    |";
    
    Console.WriteLine("+------------------- Tabela de Distribuição de Frequências ---------------------+");
    Console.WriteLine(cabecalho);

    for (int i = 0; i < categorias.Length; i++)
    {
       double percTotal, percMachos, percFemeas;

        //calcula as procentagens só se tiver valores pra evitar divisão por zero
        if (totalUrsos > 0)
        {
            percTotal = (double)total[i] / totalUrsos * 100;
        }
        else
        {
            percTotal = 0;
        }

        if (totalMachos > 0){
            percMachos = (double)machos[i] / totalMachos * 100;
        }else{
            percMachos = 0;
        }

        if (totalFemeas > 0){
            percFemeas = (double)femeas[i] / totalFemeas * 100;
        }else{
            percFemeas = 0;
        }

        //monta cada linha de registro das informaçõeos na tabela
        string linha = "| " + categorias[i].PadRight(11) + " " + total[i].ToString().PadLeft(4) + " " + $"{percTotal:F1}%".PadLeft(12) + " " + machos[i].ToString().PadLeft(9) + " " + $"{percMachos:F1}%".PadLeft(12) + " " + femeas[i].ToString().PadLeft(8) + " " + $"{percFemeas:F1}%".PadLeft(12) + "    |";
        Console.WriteLine(linha);
    }

    Console.WriteLine(totalLinha);
    Console.WriteLine("+-------------------------------------------------------------------------------+");
}

//função que recebe um peso e retorna o índice que representa em quual intervalo peso pertence
int obterIndiceCategoria(double peso, (int min, int max)[] intervalos)
{
    //percorre o array de intervalo de peso e retorna o indice igual ao intervalo onde o peso se encaixa
    for (int i = 0; i < intervalos.Length; i++)
        if (peso >= intervalos[i].min && peso <= intervalos[i].max)
            return i;
    return -1;
}

// função que acha a categoria do urso com base no peso informado e o intervalo que ela pertence
string saberCategoria(double peso, (int min, int max)[] intervalos, string[] categorias)
{
    //percorre a array e retorna a categoria correspondente ao peso
    for (int i = 0; i < intervalos.Length; i++)
    {
        if (peso >= intervalos[i].min && peso <= intervalos[i].max)
        {
            return categorias[i];
        }
    }
    return "Sem Categoria";
}

//função que mostra um histograma com barras representando a quantidade de ursos por categoria
void histograma(string titulo, int[] dados, string[] categorias)
{
    Console.WriteLine($"\n--- {titulo} ---");
    Console.WriteLine("    +...10...20...30...40...50...60...70...80...90..100");
    for (int i = 0; i < categorias.Length; i++)
        //monta a linha da categoria com uma barra de '*' proporcional ao valor
        Console.WriteLine($"{categorias[i],-4}|{new string('*', dados[i])}");
}
