namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
        // *IMPLEMENTE AQUI*
        string? resultado;
        do
        {
            string placa = PedirPlaca();
            resultado = ValidarPlaca(placa);
            Console.WriteLine(resultado);

            if (resultado != "Placa válida")
            {
                Console.WriteLine("Pressione uma tecla para tentar novamente...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                veiculos.Add(placa);
            }
        } while (resultado != "Placa válida");
    }


    public void RemoverVeiculo()
    {
        // Pedir para o usuário digitar a placa e armazenar na variável placa
        string placa = PedirPlaca();

        // Verifica se o veículo existe
        if (veiculos.Any(x => x == placa))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            int horas = 0;
            decimal valorTotal = 0;

            while (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0)
                Console.WriteLine("Entrada inválida! Digite um número inteiro positivo maior que zero.");

            valorTotal = precoInicial + precoPorHora * horas;
            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }

    public void ListarVeiculos()
    {
        // Verifica se há veículos no estacionamento
        if (veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados são:");


            foreach (string veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }


    public string ValidarPlaca(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
            return "A placa não pode ser nula ou vazia.";
        if (placa.Length != 7)
            return "A placa deve conter exatamente 7 caracteres.";
        int[] letras = [0, 1, 2, 4];
        int[] digitos = [3, 5, 6];
        if (!letras.All(i => char.IsLetter(placa[i])) ||
        !digitos.All(i => char.IsDigit(placa[i]))
        )
            return "Formato inválido. Confira o formato da placa: ABC1D23";
        return "Placa válida";
    }
    public string PedirPlaca()
    {
        Console.WriteLine("Digite a placa do veículo (formato ABC1D23):");
        return (Console.ReadLine() ?? "").ToUpper().Replace("-", "").Trim();
    }

}
//Pede input da placa

