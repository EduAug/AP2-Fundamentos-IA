using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using System.Diagnostics;
using EXS.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;

public class DatabaseManager
{
    private static DatabaseManager Instancia;
    private SQLiteConnection conne;

    private DatabaseManager()
    {
        string dbFilePath = Directory.GetCurrentDirectory();
        string fullFile = System.IO.Path.Join(dbFilePath, "expSysKnoBas.db");
        string connectionString = $"Data Source={fullFile};Version=3;";
        conne = new SQLiteConnection(connectionString);
        conne.Open();

        CreateTables();
    }

    public static DatabaseManager Instance
    {
        get
        {
            if (Instancia == null)
            {
                Instancia = new DatabaseManager();      // Uma forma super complicada e exagerada de criar uma... instancia dessa classe
            }
            return Instancia;
        }
    }

    public SQLiteConnection Connection
    {
        get { return conne; }
    }

    public void CloseConnection()
    {
        if (conne != null && conne.State == ConnectionState.Open)
        {
            conne.Close();
        }
    }

    private void CreateTables()
    {
        string createTableStringVariables = "CREATE TABLE IF NOT EXISTS Variaveis(" +
                                            "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                            "Nome TEXT NOT NULL UNIQUE," +
                                            "Tipo TEXT NOT NULL," +
                                            "Valores TEXT" +
                                            ");";
        
        string createTableStringValores =   "CREATE TABLE IF NOT EXISTS ValoresVariaveis("+
                                            "Id INTEGER PRIMARY KEY AUTOINCREMENT,"+
                                            "VariavelId INTEGER NOT NULL,"+
                                            "Valor TEXT NOT NULL UNIQUE,"+
                                            "FOREIGN KEY(VariavelId) REFERENCES Variaveis(Id) ON DELETE CASCADE"+
                                            ");";

        string createTableStringRegras =    "CREATE TABLE IF NOT EXISTS Regras("+
                                            "Id INTEGER PRIMARY KEY AUTOINCREMENT,"+
                                            "Nome TEXT NOT NULL UNIQUE,"+
                                            "QueryForUser TEXT NOT NULL,"+
                                            "QueryForKnowledge TEXT NOT NULL,"+
                                            "VariavelSaidaId INTEGER,"+
                                            "ValorSaidaId INTEGER,"+
                                            "FatorConfiabilidade DECIMAL,"+
                                            "FOREIGN KEY (VariavelSaidaId) REFERENCES Variaveis(Id) ON DELETE SET NULL,"+
                                            "FOREIGN KEY (ValorSaidaId) REFERENCES ValoresVariaveis(Id) ON DELETE SET NULL"+
                                            ");";
        using (SQLiteCommand dbcmd = new SQLiteCommand(createTableStringVariables, conne))
        { 
            dbcmd.ExecuteNonQuery();
        }
        using (SQLiteCommand dbcmd = new SQLiteCommand(createTableStringRegras, conne))
        {
            dbcmd.ExecuteNonQuery();
        }
        using (SQLiteCommand dbcmd = new SQLiteCommand(createTableStringValores, conne))
        {
            dbcmd.ExecuteNonQuery();
        }
    }

    public void InsertVariable(Variavel insertVar)
    {
        string queryForInsert = "INSERT INTO Variaveis (Nome, Tipo) VALUES (@Nome,@Tipo)";

        using (SQLiteCommand dbcmd = new SQLiteCommand(queryForInsert, conne))
        {
            dbcmd.Parameters.AddWithValue("@Nome", insertVar.Nome);
            dbcmd.Parameters.AddWithValue("Tipo", insertVar.Tipo);

            dbcmd.ExecuteNonQuery();
        }
    }

    public void InsertValue(Valor insertValue)
    {
        string queryForInsert = "INSERT INTO ValoresVariaveis (VariavelId, Valor) VALUES (@VariavelId,@Valor)";

        using (SQLiteCommand dbcmd = new SQLiteCommand(queryForInsert, conne))
        {
            dbcmd.Parameters.AddWithValue("@VariavelId", insertValue.VariavelId);
            dbcmd.Parameters.AddWithValue("@Valor", insertValue.ValorReal);

            dbcmd.ExecuteNonQuery();
        }

        string queryForUpdatingValuesOnVariable = "UPDATE Variaveis SET Valores = COALESCE(Valores || ',', '') || @Valor WHERE Id = @VariavelId";
        using (SQLiteCommand dbcmd = new SQLiteCommand(queryForUpdatingValuesOnVariable, conne))
        {
            dbcmd.Parameters.AddWithValue("@VariavelId", insertValue.VariavelId);
            dbcmd.Parameters.AddWithValue("@Valor", insertValue.ValorReal);

            dbcmd.ExecuteNonQuery();
        }
    }

