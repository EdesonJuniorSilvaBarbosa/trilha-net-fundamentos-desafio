namespace DesafioFundamentos.Models
{
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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper() ?? "ABC-0000";

            if(placa.Length == 8)
            {
                bool letrasCorretas = char.IsLetter(placa[0]) && char.IsLetter(placa[1]) && char.IsLetter(placa[2]);
                bool temHifen = placa[3] == '-';
                bool numerosCorretos = char.IsDigit(placa[4]) && char.IsDigit(placa[5]) && char.IsDigit(placa[6]) && char.IsDigit(placa[7]);

                if(letrasCorretas && temHifen && numerosCorretos)
                {
                    veiculos.Add(placa);
                    System.Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
                }
                else
                {
                    System.Console.WriteLine("Placa inválida. Tente novamente");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. O formato correto é ABC-0000.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                decimal valorTotal = 0; 

                while(!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    System.Console.WriteLine("Por favor, insira um número válido de horas");
                }

                valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);
                
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine($"Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    System.Console.WriteLine(veiculo);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
