using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXS.Entities
{
    public class Valor
    {
        public int Id { get; set; }
        public int VariavelId { get; set; }
        public string ValorReal { get; set; }

        public Valor(int _variavel, string _valor) 
        {
            this.VariavelId = _variavel;
            this.ValorReal = _valor;
        }
    }
}
