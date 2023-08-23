using System;

class Program {
    
    public static void Main(string[] args) {

        bool cpfValido = false;

        Console.WriteLine("Informe o CPF completo, sem pontos ou traços:");
        string cpf = Console.ReadLine();

        cpf = cpf.Replace(".", "").Replace("-", ""); // Remover pontos e traços do CPF

        if (cpf.Length != 11 || !VerificarDigitos(cpf)) {
            cpfValido = false;
        } else {
            cpfValido = true;
        }

        if (cpfValido) {
            Console.WriteLine("CPF Válido!");
        } else {
            Console.WriteLine("CPF Inválido!");      
        }
    }

    static bool VerificarDigitos(string cpf) {
        int[] multiplicadoresPrimeiroDigito = {10, 9, 8, 7, 6, 5, 4, 3, 2};
        int[] multiplicadoresSegundoDigito = {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
        int soma = 0;

        for (int i = 0; i < 9; i++) {
            soma += int.Parse(cpf[i].ToString()) * multiplicadoresPrimeiroDigito[i];
        }

        int primeiroDigito = 11 - (soma % 11);
        if (primeiroDigito >= 10) {
            primeiroDigito = 0;
        }

        soma = 0;
        for (int i = 0; i < 10; i++) {
            soma += int.Parse(cpf[i].ToString()) * multiplicadoresSegundoDigito[i];
        }

        int segundoDigito = 11 - (soma % 11);
        if (segundoDigito >= 10) {
            segundoDigito = 0;
        }

        return cpf[9] == primeiroDigito.ToString()[0] && cpf[10] == segundoDigito.ToString()[0];
    }
}
