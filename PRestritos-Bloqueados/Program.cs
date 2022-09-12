using System;

namespace PRestritos_Bloqueados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaRestritos Minhalista = new ListaRestritos();
            Minhalista.Push(new ArquivodeRestritos("123.321.121-12"));

            //Lista dos CNPJs

            ListadeBloqueados Minhalista1 = new ListadeBloqueados();
            Minhalista1.Push(new ArquivodeBloqueados("67.298.128/0001-54"));

            //Melhorias:
            //Questão dos 11 digitos;
            //Questão do arquivo texto;
            //Dois registros com mesmo atributo;
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
                        Console.WriteLine("\nQual destas ações deseja fazer? : \n1-Imprimir lista de restritos.\n2-Localizar um CPF.\n3-Remover CPF.\n4-Cadstrar um CPF.\n0-SAIR!\nOpção: ");
                        opc = int.Parse(Console.ReadLine());

                        if (opc == 1)
                        {
                            Minhalista.Print();

                        }
                        else if (opc == 2)
                        {
                            Console.Clear();

                            Console.Write("\nInforme o CPF que deseja localizar: ");
                            string CPF = Console.ReadLine();
                            Minhalista.Find(CPF);

                        }
                        else if (opc == 3)
                        {
                            Console.Write("\nInforme o CPF que deseja remover: ");
                            string cpfremovido = Console.ReadLine();
                            Minhalista.pop(cpfremovido);

                            Console.Clear();

                            Minhalista.Print();
                        }
                        else if (opc == 4)
                        {
                            Console.WriteLine("Informe o CPF para o cadastro: ");
                            string CPF = Console.ReadLine();

                            Minhalista.Push(new ArquivodeRestritos(CPF));
                            opc = -1;

                            Console.WriteLine("CPF cadastrado com sucesso!");

                        }
                        else if (opc == 0)
                        {
                            break;//arrumar isso
                        }
                        else
                            Console.WriteLine("Opção inexistente!");

                    } while (true);


                }
                else if (opc == 2)
                {
                    do
                    {
                        Console.WriteLine("                                     <<<<<Bem-vindo(a) ao menu de CNPJs restritos:>>>>>                        ");
                        Console.WriteLine("\nQual destas ações deseja fazer? : \n1-Imprimir lista de restritos.\n2-Localizar um CNPJ.\n3-Remover CNPJ.\n4-Cadstrar um CNPJ.\nOpção: ");
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
                        string CNPJ = Console.ReadLine();
                        Minhalista1.Find(CNPJ);

                    }
                    if (opc == 3)
                    {
                        Console.Write("\nInforme o CNPJ que deseja remover: ");
                        string cnpjremovido = Console.ReadLine();
                        Minhalista1.pop(cnpjremovido);

                        Console.Clear();

                        Minhalista1.Print();
                    }
                    if (opc == 4)
                    {
                        Console.WriteLine("Informe o CNPJ para o cadastro: ");
                        string CNPJ = Console.ReadLine();

                        if(Minhalista1.Vali)
                        {

                        }
                        


                        Minhalista1.Push(new ArquivodeBloqueados(CNPJ));
                        opc = -1;

                        Console.WriteLine("CNPJ cadastrado com sucesso!");

                    }
                    else if (opc == 0)
                    {
                        break; //arrumar isso
                    }
                    else
                        Console.WriteLine("Opção inexistente!");
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

