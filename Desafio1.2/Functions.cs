using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Functions
{
    public static string FormatarData(DateTime data)
    {
        return $"{data.Day.ToString().PadLeft(2, '0').Substring(0, 2)}/{data.Month.ToString().PadLeft(2, '0').Substring(0, 2)}/{data.Year}";
    }

    public static string FormatarHora(DateTime data)
    {
        return $"{data.Hour}:{data.Minute}";
    }

    public static int CalculaIdade(DateTime dataNascimento)
    {
        int qtdAnos = DateTime.Now.Year - dataNascimento.Year;
        return DateTime.Now > dataNascimento.AddYears(qtdAnos) ? qtdAnos : qtdAnos-1;
    }

    public static string ValidaCPF(string cpf)
    {
        var regex = new Regex(@"\D");
        if (regex.IsMatch(cpf)) throw new Exception("Um CPF deve conter apenas numeros!");

        if (cpf.Length != 11) throw new Exception("O CPF deve ter 11 digitos!");

        string[] iguais = { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
        if (iguais.Contains(cpf)) throw new Exception("Os digitos não podem ser todos iguais!");

        var J = (int) char.GetNumericValue(cpf[9]);
        var K = (int) char.GetNumericValue(cpf[10]);

        var somaJ = cpf.Substring(0, 9).Select((digito, i) => (int) char.GetNumericValue(digito) * (10 - i)).Sum();
        var restoJ = somaJ % 11;
        if (restoJ >= 2)
        {
            if (J != 11 - restoJ) throw new Exception("CPF Invalido!");
        }
        else if (J != 0) throw new Exception("CPF Invalido!");

        var somaK = cpf.Substring(0, 10).Select((digito, i) => (int) char.GetNumericValue(digito) * (11 - i)).Sum();
        var restoK = somaK % 11;

        Console.WriteLine(restoK);

        if (restoK >= 2)
        {
            if (K != 11 - restoK) throw new Exception("CPF Invalido!");
        }
        else if (K != 0) throw new Exception("CPF Invalido2!");

        return cpf;
    }
    public static string ValidaNome(string nome)
    {
        if (nome.Length < 5) throw new Exception("Nome Invalido");
        return nome;
    }
    public static DateTime ValidaDataNascimento(string data)
    {
        if (data == null || data.Length == 0) throw new Exception("Digite uma data");

        var regex = new Regex(@"\D");
        if (regex.IsMatch(data)) throw new Exception("Uma data deve conter apenas numeros!");

        DateTime dataNascimento = DateTime.ParseExact(data, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
        if (CalculaIdade(dataNascimento) < 13) throw new Exception("O paciente deve ter mais que 13 anos de idade!");
        return dataNascimento;
    }

    public static DateTime ValidaData(string data)
    {
        if (data == null || data.Length == 0) throw new Exception("Digite uma data");

        var regex = new Regex(@"\D");
        if (regex.IsMatch(data)) throw new Exception("Uma data deve conter apenas numeros!");
        DateTime dataMarcada = DateTime.ParseExact(data, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

        if (dataMarcada < DateTime.Now) throw new Exception("A data deve ser futura!");

        return dataMarcada;
    }

    public static DateTime ValidaHorario(string hora)
    {
        if (hora == null || hora.Length == 0) throw new Exception("Digite uma horario");
        var regex = new Regex(@"\D");
        if (regex.IsMatch(hora)) throw new Exception("Um horario deve conter apenas numeros!");
        DateTime horario = DateTime.ParseExact(hora, "HHmm", System.Globalization.CultureInfo.InvariantCulture);

        return horario;
    }
}
