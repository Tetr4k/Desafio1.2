// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Globalization;

Console.WriteLine("Hello, World!");

/*
 Fiquei com duvida quanto a validação: erros "lexicos/sintaticos" e regras da aplicação devem ser validados juntos? aqui validei os lexicos/sintaticos nas views e as regras da aplicação nos controllers.
 */

//Controller pode/deve ser implementado como um singleton?
PacienteController pacienteController = new PacienteController();
ConsultaController consultaController = new ConsultaController();

string line=null;

//Deveria ter criado uma MainController?
do
{
    switch (line)
    {
        case "1":
            string line2 = null;
            do
            {
                switch (line2)
                {
                    case "1":
                        pacienteController.CriarPaciente();
                        break;
                    case "2":
                        pacienteController.ExcluirPaciente(consultaController.consultas);
                        break;
                    case "3":
                        pacienteController.ListarPacientesPorCPF(consultaController.consultas);
                        break;
                    case "4":
                        pacienteController.ListarPacientesPorCPF(consultaController.consultas);
                        break;
                }
                Console.WriteLine("Menu do Cadastro de Pacientes");
                Console.WriteLine("1-Cadastrar novo paciente");
                Console.WriteLine("2-Excluir paciente");
                Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
                Console.WriteLine("4-Listar pacientes (ordenado por Nome)");
                Console.WriteLine("5-Voltar p/ menu principal");
            } while ((line2 = Console.ReadLine()) != null && line2 != "5");
            break;
        case "2":
            string line3=null;
            do
            {
                switch (line3)
                {
                    case "1":
                        consultaController.CriarConsulta(pacienteController.pacientes);
                        break;
                    case "2":
                        consultaController.ExcluirConsulta();
                        break;
                    case "3":
                        consultaController.ListarAgenda(pacienteController.pacientes);
                        break;
                }
                Console.WriteLine("Agenda");
                Console.WriteLine("1-Agendar consulta");
                Console.WriteLine("2-Cancelar agendamento");
                Console.WriteLine("3-Listar agenda");
                Console.WriteLine("4-Voltar p/ menu principal");
            } while ((line3 = Console.ReadLine()) != null && line3 != "4");
            break;
    }
    Console.WriteLine("Menu Principal");
    Console.WriteLine("1-Cadastro de pacientes");
    Console.WriteLine("2-Agenda");
    Console.WriteLine("3-Fim");
} while ((line = Console.ReadLine()) != null && line != "3");