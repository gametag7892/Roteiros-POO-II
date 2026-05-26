using System;

namespace SistemaBancario
{

    // EXERCÍCIO 2: Nova Exceção
    public class LimiteDiarioException : Exception
    {
        public LimiteDiarioException(string message) : base(message) { }
    }

    // EXERCÍCIO 8: Nova exceção (Limite Acumulado)

    public class LimiteAcumuladoException : Exception
    {
        public LimiteAcumuladoException(string message) : base(message) { }
    }

    public class Conta
    {
        public decimal Saldo { get; private set; }

        // EXERCÍCIO 8: Controle por variável interna
        private decimal _saqueAcumuladoDiario = 0;
        private const decimal LIMITE_DIARIO_TOTAL = 2000m;

        public Conta(decimal saldoInicial = 0)
        {
            Saldo = saldoInicial;
        }


        // EXERCÍCIO 1: Validação básica no Depositar

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");

            // Regra: não permitir valores maiores que 10.000
            if (valor > 10000m)
                throw new ArgumentOutOfRangeException(nameof(valor), "Não são permitidos depósitos com valores maiores que 10.000.");

            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");

            // EXERCÍCIO 2: Regra de saque máximo por operação = 500
            if (valor > 500m)
                throw new LimiteDiarioException("O limite de saque por operação é de no máximo R$ 500,00.");

            // EXERCÍCIO 8: Limite de saque diário acumulado
            if (_saqueAcumuladoDiario + valor > LIMITE_DIARIO_TOTAL)
                throw new LimiteAcumuladoException($"Limite diário acumulado excedido. Seu limite restante hoje é de R$ {LIMITE_DIARIO_TOTAL - _saqueAcumuladoDiario}.");

            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;
            _saqueAcumuladoDiario += valor;
        }

        // EXERCÍCIO 3: Transferência
        public void Transferir(Conta destino, decimal valor)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino), "A conta de destino não pode ser nula.");

            try
            {
                // Usando Sacar e Depositar para manter as regras de validação consistentes
                this.Sacar(valor);
                destino.Depositar(valor);
            }
            catch (Exception ex)
            {
                /*
                 
                EXERCÍCIO 5:

                DADO O CÓDIGO ERRADO: 
                    catch (Exception ex) { throw ex; }

                MOTIVO DO ERRO: 
                Usar "throw ex;" zera o StackTrace da exceção. O sistema passa a achar 
                que o erro aconteceu na linha do "throw ex;", escondendo o método e a linha 
                original onde o problema realmente ocorreu.
                    
                CORREÇÃO:
                Para repassar o erro mantendo o rastro original, use apenas "throw;" ou empacote 
                o erro original dentro de uma nova exceção usando o parâmetro InnerException 
                (como feito abaixo).

                 */

                throw new InvalidOperationException("Falha na operação de transferência.", ex);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Conta minhaConta = new Conta(3000);
            Conta contaDestino = new Conta(100);

            try
            {

                // EXERCÍCIO 6: Simular entrada do usuário e erro de conversão

                Console.Write("Digite o valor que deseja transferir: ");
                string entrada = Console.ReadLine();

                // Pode gerar um erro de formatação se o usuário digitar letras
                decimal valor = Convert.ToDecimal(entrada);

                minhaConta.Transferir(contaDestino, valor);
                Console.WriteLine("Operação realizada com sucesso!");
            }
            catch (FormatException)
            {
                // EXERCÍCIO 6: Tratamento com mensagem amigável
                Console.WriteLine("Erro de digitação: Por favor, informe apenas números válidos.");
            }
            catch (Exception ex) // EXERCÍCIO 4: Uso de Propriedades
            {
                Console.WriteLine("\n--- DETALHES TÉCNICOS DO ERRO ---");
                Console.WriteLine($"[Message]: {ex.Message}");
                Console.WriteLine($"[StackTrace]: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"[InnerException]: {ex.InnerException.Message}");
                }
            }

            /*
             
            EXERCÍCIO 7:
             
            1. Por que usar exceção personalizada aqui?

            R: Para separar erros de regras de negócio (como exceder o limite de saque) 
            de erros de infraestrutura (como falha de memória ou nulos). Isso permite que a 
            camada que chamou o código use "catch (LimiteDiarioException)" e tome ações específicas 
            para esse cenário, melhorando a clareza.

            2. Qual a função do InnerException?

            R: Ele preserva o histórico de um erro. Se um método (Transferir) captura uma 
            exceção gerada por outro (Sacar) e lança uma nova exceção mais genérica 
            ("Falha na transferência"), o InnerException guarda a exceção original. 
            Isso é crucial para debugar e descobrir o real motivo da falha.
             
             3. Onde o erro deve ser tratado: Conta ou Main?

             R: A classe 'Conta' deve apenas *lançar* o erro (validar as regras). O tratamento 
             final do erro (o bloco try-catch e a decisão de mostrar a mensagem na tela) 
             deve ficar no 'Main' (ou na interface do usuário). A classe Conta não deve se preocupar 
             com a forma que a mensagem será exibida.

             */
        }
    }
}