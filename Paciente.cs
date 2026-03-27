using System;

namespace desafio1;

public class Paciente()
{
    public string? nomePaciente;
    public string? idadePacienteString;
    public int idadePaciente;
    public int nivelDor;
    public string? prioridade;
    List<string> listaVermelha = new List<string>();
    List<string> listaAmarela = new List<string>();
    List<string> listaVerde = new List<string> ();
    List<string> listaPacientes = new List<string>();
    List<string> listaAtendidos = new List<string>();

    //Métodos (ações que pertencem à minha classe)
    //Adicionar paciente
    public void AdicionarPaciente()
    {
        Console.WriteLine("Digite o nome do paciente: ");
        nomePaciente = Console.ReadLine() ?? "";
        Console.WriteLine("Digite a idade do paciente: ");
        idadePacienteString = Console.ReadLine();
        if(int.TryParse(idadePacienteString, out idadePaciente))
        {
            Console.WriteLine("Digite o nível de dor do paciente: ");
            if(int.TryParse(Console.ReadLine(), out nivelDor))
            {
                ClassificarPrioridade(nomePaciente, idadePaciente, nivelDor);
            }
            else
            {
                Console.WriteLine("Dor não identificada. Digite um número.");
            }
        }
        else
        {
            Console.WriteLine("A idade não é um número.");
        }

    }

    public void ClassificarPrioridade(string nomePaciente, int idadePaciente, int nivelDor)
    {
        
        //se dor for maior que 9 ou idade maior que 80 - vermelho
        if(nivelDor>=9 || idadePaciente >= 80)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Prioridade Alta - Pulseira Vermelha");
            listaVermelha.Add(nomePaciente);
            Console.ResetColor();
        }
        //se dor for entre 5 e 8 - amarelo
        else if (nivelDor >= 5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Prioridade Média - Pulseira Amarela");
            listaAmarela.Add(nomePaciente);
            Console.ResetColor();
        }
        //caso contrário - verde
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Prioridade Baixa - Pulseira Verde");
            listaVerde.Add(nomePaciente);
            Console.ResetColor();
        }   
    }

    public void ListarPacientes()
    {
        int contAmarelo = 0;
        int contVerde = 0;
        listaPacientes = new List<string>();

        // PRECISO VERIFICAR SE JÁ TEVE ATENDIMENTO DE MAIS DE 2 PESSOAS

        if (listaAtendidos.Count() < 2)
        {
            foreach (var nome in listaVermelha)
            {
                listaPacientes.Add(nome);
            }
            while(contAmarelo<listaAmarela.Count() || contVerde < listaVerde.Count())
            {
                int i = 0;
                while (contAmarelo<listaAmarela.Count() && i<2)
                {
                    listaPacientes.Add(listaAmarela[contAmarelo]);
                    contAmarelo++;
                    i++;
                }
                listaPacientes.Add(listaVerde[contVerde]);
                contVerde++;
            }
        }
        else
        {
            //preciso verificar os dois últimos atendimentos, 
            string ultimoAtendimentoPrioridade = listaAtendidos[listaAtendidos.Count()-1]; //10-1 = 9 (ultima posição)
            string penultimoAtendimentoPrioridade = listaAtendidos[listaAtendidos.Count()-2];// 10-2 = 8 (penultima posição)
            if (listaVermelha.Count() > 0)
            {
                //adiciono vermelho
                listaPacientes.Add(listaVermelha[0]);
            }
            else
            {
                if (ultimoAtendimentoPrioridade=="amarelo" && penultimoAtendimentoPrioridade=="amarelo")
                {
                    
                }
                else
                {
                    
                }
                
            }
            // caso não tenha vermelhos:
            // se forem 2 amarelos, eu coloco um verde 
            // caso tenha só um amarelo eu coloco outro amarelo 
            // caso tenha vermelho, eu coloco um vermelho
        }
        
    }
    public void ChamarProximo()
    {
        //SABER O PRIMEIRO DA FILA
        ListarPacientes(); //sem erros
        //localização do próximo paciente -> listaPacientes[0];
        //MOSTRAR NA TELA QUEM É "SR.(A) FULANO DIRIGIR-SE AO CONSULTÓRIO"
        Console.WriteLine($"Sr.(a) {listaPacientes[0]} Dirigir-se ao Consultório");
        //REMOVER ESSE PACIENTE DA LISTA
        listaAtendidos.Add(listaPacientes[0]);
        ExcluirPaciente();
    }
    public void ExcluirPaciente()
    {
        //remover da lista de prioridades; Preciso encontrar em qual lista está e remover.
        if (listaVermelha.Contains(listaPacientes[0]))
        {
            listaVermelha.RemoveAt(0);
        }
        else if (listaAmarela.Contains(listaPacientes[0]))
        {
            listaAmarela.RemoveAt(0);
        }
        else
        {
            listaVerde.RemoveAt(0);
        }
        //remove da listaPacientes
        listaPacientes.RemoveAt(0);
    }
    public void VerificarListaAtendimento()
    {
        ListarPacientes();
        int i=1;
        foreach (var nome in listaPacientes)
        {
            Console.WriteLine($"{i} - {nome}");
            i++;
        }
    }

}