    public void InsertRule(Regra insertRule)
    {
        string queryForInsert = "INSERT INTO Regras (Nome, QueryForUser, QueryForKnowledge, VariavelSaidaId, ValorSaidaId, FatorConfiabilidade) VALUES (@nome, @queryUser, @queryKnow, @varId, @valId, @fatorConf)";

        using (SQLiteCommand dbcmd = new SQLiteCommand(queryForInsert, conne))
        {
            dbcmd.Parameters.AddWithValue("@nome",insertRule.Nome);
            dbcmd.Parameters.AddWithValue("@queryUser", insertRule.UserQuery);
            dbcmd.Parameters.AddWithValue("@queryKnow", insertRule.KBQuery);
            dbcmd.Parameters.AddWithValue("@varId", insertRule.IdVariavelSaida);
            dbcmd.Parameters.AddWithValue("@valId", insertRule.IdValorSaida);
            dbcmd.Parameters.AddWithValue("@fatorConf", insertRule.FatorConfiabilidade);

            dbcmd.ExecuteNonQuery();
        }
    }

    public List<(int,string)> GetVarNamesIds()
    {
        List<(int _Id, string _Nome)> dadosRetorno = new List<(int _Id, string _Nome)>();

        string queryToSelectValueData = "SELECT Id, Nome FROM Variaveis";

        using (SQLiteCommand comd = new SQLiteCommand(queryToSelectValueData, conne))
        { 
            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int varId = Convert.ToInt32(rdr["Id"]);
                    string varName = rdr["Nome"].ToString();
                    dadosRetorno.Add((varId,varName));
                }
            }
        }
        return dadosRetorno;
    }

    public List<string> GetVarValues(string varOriginName)
    {
        List<string> valoresRetorno = new List<string>();
        string queryToGetValueNamesBasedOffVarName =
            "SELECT Valores FROM Variaveis WHERE Nome = @NomeVariavel";

        using (SQLiteCommand comd = new SQLiteCommand(queryToGetValueNamesBasedOffVarName, conne))
        {
            comd.Parameters.AddWithValue("@NomeVariavel", varOriginName);
            using (SQLiteDataReader rdr = comd.ExecuteReader())
            { 
                if(rdr.Read()) 
                {
                    string valNames = rdr["Valores"].ToString();

                    if (!string.IsNullOrWhiteSpace(valNames))
                    {
                        valoresRetorno = valNames.Split(',').Select(x => x.Trim()).ToList();
                    }
                }
            }
        }
        return valoresRetorno;
    }

    public List<string> GetVarValues(int varId)
    {
        List<string> valoresRetorno = new List<string>();
        string queryToGetValueNamesBasedOffVarId =
            "SELECT Valores FROM Variaveis WHERE Id = @VarId";

        using (SQLiteCommand comd = new SQLiteCommand(queryToGetValueNamesBasedOffVarId, conne))
        {
            comd.Parameters.AddWithValue("@VarId", varId);
            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    string valNames = rdr["Valores"].ToString();
                    valoresRetorno = valNames.Split(',').Select(x => x.Trim()).ToList();
                }
            }
        }
        return valoresRetorno;
    }

    public int GetVarIdFromValName(string valName)
    { 
        int valId = -1; //-1 não 0 uma vez que 0 pode ser um índice settado por padrão
        string queryToGetValueIdBasedOffValName = "SELECT VariavelId FROM ValoresVariaveis WHERE Valor = @ValName";

        using(SQLiteCommand comd = new SQLiteCommand(queryToGetValueIdBasedOffValName, conne))
        {
            comd.Parameters.AddWithValue("@ValName", valName);

            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if(rdr.Read())
                {
                    valId = Convert.ToInt32(rdr["VariavelId"]);
                }
            }
        }
        return valId;
    }

    public void UpdateVariable(int varId, string varName)
    {
        string queryToUpdateVarName = "UPDATE Variaveis SET Nome = @novoNome WHERE Id = @varId";
        using(SQLiteCommand comd = new SQLiteCommand( queryToUpdateVarName, conne))
        {
            comd.Parameters.AddWithValue("@novoNome", varName);
            comd.Parameters.AddWithValue("@varId", varId);

            comd.ExecuteNonQuery();
        }
    }

    public void UpdateValue_name(string oldValName, string newValName)
    {
        string queryToUpdateValueName = "UPDATE ValoresVariaveis SET Valor = @newValName WHERE Valor = @oldValName";
        using (SQLiteCommand comd = new SQLiteCommand(queryToUpdateValueName, conne))
        {
            comd.Parameters.AddWithValue("@newValName", newValName);
            comd.Parameters.AddWithValue("@oldValName", oldValName);

            comd.ExecuteNonQuery();
        }

        string queryToUpdateValueNameOnItsRespectiveValue = "UPDATE Variaveis SET Valores = REPLACE(Valores, @oldValName, @newValName)";
        using (SQLiteCommand comd = new SQLiteCommand(queryToUpdateValueNameOnItsRespectiveValue, conne))
        {
            comd.Parameters.AddWithValue("@oldValName", oldValName);
            comd.Parameters.AddWithValue("@newValName", newValName);

            comd.ExecuteNonQuery();
        }
    }

    public void DeleteVariable(int varId) 
    {
        string queryToDeleteVariable = "DELETE FROM Variaveis WHERE Id = @VarId";
        using(SQLiteCommand comd = new SQLiteCommand(queryToDeleteVariable, conne))
        {
            comd.Parameters.AddWithValue("@VarId", varId);
            
            comd.ExecuteNonQuery ();
        }
    }

    public void DeleteValue(string valName, int varId)
    {
        string queryToDeleteValue = "DELETE FROM ValoresVariaveis WHERE Valor = @valName AND VariavelId = @varId";
        using (SQLiteCommand comd = new SQLiteCommand(queryToDeleteValue, conne))
        {
            comd.Parameters.AddWithValue("@valName", valName);
            comd.Parameters.AddWithValue("@varId", varId);

            comd.ExecuteNonQuery();
        }
        
        List<string> currentValues = GetVarValues(varId);
        currentValues.Remove(valName);

        string newValues = (currentValues.Count > 0) ? string.Join(",", currentValues) : null;

        string queryToUpdateValues = "UPDATE Variaveis SET Valores = @newValues WHERE Id = @varId";
        using (SQLiteCommand comd = new SQLiteCommand(queryToUpdateValues, conne))
        {
            comd.Parameters.AddWithValue("@newValues", newValues);
            comd.Parameters.AddWithValue("@varId", varId);

            comd.ExecuteNonQuery();
        }
    }

    public void DeleteRule(int regraToDel)
    {
        //Adicionar um tratamento ali em cima pra tirar as variáveis e valores da regra que pertencem quando forem excluídas, eventualmente
        //(Se não tava funcionando direito isso no SINTA, não vai ser aqui tão cedo que vai)
        string queryToDeleteRule = "DELETE FROM Regras WHERE Id = @rulId";
        using (SQLiteCommand comd = new SQLiteCommand(queryToDeleteRule, conne))
        {
            comd.Parameters.AddWithValue("@rulId", regraToDel);

            comd.ExecuteNonQuery();
        }
    }

    public string GetVarType(string varName)
    {
        string queryToGetVariableType = "SELECT Tipo FROM Variaveis WHERE Nome = @varName";
        using (SQLiteCommand comd = new SQLiteCommand(queryToGetVariableType, conne))
        {
            comd.Parameters.AddWithValue("@varName", varName);

            using(SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if(rdr.Read())
                {
                    return rdr["Tipo"].ToString();
                }
            }
        }
        //If all else fails...
        return "Numérico";
    }

    public int GetLastRuleId()
    {
        int lastRule = 0; //Caso não encontre, o 'default' vai ser começar por 0

        string queryToGetLastRuleId = "SELECT MAX(Id) FROM Regras";
        using (SQLiteCommand comd = new SQLiteCommand(queryToGetLastRuleId, conne))
        { 
            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if(rdr.Read() && rdr[0] != DBNull.Value) 
                {
                    lastRule = Convert.ToInt32(rdr[0]);
                }
            }
        }

        return lastRule;
    }

    public int GetValIdBasedOnName(string valName)
    {
        int valId = -1;
        string queryToGetValueIdOffItsName = "SELECT Id FROM ValoresVariaveis WHERE Valor = @valueName";
        using (SQLiteCommand comd = new SQLiteCommand(queryToGetValueIdOffItsName, conne))
        {
            comd.Parameters.AddWithValue("@valueName", valName);

            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    valId = Convert.ToInt32(rdr["Id"]);
                }
            }
        }

        return valId;
    }

    public string GetVarName(int varId)
    {
        string varName = "";
        string queryToGetVariableNameOffId = "SELECT Nome FROM Variaveis WHERE Id = @varId";
        using (SQLiteCommand comd = new SQLiteCommand(queryToGetVariableNameOffId, conne)) 
        {
            comd.Parameters.AddWithValue("@varId", varId);
            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    return rdr["Nome"].ToString();
                }
            }
        }
        return varName;
    }

    public string GetValName(int valId)
    {
        string valName="";

        string queryToGetValueNameBasedOnItsID = "SELECT Valor FROM ValoresVariaveis WHERE Id = @valueId";

        using (SQLiteCommand comd = new SQLiteCommand(queryToGetValueNameBasedOnItsID, conne))
        {
            comd.Parameters.AddWithValue("@valueId", valId);

            using (SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    valName = rdr["Valor"].ToString();
                }
            }
        }

        return valName;
    }

    public List<Regra> GetRegras() 
    {
        List<Regra> regraRetorno = new List<Regra> ();
        string queryToGetRules = "SELECT * FROM REGRAS";
        using(SQLiteCommand comd = new SQLiteCommand(queryToGetRules,conne))
        {
            using(SQLiteDataReader rdr = comd.ExecuteReader())
            {
                while(rdr.Read())
                {
                    Regra thisRule = new Regra(
                        Convert.ToInt32(rdr["Id"]),
                        rdr["Nome"].ToString(),
                        rdr["QueryForUser"].ToString(),
                        rdr["QueryForKnowledge"].ToString(),
                        Convert.ToInt32(rdr["VariavelSaidaId"]),
                        Convert.ToInt32(rdr["ValorSaidaId"]),
                        Convert.ToDecimal(rdr["FatorConfiabilidade"])
                        ){};
                    regraRetorno.Add(thisRule);
                }
            }
        }
        return regraRetorno;
    }

    public void UpdateRule_conditions(Regra regra)
    {
        string queryToUpdateAnExistingRuleConditions =  "UPDATE Regras SET Nome = @newNome, QueryForUser = @newUQuery, QueryForKnowledge = @newKQuery, FatorConfiabilidade = @newFC WHERE Id = @oldID";

        using (SQLiteCommand comd = new SQLiteCommand(queryToUpdateAnExistingRuleConditions, conne))
        {
            comd.Parameters.AddWithValue("@newNome", regra.Nome);
            comd.Parameters.AddWithValue("@newUQuery", regra.UserQuery);
            comd.Parameters.AddWithValue("@newKQuery", regra.KBQuery);
            comd.Parameters.AddWithValue("@newFC", regra.FatorConfiabilidade);
            comd.Parameters.AddWithValue("@oldID", regra.Id);

            comd.ExecuteNonQuery();
        }
    }

    public void UpdateRule_output(Regra regra)
    {
        string queryToUpdateAnExistingRuleOutputs = "UPDATE Regras SET VariavelSaidaId = @newVarSaida, ValorSaidaId = @newValSaida WHERE Id = @oldID";

        using (SQLiteCommand comd = new SQLiteCommand(queryToUpdateAnExistingRuleOutputs, conne))
        {
            comd.Parameters.AddWithValue("@newVarSaida", regra.IdVariavelSaida);
            comd.Parameters.AddWithValue("@newValSaida", regra.IdValorSaida);
            comd.Parameters.AddWithValue("@oldID", regra.Id);

            comd.ExecuteNonQuery();
        }
    }

    public Variavel GetVarById(int varId)
    {
        string queryToGetOneTrueVarById = "SELECT * FROM Variaveis WHERE Id = @varId";

        using (SQLiteCommand comd = new SQLiteCommand(queryToGetOneTrueVarById, conne))
        {
            comd.Parameters.AddWithValue("@varId",varId);

            using(SQLiteDataReader rdr = comd.ExecuteReader())
            {
                if(rdr.Read())
                {
                    Variavel foundVarToReturn = new Variavel
                        (varId, rdr["Nome"].ToString(), rdr["Tipo"].ToString(), rdr["Valores"].ToString());
                    return foundVarToReturn;
                }
            }
        }
        return null;
    }
}