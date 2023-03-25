using System.Text.RegularExpressions;
using PROJETO.Interfaces;

namespace PROJETO.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set;}
        public string caminho {get; private set;} = "Database/PessoaJuridica.csv";
        
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if(rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if(rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)")) 
            {
                if(cnpj.Length == 18)
                {
                    if(cnpj.Substring(11,4) == "0001")
                    {
                        return true;
                    }  
                }
                else if(cnpj.Length == 14)
                {
                    if(cnpj.Substring(8,4) == "0001")
                    {
                        return true;
                    }
                }  
            }
            return false;
        }

 public void Inserir(PessoaJuridica pj)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial},{pj.rendimento},{pj.endereco.logradouro},{pj.endereco.numero},{pj.endereco.complemento},{pj.endereco.endComercial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {
            VerificarPastaArquivo(caminho);

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);


            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();
                Endereco cadaEnd = new Endereco();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];
                cadaPj.rendimento = float.Parse(atributos[3]);
                cadaEnd.logradouro = atributos[4];
                cadaEnd.numero = int.Parse(atributos[5]);
                cadaEnd.complemento = atributos[6];
                cadaEnd.endComercial = bool.Parse(atributos[7]);
                cadaPj.endereco = cadaEnd;
                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
    }
}