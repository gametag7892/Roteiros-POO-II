using System;
using NLog;

namespace ExerciciosNLog
{
    class Program
    {
        // Inicialização do Logger do NLog
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            // EXERCÍCIO 2: Log de início do programa
            // EXERCÍCIO 5: Uso do nível 'Info' para operação normal
            Logger.Info("Aplicação iniciada com sucesso.");

            try
            {

                // EXERCÍCIO 3: Conversão de string para inteiro com log de erro

                string textoParaConverter = "abc123"; 

                try
                {
                    Logger.Info($"Tentando converter a string '{textoParaConverter}' para inteiro.");
                    int resultado = int.Parse(textoParaConverter);
                }
                catch (FormatException ex)
                {
                    // EXERCÍCIO 3: Log de erro ao falhar na conversão
                    // EXERCÍCIO 5: Uso do 'Error' para capturar a exceção
                    Logger.Error(ex, "Falha na conversão de string para inteiro.");
                }



                // EXERCÍCIO 6: Implementação do Fluxo de Contas
                // Registrando o Início, Sucesso e Erro de cada operação

                Conta contaOrigem = new Conta("123-X", 500.00m);
                Conta contaDestino = new Conta("456-Y", 100.00m);

                Console.WriteLine("\n--- Iniciando Fluxos de Teste ---\n");

                // Fluxo A: Depósito (Início e Sucesso)
                contaOrigem.Depositar(200.00m);

                // Fluxo B: Saque com Sucesso
                contaOrigem.Sacar(150.00m);

                // Fluxo C: Transferência com Sucesso
                contaOrigem.Transferir(100.00m, contaDestino);

                // Fluxo D: Tentativa Inválida (Valor negativo) -> Vai gerar Warn
                try
                {
                    contaOrigem.Sacar(-50.00m);
                }
                catch (ArgumentException) { /* Tratado para o programa continuar */ }

                // Fluxo E: Erro de Saldo Insuficiente -> Vai gerar Error/Exceção
                try
                {
                    contaOrigem.Sacar(2000.00m);
                }
                catch (InvalidOperationException) { /* Tratado para o programa continuar */ }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Ocorreu um erro inesperado no fluxo principal do programa.");
            }
            finally
            {

                // EXERCÍCIO 2: Log de fim do programa
                Logger.Info("Aplicação finalizada.");
            }

            Console.ReadKey();
        }
    }


    // EXERCÍCIO 4: Criação da Classe Conta
    public class Conta
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public string Numero { get; private set; }
        public decimal Saldo { get; private set; }

        public Conta(string numero, decimal saldoInicial)
        {
            Numero = numero;
            Saldo = saldoInicial;
            Logger.Info($"Conta {Numero} criada com saldo inicial de R$ {Saldo}");
        }

        public void Depositar(decimal valor)
        {
            // EXERCÍCIO 6: Registra o início da operação
            Logger.Info($"[Depósito] Iniciando operação de depósito na conta {Numero}. Valor: R$ {valor}");

            // EXERCÍCIO 5: Uso do 'Warn' para tentativa inválida
            if (valor <= 0)
            {
                Logger.Warn($"[Depósito] Tentativa inválida de depósito na conta {Numero}. Valor informado: R$ {valor}");
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }

            Saldo += valor;

            // EXERCÍCIO 6: Registra o sucesso da operação
            Logger.Info($"[Depósito] Sucesso! Novo saldo da conta {Numero}: R$ {Saldo}");
        }

        public void Sacar(decimal valor)
        {
            // EXERCÍCIO 4: Logue tentativa de saque
            // EXERCÍCIO 6: Registra o início da operação
            Logger.Info($"[Saque] Iniciando tentativa de saque na conta {Numero}. Valor solicitado: R$ {valor}");

            // EXERCÍCIO 5: Uso do 'Warn' para tentativa inválida
            if (valor <= 0)
            {
                Logger.Warn($"[Saque] Tentativa inválida de saque na conta {Numero}. Valor solicitado: R$ {valor}");
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            }

            // EXERCÍCIO 4: Logue erro de saldo insuficiente
            // EXERCÍCIO 5: Uso do 'Error' para exceção gerada
            if (valor > Saldo)
            {
                var excecao = new InvalidOperationException("Saldo insuficiente para realizar a operação.");

                // EXERCÍCIO 6: Registra o erro do fluxo
                Logger.Error(excecao, $"[Saque] Erro de saldo insuficiente na conta {Numero}. Saldo atual: R$ {Saldo}, Solicitado: R$ {valor}");
                throw excecao;
            }

            Saldo -= valor;

            // EXERCÍCIO 6: Registra o sucesso da operação
            Logger.Info($"[Saque] Sucesso! Saque realizado na conta {Numero}. Saldo atual: R$ {Saldo}");
        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            // EXERCÍCIO 6: Registra o início da operação
            Logger.Info($"[Transferência] Iniciando transferência de R$ {valor} da conta {this.Numero} para a conta {contaDestino.Numero}");

            try
            {
                this.Sacar(valor);
                contaDestino.Depositar(valor);

                // EXERCÍCIO 6: Registra o sucesso da operação
                Logger.Info($"[Transferência] Sucesso! Transferência de R$ {valor} concluída com êxito.");
            }
            catch (Exception ex)
            {
                // EXERCÍCIO 6: Registra o erro do fluxo caso falte saldo ou ocorra outro problema
                Logger.Error(ex, $"[Transferência] Erro ao tentar transferir R$ {valor} de {this.Numero} para {contaDestino.Numero}");
                throw;
            }
        }
    }
}