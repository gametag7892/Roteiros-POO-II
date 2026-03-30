using BibliotecaValidacoes;

namespace AppDLLteste;


class Program
{
    public static void Main()
    {
        var validar = new Validacoes();
        validar.ValidadorCPF("afasf");
        validar.ValidadorEmail("afasf");
        validar.ValidadorSenha("afasf");
    }
}


// O que quebrou?
//  R: O metodo ValidadorCPF não é mais reconhecido pelo programa principal.

// Pesquisar o conceito de breaking change
//  R:  alteração em um software, API, biblioteca ou infraestrutura que interrompe a compatibilidade com versões anteriores,
//      exigindo que os usuários modifiquem suas configurações ou códigos para
//      que o sistema continue funcionando após uma atualização. 