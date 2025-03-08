using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Hospedagem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();

            Pessoa p1 = new Pessoa(nome: "Hóspede 1");
            Pessoa p2 = new Pessoa(nome: "Hóspede 2");   

            hospedes.Add(p1);
            hospedes.Add(p2);    

            // Cria a suíte
            Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

            // Cria uma nova reserva, passando a suíte e os hóspedes
            Reserva reserva = new Reserva(diasReservados: 5);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

            Console.ReadLine();
        }

        public class Pessoa
        {
            public Pessoa() { }

            public Pessoa(string nome)
            {
                Nome = nome;
            }

            public Pessoa(string nome, string sobrenome)
            {
                Nome = nome;
                Sobrenome = sobrenome;
            }

            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
        }

        public class Reserva
        {
            public List<Pessoa> Hospedes { get; set; }
            public Suite Suite { get; set; }
            public int DiasReservados { get; set; }

            public Reserva() { }

            public Reserva(int diasReservados)
            {
                DiasReservados = diasReservados;
            }

            public void CadastrarHospedes(List<Pessoa> hospedes)
            {
                //Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
               
                if (hospedes.Count <= 2)
                {
                    Hospedes = hospedes;
                }
                else 
                {
                    // Retorna uma exception caso a capacidade seja menor que o número de hóspedes recebido                  
                    throw new Exception("Extrapolou o limite de hospedes");
                }
            }

            public void CadastrarSuite(Suite suite)
            {
                Suite = suite;
            }

            public int ObterQuantidadeHospedes()
            {
                //Retorna a quantidade de hóspedes 
                int quantidade = Hospedes.Count();
                return quantidade;
            }

            public decimal CalcularValorDiaria()
            {
                //Retorna o valor da diária
                decimal valor = DiasReservados * Suite.ValorDiaria;

                //Caso os dias reservados forem maior ou igual a 10, concede um desconto de 10%
                if (DiasReservados >= 10)
                {  
                    valor = valor - 10/100;
                }

                return valor;
            }
        }

        public class Suite
        {
            public Suite() { }

            public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
            {
                TipoSuite = tipoSuite;
                Capacidade = capacidade;
                ValorDiaria = valorDiaria;
            }

            public string TipoSuite { get; set; }
            public int Capacidade { get; set; }
            public decimal ValorDiaria { get; set; }
        }



    }
}
