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
    }
}
