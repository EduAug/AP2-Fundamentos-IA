using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXS.Entities
{
    public class Variavel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Valores { get; set; }

        public Variavel(string _nome, string _tipo, string _valores)
        {
            Nome = _nome;              //Whatever
            Tipo = _tipo;              //"Bool" ou "Num", dependendo irá chamar um construtor da classe Valor (ou regra?)
            Valores = _valores;        //Nomes dos valores
        }
        public Variavel(int _id, string _nome, string _tipo, string _valores)
        {                           //Construtor "para leitura"
            Id = _id;
            Nome = _nome;
            Tipo = _tipo;
            Valores = _valores;
        }
    }
}
