using System;
using System.Collections.Generic;

namespace PRestritos_Bloqueados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaRestritos Minhalista = new ListaRestritos();
            Minhalista.Push(new ArquivodeRestritos("123.321.121-12"));
            ArquivodeBloqueados arquivodeBloqueados = new ArquivodeBloqueados(null);
            ArquivodeRestritos arquivodeRestritos = new ArquivodeRestritos(null);
            List<ListadeBloqueados> listaBloqueados = new List<ListadeBloqueados>();
            List<ListaRestritos> listaRestritos = new List<ListaRestritos>();
            string CPF;
            string CNPJ;

 

            ListadeBloqueados Minhalista1 = new ListadeBloqueados();
            Minhalista1.Push(new ArquivodeBloqueados("67.298.128/0001-54"));

            //Melhorias:
            
            //Questão do arquivo texto;
            
            int opc = 0;

            do
            {
                  
                Console.WriteLine("                                        <<<<Bem-Vindo(a) a lista de bloqueados e restritos!>>>>                   ");
                Console.WriteLine("\nQual das listas deseja acessar: \n1-CPFs restritos.\n2-CNPJs restritos.\n0-SAIR!\nOpções: ");
                opc = int.Parse(Console.ReadLine());


                if (opc == 1)
                {
                    do
                    {
                        Console.WriteLine("                                     <<<<<Bem-vindo(a) ao menu de CPFs restritos:>>>>>                        ");
                        Console.WriteLine("\nQual destas ações deseja fazer? : \n1-Imprimir lista de restritos.\n2-Localizar um CPF.\n3-Remover CPF.\n4-Cadastrar um CPF.\n0-SAIR!\nOpção: ");
                        opc = int.Parse(Console.ReadLine());

                        if (opc == 1)
                        {
                            Minhalista.Print();

                        }
                        if (opc == 2)
                        {
                            Console.Clear();

                            Console.Write("\nInforme o CPF que deseja localizar: ");
                            CPF = Console.ReadLine();
                            Minhalista.Find(CPF);

                        }
                        if (opc == 3)
                        {
                            Console.Write("\nInforme o CPF que deseja remover: ");
                            string cpfremovido = Console.ReadLine();
                            Minhalista.pop(cpfremovido);

                            Console.Clear();

                            Minhalista.Print();
                        }
                        if (opc == 4)
                        {
                                
                            CPF = ArquivodeRestritos.ReadCPF("Informe o cpf sem traço ou ponto: : ");

                            Minhalista.Push(new ArquivodeRestritos(CPF));
                            opc = -1;

                            Console.WriteLine("CPF cadastrado com sucesso!");

                        }
                        else if (opc == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Finalizando...");
                            return;
                        }
                        else
                            Console.WriteLine("Opção inexistente!");

                    } while (true);


                }
                if (opc == 2)
                {
                    do
                    {
                        Console.WriteLine("                                     <<<<<Bem-vindo(a) ao menu de CNPJs restritos:>>>>>                        ");
                        Console.WriteLine("\nQual destas ações deseja fazer? : \n1-Imprimir lista de restritos.\n2-Localizar um CNPJ.\n3-Remover CNPJ.\n4-Cadastrar um CNPJ.\n0-SAIR!\nOpção: ");
                        opc = int.Parse(Console.ReadLine());
                    } while (opc < 1 || opc > 4);

                    if (opc == 1)
                    {
                        Minhalista1.Print();

                    }
                    if (opc == 2)
                    {
                        Console.Clear();

                        Console.Write("\nInforme o CNPJ que deseja localizar: ");
                        CNPJ = Console.ReadLine();
                        Minhalista1.Find(CNPJ);

                    }
                    if (opc == 3)
                    {
                        Console.Write("\nInforme o CNPJ que deseja remover: ");
                        string cnpjremovido = Console.ReadLine();
                        Minhalista1.pop(cnpjremovido);

                        Console.Clear();

                        
                    }
                    if (opc == 4)
                    {
                        do
                        {
                            Console.WriteLine("Informe o CNPJ para o cadastro (XX. XXX. XXX/0001-XX): ");
                            CNPJ = Console.ReadLine();

                            if (!arquivodeBloqueados.ValidarCnpj(CNPJ))
                            {
                                Console.WriteLine("CPNJ digitado é invalido!");
                            }

                        } while (!arquivodeBloqueados.ValidarCnpj(CNPJ));
                        
                        


                        Minhalista1.Push(new ArquivodeBloqueados(CNPJ));
                        opc = -1;

                        Console.WriteLine("CNPJ cadastrado com sucesso!");

                    }
                    else if (opc == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Finalizando...");
                        return;
                    }
                    else
                        Console.WriteLine("Opção inexistente!");
                }
                else if (opc == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Finalizando...");
                    return;
                }
                else
                    Console.WriteLine("Opção inexistente!");

            } while (true);

           
           


        

            //Melhorias:
            //Questão dos 11 digitos;
            //Questão do arquivo texto;
            //voltar ao menu;
            //Dois registros com mesmo atributo;
            

            


           

























        }
           


















    }
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}

