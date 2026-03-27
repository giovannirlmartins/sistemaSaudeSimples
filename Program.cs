using System;

namespace desafio1;

public class Program()
{
    public static void Main()
    {
        string resposta = "s";
        int opcao;
        Paciente pacienteEmAtendimento = new Paciente();

        Console.ResetColor();

        Console.WriteLine("======== HealthConnect ========");
        do
        {
            Console.WriteLine("-------- MENU --------");
            Console.WriteLine("1 - Adicionar Paciente \n 2 - Ver Fila Atual \n 3 - Chamar Próximo \n 4 - Sair");
            Console.Write("Digite a opção desejada: ");
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        pacienteEmAtendimento.AdicionarPaciente();
                        break;
                    case 2:
                        pacienteEmAtendimento.VerificarListaAtendimento();
                        break;
                    case 3:
                        pacienteEmAtendimento.ChamarProximo();
                        break;
                    case 4:
                        resposta = "n";
                        Console.WriteLine("Programa Finalizado");
                        break;
                    default:
                        Console.WriteLine("Opção Incorreta. Digite um número entre 1 e 4.");
                        break;
                }
            } else {
                Console.WriteLine("Opção Incorreta. Digite um número");
            }

        } while (resposta == "s");
        
    }
}
