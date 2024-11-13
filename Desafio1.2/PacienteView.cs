using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class PacienteView
{
    public static string CapturaCpf()
    {
        while (true)
        {
            string cpf;
            try
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine().Trim();
                return Functions.ValidaCPF(cpf);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                continue;
            }
        }
    }

    public static string CapturaNome()
    {
        string nome;
        while (true)
        {
            string cpf;
            try
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim();
                return Functions.ValidaNome(nome);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                continue;
            }
        }
    }

    public static DateTime CapturaDataNascimento()
    {
        string nome;
        while (true)
        {
            string data;
            try
            {
                Console.Write("Data de nascimento: ");
                data = Console.ReadLine().Trim();
                return Functions.ValidaDataNascimento(data);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                continue;
            }
        }
    }

    public static void ListarPacientes(List<Paciente> pacientes, List<Consulta> consultas)
    {
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("CPF         Nome                             Dt.Nasc.  Idade");
        Console.WriteLine("------------------------------------------------------------");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente.ToString());
            foreach (var consulta in consultas.Where(c => c.cpf.Equals(paciente.cpf)).ToList()){
                Console.WriteLine($"\t{consulta.ToString()}");
            }
        }
        Console.WriteLine("------------------------------------------------------------");
    }
}
