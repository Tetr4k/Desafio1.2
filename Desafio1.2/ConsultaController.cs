using System;

public class ConsultaController
{
	public List<Consulta> consultas;
	public ConsultaController()
	{
		consultas = new List<Consulta>();
	}

    public void CriarConsulta(List<Paciente> pacientes)
    {
        string cpf = ConsultaView.CapturaCpf();
        try
        {
            if (pacientes.First(p => p.cpf.Equals(cpf)) == null) throw new Exception("CPF não cadastrado!");
        }
        catch { 
            //Deve-se separar validações entre a view e o controller, ou essa função pertence apenas a um deles? 
        }

        DateTime data = ConsultaView.CapturaData();
        DateTime horaIncicial = ConsultaView.CapturaHoraInicial();
        DateTime horaFinal = ConsultaView.CapturaHoraFinal();

        DateTime abertura = DateTime.ParseExact("0800", "HHmm", System.Globalization.CultureInfo.InvariantCulture);
        DateTime encerramento = DateTime.ParseExact("1900", "HHmm", System.Globalization.CultureInfo.InvariantCulture);

        //verificar se esta disponivel
        consultas.Add(new Consulta(cpf, data, horaIncicial, horaFinal));
    }

    public bool ExcluirConsulta()
    {
        var cpf = ConsultaView.CapturaCpf();
        var data = ConsultaView.CapturaData();
        var horaIncicial = ConsultaView.CapturaHoraInicial();

        var consulta = consultas.Where(c => c.data == data).First(c => c.horaInicial == horaIncicial);
        try
        {
            if (consulta == null) throw new Exception("Não há consulta neste horario!");
        }
        catch
        {

        }

        return consultas.Remove(consulta);
    }

    public void ListarAgenda(List<Paciente> pacientes)
    {
        ConsultaView.ListarConsultas(consultas, pacientes);
    }
}
