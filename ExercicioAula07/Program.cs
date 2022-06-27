using ExercicioAula07;
string exit = "";

List <ContratoPessoaFisica> listaContratosPf = new();


List <ContratoPessoaJuridica> listaContratosPj = new();

while (!exit.Equals("3"))
{
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("             AVELINO FINANCEIRA               ");
    Console.WriteLine("==============================================");

    Console.WriteLine("Digite a operação que deseja realizar: ");
    Console.WriteLine("1 - Cadastrar novo contrato \n2 - Exibir contratos cadastrados \n 3 - Sair do programa");

    do
    {
        exit = Console.ReadLine().Trim();
        if(!(exit.Equals("1") || exit.Equals("2") || exit.Equals("3")))
        {
            Console.WriteLine("Entrada invalida, tente novamente...");
            Console.WriteLine();
        }
    } while (!(exit.Equals("1") || exit.Equals("2") || exit.Equals("3")));

    Console.Clear();

    if (exit.Equals("1"))
    {
        string tipoContrato;

        Console.WriteLine("Cadastrando um novo Contrato... \n Digite o tipo de contrato que deseja cadastrar:");
        Console.WriteLine("1 - Pessoa Fisica \n2 - Pessoa Juridica");

        do
        {
            tipoContrato = Console.ReadLine().Trim();
            if(!(tipoContrato.Equals("1") || tipoContrato.Equals("2")))
            {
                Console.WriteLine("Tipo de contrato inválido, tente novamente...");
                Console.WriteLine();
            }

        } while (!(tipoContrato.Equals("1") || tipoContrato.Equals("2")));

        if (tipoContrato.Equals("1"))
        {
            ContratoPessoaFisica pessoafisica = ContratoPessoaFisica.CreatePessoaFisica();
            listaContratosPf.Add(pessoafisica);
        }
        if (tipoContrato.Equals("2"))
        {
            ContratoPessoaJuridica pessoaJuridica = ContratoPessoaJuridica.CreatePessoaJuridica();
            listaContratosPj.Add(pessoaJuridica);
        }
    }

    if (exit.Equals("2"))
    {
        Console.WriteLine("Digite o tipo de contratos que deseja exibir");
        Console.WriteLine("1 - Contratos Pessoa Fisica \n2 - Contratos Pessoa Juridica");
        string tipoBusca;
        do
        {
            tipoBusca = Console.ReadLine().Trim();
            if(!(tipoBusca.Equals("1") || tipoBusca.Equals("2")))
            {
                Console.WriteLine("Tipo de contrato inválido, tente novamente...");
            }

        } while (!(tipoBusca.Equals("1") || tipoBusca.Equals("2")));

        if (tipoBusca.Equals("1"))
        {
            if(listaContratosPf.Count == 0)
            {
                Console.WriteLine("Ainda não existem contratos do tipo Pessoa Física");
                continue;
            }
            ContratoPessoaFisica.PrintListaPessoaFisica(listaContratosPf);
        }

        if (tipoBusca.Equals("2"))
        {
            if (listaContratosPj.Count == 0)
            {
                Console.WriteLine("Ainda não exitem contratos do tipo Pessoa Jurídica");
                continue;
            }
            ContratoPessoaJuridica.PrintPessoaJuridica(listaContratosPj);
        }
    }
}




