using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula07
{
    public class Contrato
    {
        public Guid NumeroContrato { get; set; }
        public string Contratante { get; set; }
        public decimal Valor { get; set; }
        public int Prazo { get; set; }

        public int Adicional { get; set; }
        public virtual decimal ValorParcela()
        {
            return Valor/ Prazo + Adicional;
        }


        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Número do contrato { NumeroContrato}");
            Console.WriteLine($"Valor do Contrato: {Valor}");
            Console.WriteLine($"Prazo do Contrato: {Prazo}");
            Console.WriteLine($"Valor da Prestação: {ValorParcela().ToString("F")}");
        }

    }
}
