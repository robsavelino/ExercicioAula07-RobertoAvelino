using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExercicioAula07;

public class Valitations
{
    public static bool IsCpfValid (string cpf)
    {
        Regex RgxCpf = new Regex(@"\d{3}\.\d{3}\.\d{3}\-\d{2}");
        if (!RgxCpf.Match(cpf).Success)
        {
            Console.WriteLine("Cpf digitado inválido! Digite no formato: 123.123.123-12");
            return false;
        }
        return true;
    }

    public static bool IsCnpjValid (string cnpj)
    {
        Regex RgxCnpj = new Regex(@"\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}");
        if (!RgxCnpj.Match(cnpj).Success)
        {
            Console.WriteLine("Cnpj digitado inválido! Digite no formato: 12.123.123/0001-12");
            return false;
        }
        return true;
    }
    public static bool IsBirthDateValid (string birthdate)
    {
        Regex RgcBirthDate = new Regex(@"\d{2}\/\d{2}\/\d{4}");
        if (!RgcBirthDate.Match(birthdate).Success)
        {
            Console.WriteLine("Data de nascimento inválida: Digite no formato: dd/mm/aaaa");
            return false;
        }
        return true;
    }

}
