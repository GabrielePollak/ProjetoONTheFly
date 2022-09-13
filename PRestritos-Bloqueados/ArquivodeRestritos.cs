using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRestritos_Bloqueados
{
    internal class ArquivodeRestritos
    {
      
        public string CPF { get; set; }
      
        public ArquivodeRestritos Proximo { get; set; }

        public List<ArquivodeRestritos> Filhos { get; set; }

        public  ArquivodeRestritos(string CPF)
        {
           
            this.CPF = CPF;
            
            this.Proximo = null;
        }

        public override string ToString()
        {
            return "\nDados Restritos:\nCPF:" + CPF;
        }
        public void GravarArquivoRestritos(List<ArquivodeRestritos> arquivodeRestritos)
        {
            Console.WriteLine("Iniciando a Gravação de Dados...");
            try
            {
                StreamWriter sw = new StreamWriter(@"c:\Users\Gabriele\source\repos\PRestritos-Bloqueados\Restritos.dat");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                                                                                                                             //sw.WriteLine("Treinamento de C#");  //Escreve uma linha no Arquivo
                                                                                                                             //sw.WriteLine("maria;araraquara;190;contato;"); //Exemplo de escrita - formato da escrita será de acordo com a necessidade do projeto
                foreach (ArquivodeRestritos i in arquivodeRestritos)
                {
                    sw.WriteLine(i.CPF);
                }
                sw.Close();  // Comando para Fechar o Arquivo
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }
            Console.WriteLine("FIM DA GRAVAÇÃO");
            Console.ReadKey();

        }
       
        
        public void CarregarArquivoRestritos(List<ArquivodeRestritos> arquivodeRestritos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"c:\Users\Gabriele\source\repos\PRestritos-Bloqueados\Bloqueados.dat"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //tempo = new DateTime(int.Parse(line.Substring(14, 4)), int.Parse(line.Substring(12, 2)), int.Parse(line.Substring(10, 2)), int.Parse(line.Substring(20, 2)), int.Parse(line.Substring(18, 2)), int.Parse(line.Substring(18, 2)));
                        arquivodeRestritos.Add(new ArquivodeRestritos
                            (
                            line.Substring(0, 11)
                            ));
                    }

                    Console.WriteLine("\nArquivo carregado com sucesso!");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("\nException: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        public static string ReadCPF(string text)
        {
            string cpfString;
            long cpfLong;
            int digVerificador, v1, v2, aux;
            int[] digitosCPF = new int[9];
            bool digitosIguais = false;

            do
            {
                Console.Write(text);
                cpfString = Console.ReadLine();
                while (!long.TryParse(cpfString, out cpfLong))
                {
                    Console.Write("Digite um CPF valido!\n{0}", text);
                    cpfString = Console.ReadLine();
                }
                digVerificador = (int)(cpfLong % 100);
                cpfLong /= 100;
                for (int i = 0; i < 9; i++)
                {
                    aux = (int)cpfLong % 10;
                    digitosCPF[i] = aux;
                    cpfLong /= 10;
                }
                digitosIguais = false;
                for (int i = 0; i < digitosCPF.Length; i++)
                {
                    if (i == digitosCPF.Length - 1)
                    {
                        Console.WriteLine("O CPF nao segue as regras de validacao da Receita Federal!");
                        digitosIguais = true;
                        break;
                    }
                    if (digitosCPF[i] != digitosCPF[i + 1]) break;
                }
                if (digitosIguais) continue;
                v1 = v2 = 0;
                for (int i = 0; i < 9; i++)
                {
                    v1 += digitosCPF[i] * (9 - i);
                    v2 += digitosCPF[i] * (8 - i);
                }
                v1 = (v1 % 11) % 10;
                v2 += v1 * 9;
                v2 = (v2 % 11) % 10;
                if (v1 * 10 + v2 == digVerificador) return cpfString;
                else Console.WriteLine("O CPF nao segue as regras de validacao da Receita Federal!");
            } while (true);
        }

    }
}
