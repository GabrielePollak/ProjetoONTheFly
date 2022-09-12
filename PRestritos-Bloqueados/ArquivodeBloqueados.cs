using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRestritos_Bloqueados
{
    public class ArquivodeBloqueados
    {
        public string CNPJ { get; set; }

        public ArquivodeBloqueados Proximo { get; set; }

        public List<ArquivodeRestritos> Filhos { get; set; }

        public ArquivodeBloqueados(string CNPJ)
        {

            this.CNPJ = CNPJ;

            this.Proximo = null;
        }

        public override string ToString()
        {
            return "\nDados Restritos:\nCPF:" + CNPJ;
        }

        public bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;
            string digito, tempCnpj;

            //limpa caracteres especiais e deixa em minusculo
            cnpj = cnpj.ToLower().Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            cnpj = cnpj.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            cnpj = cnpj.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            cnpj = cnpj.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            cnpj = cnpj.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            cnpj = cnpj.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            cnpj = cnpj.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");

            // Se vazio
            if (cnpj.Length == 0)
                return false;

            //Se o tamanho for < 14 então retorna como falso
            if (cnpj.Length != 14)
                return false;

            // Caso coloque todos os numeros iguais
            switch (cnpj)
            {

                case "00000000000000":

                    return false;

                case "11111111111111":

                    return false;

                case "22222222222222":

                    return false;

                case "33333333333333":

                    return false;

                case "44444444444444":

                    return false;

                case "55555555555555":

                    return false;

                case "66666666666666":

                    return false;

                case "77777777777777":

                    return false;

                case "88888888888888":

                    return false;

                case "99999999999999":

                    return false;
            }

            tempCnpj = cnpj.Substring(0, 12);

            //cnpj é gerado a partir de uma função matemática, logo para validar, sempre irá utilizar esse calculo 
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);

          





        }



    }
}
