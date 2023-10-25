using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXS.Entities
{
    public class Regra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UserQuery { get; set; }
        public string KBQuery { get; set; }
        public int IdVariavelSaida { get; set; }
        public int IdValorSaida { get; set; }
        public SqlDecimal FatorConfiabilidade { get; set; }
        public List<RuleCondition> Conditions { get; set; }

        //Construtor para "criação"
        public Regra(string _user, string _knowledge, int _varsaida, int _valsaida)
        {
            this.UserQuery = _user;
            this.KBQuery = _knowledge;
            this.IdVariavelSaida = _varsaida;
            this.IdValorSaida = _valsaida;
            this.Conditions = new List<RuleCondition>();
        }

        //Consrtutor para "resgate"
        public Regra(int _id, string _nome, string _uquery, string _kquery, int _idvar, int _idval, decimal _conf)
        {
            this.Id = _id;
            this.Nome = _nome;
            this.UserQuery = _uquery;
            this.KBQuery = _kquery;
            this.IdVariavelSaida = _idvar;
            this.IdValorSaida = _idval;
            this.FatorConfiabilidade = _conf;
            this.Conditions = new List<RuleCondition>();
        }

        public void setUserQuery(string uQuery)
        { 
            UserQuery = uQuery;
        }
        public void setKBQuery(string kQuery)
        { 
            KBQuery = kQuery;
        }
    }
}
