using System;

namespace desafio1;

public class Program()
{
    public static void Main()
    {
        string? nomePaciente, idadePacienteString, dorPacienteString;
        string resposta = "s";
        int idadePaciente, dorPaciente;
        int opcao;
        int contadorAmarelo = 0;
        int contadorVerde = 0;
        int i = 0;

        List<string> listaTriagem = new List<string>();
        List<string> listaVermelha = new List<string>();
        List<string> listaAmarela = new List<string>();
        List<string> listaVerde = new List<string>();

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("======== HealthConnect ========");
        do
        {
            Console.WriteLine("-------- MENU --------");
            Console.WriteLine("1 - Adicionar Paciente \n 2 - Ver Fila Atual \n 3 - Chamar Próximo \n 4 - Sair");
            Console.Write("Digite a opção desejada: ");
            string? opcaostring = Console.ReadLine();
            if (int.TryParse(opcaostring, out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do paciente: ");
                        nomePaciente = Console.ReadLine() ?? "";
                        Console.WriteLine("Digite a idade do paciente: ");
                        idadePacienteString = Console.ReadLine();

                        if (int.TryParse(idadePacienteString, out idadePaciente))
                        {
                            if (idadePaciente >= 0 && idadePaciente < 200)
                            {
                                Console.WriteLine("Em uma escala de 0 a 10, digite o nível de dor do paciente: ");
                                dorPacienteString = Console.ReadLine();
                                if (int.TryParse(dorPacienteString, out dorPaciente))
                                {
                                    if (dorPaciente >= 9 || idadePaciente >= 80)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Prioridade Alta");
                                        listaVermelha.Add(nomePaciente);
                                    }
                                    else if (dorPaciente >= 5 && dorPaciente <= 8)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
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
                        listaTriagem = new List<string>();
                        i = 0;
                        int contadorTriagem = 1;
                        contadorAmarelo = 0;
                        contadorVerde = 0;

                        //adiciona todos os vermelhos
                        foreach (var nome in listaVermelha)
                        {
                            listaTriagem.Add(nome); // lista sendo preenchida no topo
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{contadorTriagem} - {nome} - Prioridade Vermelha");
                            Console.ForegroundColor = ConsoleColor.White;
                            contadorTriagem++;
                        }
                        while ((listaAmarela.Count > 0 && listaAmarela.Count() > i) || (listaVerde.Count > 0 && listaVerde.Count()>contadorVerde))
                        {
                            while (listaAmarela.Count() > 0 && contadorAmarelo < 2 && listaAmarela.Count() > i)
                            {
                                listaTriagem.Add(listaAmarela[i]);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"{contadorTriagem} - {listaAmarela[i]} - Prioridade Amarela");
                                Console.ForegroundColor = ConsoleColor.White;
                                i++;
                                contadorAmarelo++; 
                                contadorTriagem++;
                            }
                            if (listaVerde.Count() > 0 && listaVerde.Count()>contadorVerde)
                            {
                                listaTriagem.Add(listaVerde[contadorVerde]);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{contadorTriagem} - {listaVerde[contadorVerde]} - Prioridade Verde");
                                Console.ForegroundColor = ConsoleColor.White;
                                contadorVerde++;
                                contadorAmarelo = 0;
                                contadorTriagem++;
                            }
                        }


                        int contador = 0;

                        foreach (var nome in listaTriagem)
                        {
                            contador++;
                            Console.WriteLine($"Paciente {contador}: {nome}");
                        }
                        break;
                    case 3:

                        //preenche a lista de triagem seguindo a ordem de prioridade
                        listaTriagem = new List<string>();
                        i = 0;
                        contadorTriagem = 1;
                        contadorAmarelo = 0;
                        contadorVerde = 0;

                        //adiciona todos os vermelhos
                        foreach (var nome in listaVermelha)
                        {
                            listaTriagem.Add(nome); // lista sendo preenchida no topo
                        }

                        while (listaAmarela.Count > 0 || listaVerde.Count > 0)
                        {
                            while (listaAmarela.Count() > 0 && contadorAmarelo < 2)
                            {
                                listaTriagem.Add(listaAmarela[i]);
                                i++;
                                contadorAmarelo++;
                            }
                            if (listaVerde.Count() > 0)
                            {
                                listaTriagem.Add(listaVerde[contadorVerde]);
                                contadorAmarelo = 0;
                            }

                        }


                        Console.WriteLine($"Paciente {listaTriagem[0]} se dirigir ao consultorio.");


                        //remover o paciente da lista de triagem e de uma das listas de prioridade
                        if (listaAmarela.Contains(listaTriagem[0]))
                        {
                            listaAmarela.Remove(listaTriagem[0]);
                        }
                        else if (listaVermelha.Contains(listaTriagem[0]))
                        {
                            listaVermelha.Remove(listaTriagem[0]);
                        }
                        else
                        {
                            listaVerde.Remove(listaTriagem[0]);
                        }
                        listaTriagem.RemoveAt(0);

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
