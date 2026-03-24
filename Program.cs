using System;

namespace desafio1;

public class Program()
{
    public static void Main()
    {
        string? nomePaciente, idadePacienteString, dorPacienteString; 
        string resposta = "s";
        int idadePaciente, dorPaciente;
        int opcao = 0;
        int contadorAmarelo =0;
        int contadorVerde =0;
        int i = 0;

        List<string> listaTriagem = new List<string>();
        List<string> listaVermelha = new List<string>();
        List<string> listaAmarela = new List<string>();
        List<string> listaVerde = new List<string>();
        
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("======== HealthConnect ========");
        do{
            Console.WriteLine("-------- MENU --------");
            Console.WriteLine("1 - Adicionar Paciente \n 2 - Ver Fila Atual \n 3 - Chamar Próximo \n 4 - Sair");
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o nome do paciente: ");
                    nomePaciente = Console.ReadLine()?? "";
                    Console.WriteLine("Digite a idade do paciente: ");
                    idadePacienteString = Console.ReadLine();

                    if(int.TryParse(idadePacienteString, out idadePaciente))
                    {
                        if(idadePaciente>=0 && idadePaciente < 200)
                        {
                            Console.WriteLine("Em uma escala de 0 a 10, digite o nível de dor do paciente: ");
                            dorPacienteString = Console.ReadLine();
                            if(int.TryParse(dorPacienteString, out dorPaciente))
                            {
                                if (dorPaciente>=9 || idadePaciente>=80)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Prioridade Alta");
                                    listaVermelha.Add(nomePaciente);
                                }
                                else if(dorPaciente>=5 && dorPaciente<=8)
                                {
                                    Console.ForegroundColor=ConsoleColor.Yellow;
                                    Console.WriteLine("Observação de Triagem");
                                    listaAmarela.Add(nomePaciente);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Aguardar Triagem");
                                    listaVerde.Add(nomePaciente);
                                }
                                Console.ForegroundColor = ConsoleColor.White;

                                foreach (var nome in listaVermelha)
                                {
                                    listaTriagem.Add(nome); // lista sendo preenchida no topo
                                }

                                while(listaAmarela.Count()>0 && listaVerde.Count()>0){
                                    while (listaAmarela.Count() > 0 && contadorAmarelo<2)
                                    {
                                        listaTriagem.Add(listaAmarela[i]);
                                        listaAmarela.RemoveAt(i);
                                        i++;
                                        contadorAmarelo++;
                                    }
                                    if (listaVerde.Count() > 0)
                                    {
                                        listaTriagem.Add(listaVerde[contadorVerde]);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Dor do paciente não é um número");
                            }
                        }  
                    }
                    else
                    {
                        Console.WriteLine("A idade inserida não é um número!");
                    }
                    break;
                case 2:
                    int contador = 0;
                    
                    foreach (var nome in listaTriagem)
                    {
                        contador++;
                        Console.WriteLine($"Paciente {contador}: {nome}");
                    }
                    break;
                case 3:
                    Console.WriteLine($"Paciente {listaTriagem[0]} se dirigir ao consultorio.");
                    listaTriagem.RemoveAt(0);
                    break;
                case 4:
                    resposta = "n";
                    Console.WriteLine("Programa Finalizado");
                    break;
                default:
                    Console.WriteLine("Opção Incorreta");
                    break;
            }
        }while(resposta == "s");
    }
}
