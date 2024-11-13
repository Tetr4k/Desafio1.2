using System;

public class Consulta
{
	public string cpf;
	public DateTime data;
	public DateTime horaInicial;
	public DateTime horaFinal;
	public Consulta(string cpf, DateTime data, DateTime horaInicial, DateTime horaFinal)
	{
        this.cpf = cpf;
        this.data = data;
        this.horaInicial = horaInicial;
		this.horaFinal = horaFinal;
	}

    public override string ToString()
    {
        return $"Agendado para: {Functions.FormatarData(data)}\n {Functions.FormatarHora(horaInicial)} às {Functions.FormatarHora(horaFinal)}";
    }
}