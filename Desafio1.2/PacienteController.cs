using System;

public class PacienteController
{
	public List<Paciente> pacientes { get; private set; }
	public PacienteController()
	{
		pacientes = new List<Paciente>();
	}

    public void CriarPaciente()
    {
        string cpf = PacienteView.CapturaCpf();
        try
        {
            if (pacientes.First(p => p.cpf.Equals(cpf)) != null) throw new Exception("CPF ja cadastrado!");
        }
        catch { }

        string nome = PacienteView.CapturaNome();
        DateTime dataNascimento = PacienteView.CapturaDataNascimento();
        pacientes.Add(new Paciente(cpf, nome, dataNascimento));
    }

    public bool ExcluirPaciente(List<Consulta> consultas)
    {
        var cpf = PacienteView.CapturaCpf();
        var paciente = pacientes.First(p => p.cpf == cpf);

        var consulta = consultas.First(c => c.cpf == cpf);
        try
        {
            if (consulta != null) throw new Exception("Pacientes com consultas agendadas não podem ser exlcuidos");
        }
        catch
        {

        }
        return pacientes.Remove(paciente);
    }

    public void ListarPacientesPorCPF(List<Consulta> consultas)
    {
        //pacientes.Sort(delegate (p, p2) => p.cpf > p2.cpf);
        PacienteView.ListarPacientes(pacientes, consultas);
    }

    public void ListarPacientesPorNome(List<Consulta> consultas)
    {
        PacienteView.ListarPacientes(pacientes, consultas);
    }
}
