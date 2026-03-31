using System.Text.RegularExpressions;

namespace Exercicio_1
{
    public class ValidadorSenha
    {
        public bool EhValida(string senha)
        {
            if (string.IsNullOrEmpty(senha)) return false;
            if (senha.Length < 8) return false;
            bool contemLetra = Regex.IsMatch(senha, "[A-Za-z]");
            bool contemNumero = Regex.IsMatch(senha, "[0-9]");
            return contemLetra && contemNumero;
        }
    }
}