
using PROJETO.Classes;

Console.Clear();
Console.WriteLine(@$"
============================================================
|           Bem vindo ao sistema de cadastro de            |
|              Pessoas Físicas e Jurídicas                 |
============================================================
");

BarraCarregamento("Carregando",300);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
============================================================
|               Escolha uma das opções abaixo              |
|----------------------------------------------------------|
|               1 - Pessoa Física                          |
|               2 - Pessoa Jurídica                        |
|                                                          |
|               0 - Sair                                   |
============================================================
");

opcao = Console.ReadLine();

switch (opcao)
{
    case "1":
        PessoaFisica metodoPf = new PessoaFisica();

        string? opcaoPf;
        do
        {

            Console.Clear();
            Console.WriteLine(@$"
============================================================
|               Escolha uma das opções abaixo              |
|----------------------------------------------------------|
|               1 - Cadastrar Pessoa Física                |
|               2 - Mostrar Pessoas Físicas                |
|                                                          |
|               0 - Voltar ao menu anterior                |
============================================================
");
            opcaoPf = Console.ReadLine();

            switch (opcaoPf)
            {
                case "1":
                    Console.Clear();
                    PessoaFisica novaPf = new PessoaFisica();
                    Endereco novoEnd = new Endereco();

                    Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                    novaPf.nome = Console.ReadLine();

                    bool dataValida;
                    do
                    {
                        Console.WriteLine($"Digite a data de nascimento Ex.: DD/MM/AAAA");
                        string dataNasc = Console.ReadLine();

                        dataValida = metodoPf.ValidarDataNascimento(dataNasc);

                        if (dataValida)
                        {
                            novaPf.dataNascimento = dataNasc;
                        }
                        else{
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Data digitada inválida, por favor digite uma data válida");
                            Console.ResetColor();
                        }  
                    } while (dataValida == false);
                    
                    Console.WriteLine($"Digite o número do CPF");
                    novaPf.cpf = Console.ReadLine();

                    Console.WriteLine($"Digite o rendimento mensal (apenas números");
                    novaPf.rendimento = float.Parse(Console.ReadLine());

                    Console.WriteLine($"Digite o logradouro");
                    novoEnd.Logradouro = Console.ReadLine();

                    Console.WriteLine($"Digite o número:");
                    novoEnd.numero = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                    novoEnd.complemento = Console.ReadLine();
                    
                    Console.WriteLine($"Este endereço é comercial? S ou N");
                    string endCom = Console.ReadLine().ToUpper();
                    if(endCom == "S")
                    {
                        novoEnd.endComercial = true;
                    }
                    else{
                        novoEnd.endComercial = false;
                    }
                    novaPf.endereco = novoEnd;
                    metodoPf.Inserir(novaPf);
                    break;
                case "2":
                         List<PessoaFisica> listaPf = metodoPf.Ler();

                        foreach(PessoaFisica cadaItem in listaPf)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                                Nome: {cadaItem.nome}
                                CNPJ: {cadaItem.cpf}
                                Razao Social: {cadaItem.dataNascimento}
                                Rendimento: {cadaItem.rendimento}
                                Imposto: {metodoPf.PagarImposto(cadaItem.rendimento).ToString("C")}
                                Logradouro: {cadaItem.endereco.logradouro}
                                Número: {cadaItem.endereco.numero}
                                Complemento: {cadaItem.endereco.complemento}
                                Endereço Comercial?:{((cadaItem.endereco.endComercial)?"Sim":"Não")}
                            ");
                            
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }
                        break;

                case "0":
                    break;
                    
                default:
                    Console.Clear();
                    Console.WriteLine($"Opção Inválida, por favor digite uma outra opção.");
                    Thread.Sleep(3000);
                    break;
            }
            
        } while (opcaoPf != "0");
        
        break;

    case "2":
    
        PessoaJuridica metodoPj = new PessoaJuridica();

        string? opcaoPj;

        do
        {

            Console.Clear();
             Console.WriteLine(@$"
============================================================
|               Escolha uma das opções abaixo              |
|----------------------------------------------------------|
|               1 - Cadastrar Pessoa Jurídica              |
|               2 - Mostrar Pessoas Jurídica               |
|                                                          |
|               0 - Voltar ao menu anterior                |
============================================================
");           
        opcaoPj = Console.ReadLine();

        switch (opcaoPj)
        {
            case "1":
                Console.Clear();
                PessoaJuridica novaPj = new PessoaJuridica();
                Endereco novoEndPj = new Endereco();
                Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar");
                novaPj.nome = Console.ReadLine();
                
                Console.WriteLine($"Digite o número do CNPJ");
                novaPj.cnpj = Console.ReadLine();

                Console.WriteLine($"Digite a Razão Social");
                novaPj.nome = Console.ReadLine();            

                Console.WriteLine($"Digite o vaor do rendimento");
                novaPj.rendimento = float.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o logradouro");
                novoEndPj.Logradouro = Console.ReadLine();

                Console.WriteLine($"Digite o numero");
                novoEndPj.numero = int.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o complemento (aperte ENTER para vazio");
                novoEndPj.complemento = Console.ReadLine(); 

               Console.WriteLine($"Este endereço é comercial? S ou N");              
                    string endComPj = Console.ReadLine().ToUpper();
                    if(endComPj == "S")
                    {
                        novoEndPj.endComercial = true;
                    }
                    else{
                        novoEndPj.endComercial = false;
                    }
                
                novaPj.endereco = novoEndPj;
                metodoPj.Inserir(novaPj);
                break;
            
            case "2":
            
                        List<PessoaJuridica> listaPj = metodoPj.Ler();

                        foreach(PessoaJuridica cadaItem in listaPj)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                                Nome: {cadaItem.nome}
                                CNPJ: {cadaItem.cnpj}
                                Razao Social: {cadaItem.razaoSocial}
                                Rendimento: {cadaItem.rendimento}
                                Imposto: {metodoPj.PagarImposto(cadaItem.rendimento).ToString("C")}
                                Logradouro: {cadaItem.endereco.logradouro}
                                Número: {cadaItem.endereco.numero}
                                Complemento: {cadaItem.endereco.complemento}
                                Endereço Comercial?:{((cadaItem.endereco.endComercial)?"Sim":"Não")}
                            ");
                            
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }
                        break;
                case "0":
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine($"Opção Inválida, por favor digite uma outra opção.");
                    Thread.Sleep(3000);
                    break;
            }                

        } while (opcaoPj !="0");

        break;

}
} while (opcao != "0");


static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.Write($"{texto}");

    for(var contador = 0; contador < 10; contador ++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();  
}







