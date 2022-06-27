using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula07
{ 
    public class ContratoPessoaJuridica:Contrato
    {
        public string Cnpj { get; set; }

        public ContratoPessoaJuridica(string contratante, string cnpj, decimal valor, int prazo)
        {
            this.Contratante = contratante;
            this.Valor = valor;
            this.Prazo = prazo;
            this.Cnpj = cnpj;
            this.NumeroContrato = Guid.NewGuid();
            this.Adicional = 3;
        }
        public override void ExibirInfo()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("                        DADOS DO CONTRATO                          ");
            Console.WriteLine("===================================================================");
            Console.WriteLine($"Contratante: {Contratante}");
            Console.WriteLine($"Cnpj: {Cnpj}");
            base.ExibirInfo();
        }

        public static ContratoPessoaJuridica CreatePessoaJuridica()
        {
            string aux;
            string contratante;
            string cnpj;
            decimal valor;
            int prazo;

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

            Console.WriteLine("Digite o cnpj do Contratante: ");
            do
            {
                aux = Console.ReadLine();
                Valitations.IsCnpjValid(aux);
            } while (!Valitations.IsCnpjValid(aux));
            Console.Clear();
            cnpj = aux;

            Console.WriteLine("Digite o valor do Contrato: ");
            do
            {
                aux = Console.ReadLine();
                if (!decimal.TryParse(aux, out valor))
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

                if (!int.TryParse(aux, out prazo))
                {
                    Console.WriteLine("Número de parcelas inválido, tente novamente... ");
                    Console.WriteLine();
                }
            } while (!int.TryParse(aux, out prazo));
            Console.ReadLine();

            ContratoPessoaJuridica pessoaJuridica = new ContratoPessoaJuridica( contratante,  cnpj,  valor,  prazo);
            return pessoaJuridica;

        }

        public static void PrintPessoaJuridica(List <ContratoPessoaJuridica>listaContratos)
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("                  Contratos Pessoa Jurídica                     ");
            Console.WriteLine("===============================================================");
            foreach (var contrato in listaContratos)
            {
                Console.WriteLine($"Número do contrato: {contrato.NumeroContrato}");
                Console.WriteLine($"Contratante: {contrato.Contratante}");
                Console.WriteLine($"Cpf: {contrato.Contratante}");
                Console.WriteLine($"Valor: {contrato.Valor}");
                Console.WriteLine($"Número de parcelas: {contrato.Prazo}");
                Console.WriteLine();
            }
        }

    }
}
