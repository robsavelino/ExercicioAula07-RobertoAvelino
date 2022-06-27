using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula07
{
    public class ContratoPessoaFisica:Contrato
    {
        public List<ContratoPessoaFisica> ListaPessoasFisicas { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public ContratoPessoaFisica (string contratante, string cpf, DateTime dataNascimento, decimal valor, int prazo)
        {
            NumeroContrato = Guid.NewGuid();
            Contratante = contratante;
            Valor = valor;
            Prazo = prazo;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Adicional = CalcularAdicionalParcela(CalcularIdade());

        }

        public int CalcularIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;

            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                idade--;

            return idade;
        }

        public int CalcularAdicionalParcela (int idade)
        {
            int adicionalParcela = 1;

            if (idade <= 40)
                adicionalParcela = 2;
            else if (idade <= 50)
                adicionalParcela = 3;
            else if (idade > 50)
                adicionalParcela = 4;

            return adicionalParcela;

        }
        
        public override void ExibirInfo()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("                        DADOS DO CONTRATO                          ");
            Console.WriteLine("===================================================================");
            Console.WriteLine($"Contratante: {Contratante}");
            Console.WriteLine($"Cpf: {Cpf}");
            Console.WriteLine($"Idade: {CalcularIdade}");
            base.ExibirInfo();
        }

        public static ContratoPessoaFisica CreatePessoaFisica()
        {
            string aux;
            string contratante;
            decimal valor;
            int prazo;
            string cpf;
            DateTime dataNascimento;

            Console.WriteLine("Digite o nome do Contratante: ");
            do
            {
                aux = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(aux))
                {
                    Console.WriteLine("Nome inserido é vazio, tente novamente...");
                    Console.WriteLine();
                }

            } while (String.IsNullOrWhiteSpace(aux));
            Console.Clear();
            contratante = aux;

            Console.WriteLine("Digite o cpf do Contratante: ");
            do
            {
                aux = Console.ReadLine();
                Valitations.IsCpfValid(aux);
            } while (!Valitations.IsCpfValid(aux));
            Console.Clear();
            cpf = aux;

            Console.WriteLine("Digite a data de nascimento do Contratante: ");
            do
            {
                aux= Console.ReadLine();
                Valitations.IsBirthDateValid(aux);

            } while (!Valitations.IsBirthDateValid(aux));
            dataNascimento = Convert.ToDateTime(aux);

            Console.WriteLine("Digite o valor do Contrato: ");
            do
            {
                aux= Console.ReadLine();
                if(!decimal.TryParse(aux, out valor))
                {
                    Console.WriteLine("Valor digitado inválido, tente novamente...");
                    Console.WriteLine();
                }
            } while (!decimal.TryParse(aux, out valor));
            Console.Clear();

            Console.WriteLine("Digite o numero de parcelas: ");
            do
            {
                aux = Console.ReadLine();

                if(!int.TryParse(aux, out prazo))
                {
                    Console.WriteLine("Número de parcelas inválido, tente novamente... ");
                    Console.WriteLine();
                }
            } while (!int.TryParse(aux, out prazo));
            Console.ReadLine();

            ContratoPessoaFisica pessoaFisica = new ContratoPessoaFisica(contratante, cpf, dataNascimento, valor, prazo);

            return pessoaFisica;

        }

        public static void PrintListaPessoaFisica(List <ContratoPessoaFisica> listaPessoas)
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("                   Contratos Pessoa Fisica                     ");
            Console.WriteLine("===============================================================");
            foreach (var contrato in listaPessoas)
            {
                Console.WriteLine($"Número do contrato: {contrato.NumeroContrato}");
                Console.WriteLine($"Contratante: {contrato.Contratante}");
                Console.WriteLine($"Cpf: {contrato.Contratante}");
                Console.WriteLine($"Data de Nascimento: {contrato.DataNascimento}");
                Console.WriteLine($"Valor: {contrato.Valor}");
                Console.WriteLine($"Número de parcelas: {contrato.Prazo}");
                Console.WriteLine();
            }
        }

    }
}
