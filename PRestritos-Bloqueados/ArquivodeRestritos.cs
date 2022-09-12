using System;
using System.Collections.Generic;
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

        public static string ReadCPF(string text)
        {
            string cpfString;
            long cpfLong;
            int digVerificador, v1 = 0, v2 = 0, aux;
            int[] digitosInvertidosCPF = new int[9];
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
                    digitosInvertidosCPF[8 - i] = aux;
                    cpfLong /= 10;
                }
                v1 = v2 = 0;
                for (int i = 0; i < 9; i++)
                {
                    v1 += (int)digitosInvertidosCPF[i] * (9 - i);
                    v2 += (int)digitosInvertidosCPF[i] * (8 - i);
                }
                v1 = (v1 % 11) % 10;
                v2 += v1 * 9;
                v2 = (v2 % 11) % 10;
                if (v2 * 10 + v1 == digVerificador) return cpfString;
                else Console.WriteLine("O CPF nao segue as regras de validacao da Receita Federal!");
            } while (true);
        }
        
    }
}
