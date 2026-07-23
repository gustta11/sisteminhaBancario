using System.Security.Cryptography.X509Certificates;

namespace sisteminhaBancario;

using System.IO;

public class Program
{
    public static void Main()
    {
        string nomeTitular = "Gustavo Keven";
        double saldoTitular = 50000;

        string titulo = "----------SISTEMA BANCÁRIO----------";
        int opcao = 0;
        const int opcaoSaida = 5;
        const int Senha = 1234;

        void opcoes()
        {
            Console.WriteLine("ESCOLHA A SUA OPÇÃO");
            Console.WriteLine("[1] Consulta de saldo");
            Console.WriteLine("[2] Depósito");
            Console.WriteLine("[3] Saque");
            Console.WriteLine("[4] Extrato");
            Console.WriteLine("[5] Sair");
        }

        string conta()
        {
            string content = $"Nome do Titular:{nomeTitular} Saldo: {saldoTitular}";
            return content;
        }

        double consultaSaldo()
        {
            return saldoTitular;
        }

        void deposito()
        {
            double valorDeposito;
            Console.WriteLine("Informe o valor que deseja depositar:");
            if (double.TryParse(Console.ReadLine(), out valorDeposito))
            {
                if (valorDeposito > 0)
                {
                    saldoTitular += valorDeposito;
                }
                else
                {
                    Console.WriteLine("Valor inválido");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido");
            }
        }


        void saque()
        {
            double valorSaque;
            Console.WriteLine("Informe o valor que deseja sacar:");
            if (double.TryParse(Console.ReadLine(), out valorSaque))
            {
                if(valorSaque > 0 && valorSaque <= saldoTitular)
                {
                    saldoTitular -= valorSaque;
                }
                else
                {
                    Console.WriteLine("Saldo insuficiiente");
                }
                
            }
            else
            {
                Console.WriteLine("Valor inválido");
            }
        }

        string criacaoPathFileExtrato()
        {
            string path = @"C:\Users\gustavo.souza\source\repos\sisteminhaBancario\sisteminhaBancario\";
            string file = "extrato.Doc";
            string filePath = path + file;
            return filePath;
        }

        void extrato()
        {
            string filePath = criacaoPathFileExtrato();
            File.WriteAllText(filePath, conta());
        }

        Console.WriteLine(titulo);
        Console.WriteLine("Informe sua senha para prosseguir:");

        if (int.TryParse(Console.ReadLine(), out int senha))
        {

            if (senha == Senha)
            {
                while (opcao != opcaoSaida)
                {
                    opcoes();
                    if (int.TryParse(Console.ReadLine(), out opcao))
                    {
                        switch (opcao)
                        {
                            case 1:
                                double saldo = consultaSaldo();
                                Console.WriteLine(saldo);
                                break;
                            case 2:
                                deposito();
                                break;
                            case 3:
                                saque();
                                break;
                            case 4:
                                extrato();
                                Console.WriteLine("Extrato gerado com sucesso!");
                                break;
                            case 5:
                                opcao = 5;
                                break;
                            default:
                                Console.WriteLine("Opção não existe");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida)");
                    }
                }
            }
            else
            {
                Console.WriteLine("Senha inválida");
            }
        }
        else
        {
            Console.WriteLine("Senha inválida");
        }
    }
}
