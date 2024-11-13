using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ConsultaView
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

    public static DateTime CapturaData()
    {
        while (true)
        {
            string data;
            try
            {
                Console.Write("Data da consulta: ");
                data = Console.ReadLine().Trim();
                return Functions.ValidaData(data);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                continue;
            }
        }
    }

    public static DateTime CapturaHoraInicial()
    {
        while (true)
        {
            string hora;
            try
            {
                Console.Write("Hora inicial: ");
                hora = Console.ReadLine().Trim();
                return Functions.ValidaHorario(hora);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                continue;
            }
        }
    }

    public static DateTime CapturaHoraFinal()
    {
        while (true)
        {
            string hora;
            try
            {
                Console.Write("Hora final: ");
                hora = Console.ReadLine().Trim();
                return Functions.ValidaHorario(hora);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                continue;
            }
        }
    }

    public static void ListarConsultas(List<Consulta> consultas, List<Paciente> pacientes)
    {
        List<Consulta> periodo = consultas;
        Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
        var modo = Console.ReadLine();

        DateTime dataInicial, dataFinal;
        if (modo == "P")
        {
            string data;
            Console.Write("Data inicial: ");
            data = Console.ReadLine();
            dataInicial = Functions.ValidaData(data);
             
            Console.Write("Data final: ");
            data = Console.ReadLine();
            dataFinal = Functions.ValidaData(data);

            periodo = periodo.Where(p => p.data > dataInicial && p.data < dataFinal).ToList();
        }
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Data H.Ini H.Fim Tempo Nome Dt.Nasc.");
        Console.WriteLine("-------------------------------------------------------------");
        
        foreach (var consulta in periodo)
        {
            var paciente = pacientes.First(p => p.cpf.Equals(consulta.cpf));
            //Console.Write($"{consulta.data} {consulta.horaInicial} {consulta.horaFinal} {Calcular o tempo} {paciente.nome} {paciente.dataNascimento}");
            Console.WriteLine($"{Functions.FormatarData(consulta.data)} {Functions.FormatarHora(consulta.horaInicial)} {Functions.FormatarHora(consulta.horaFinal)} {paciente.nome} {paciente.dataNascimento}");
        }
    }
}
