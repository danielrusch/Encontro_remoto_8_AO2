
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
/*
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
                    // listaPf.Add(novaPf);
*/
                    using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                    {
                        sw.WriteLine(novaPf.nome);   
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                    Console.ResetColor();

                    break;
                case "2":
                    Console.Clear();
/*
                    if (listaPf.Count > 0)
                    {
                        foreach (PessoaFisica cadaPessoa in listaPf)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                            Nome: {cadaPessoa.nome}
                            Data de Nascimento: {cadaPessoa.dataNascimento}
                            CPF: {cadaPessoa.cpf}
                            Rendimento: {cadaPessoa.rendimento.ToString("C")}
                            Logradouro: {cadaPessoa.endereco.Logradouro}
                            Numero: {cadaPessoa.endereco.numero}
                            Complemento: {cadaPessoa.endereco.complemento}
                            Endereço Comercial? {((bool)(cadaPessoa.endereco.endComercial)?"Sim":"Não")}
                            Taxa de Imposto a ser paga: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}

                    ");
                    Console.WriteLine($"Aperte 'Enter'para continuar...");
                    Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Lista Vazia!!!");
                        Thread.Sleep(3000);
                    }
*/      

                using (StringReader SR = new StringReader("FELIPE.TXT"))
                {
                    String linha;
                    while ((linha = SR.ReadLine()) != null)
                    {
                        Console.WriteLine($"{linha}");
                    }

                }

                Console.WriteLine($"Aperte 'enter' para prosseguir");
                Console.ReadLine();


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
                // listaPj.Add(novaPj);

                 using (StreamWriter sw = new StreamWriter($"{novaPj.nome}.txt"))
                {
                    sw.WriteLine(novaPj.nome);   
                 }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                Console.ResetColor();

                break;
            
            case "2":
            
            Console.Clear();
            
            if (listaPj.Count > 0)
            {
             foreach (PessoaJuridica cadaPessoa in listaPj)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                            Razão Social: {cadaPessoa.razaoSocial}
                            CNPJ: {cadaPessoa.cnpj}
                            Rendimento: {cadaPessoa.rendimento.ToString("C")}
                            Logradouro: {cadaPessoa.endereco.Logradouro}
                            Numero: {cadaPessoa.endereco.numero}
                            Complemento: {cadaPessoa.endereco.complemento}
                            Endereço Comercial? {((bool)(cadaPessoa.endereco.endComercial)?"Sim":"Não")}
                            Taxa de Imposto a ser paga: {metodoPj.PagarImposto(cadaPessoa.rendimento).ToString("C")}

                    ");
                    Console.WriteLine($"Aperte 'Enter'para continuar...");
                    Console.ReadLine();
                        }   
            }       
                     else
                    {
                        Console.WriteLine($"Lista Vazia!!!");
                        Thread.Sleep(3000);
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


/*



*/






