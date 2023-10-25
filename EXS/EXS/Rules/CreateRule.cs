using EXS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EXS.Rules
{
    public partial class CreateRule : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;
        private Dictionary<string, int> variaveisIDictionary = new Dictionary<string, int>();
        private Regra currentRule;
        private int newRuleId;

        public CreateRule()
        {
            InitializeComponent();
            this.newRuleId = (dbMan.GetLastRuleId() + 1);
            this.currentRule = new Regra("", "", newRuleId, -1);

            button2.Enabled = false;
        }

        private void CreateRule_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConditionWindow createCond = new ConditionWindow(newRuleId, currentRule);
            createCond.ShowDialog();
            Debug.WriteLine(currentRule.Id);
            //foreach (var rule in currentRule.Conditions){Debug.WriteLine($"Var: {rule.Variable} | Op: {rule.Operator} | Val: {rule.Value}");}
            updateListViewConds();
            if (!string.IsNullOrEmpty(textBox1.Text) && currentRule.IdValorSaida != -1 && currentRule.IdVariavelSaida != -1 && currentRule.Conditions.Any())
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ObjectiveWindow createFin = new ObjectiveWindow(newRuleId, currentRule);
            createFin.ShowDialog();/*
            Debug.WriteLine($"Id Regra:{currentRule.Id}");
            Debug.WriteLine($"Id Valor Saída:{currentRule.IdValorSaida}");
            Debug.WriteLine($"Id Variavel Saída:{currentRule.IdVariavelSaida}");*/
            updateListViewObj();
            if (!string.IsNullOrEmpty(textBox1.Text) && currentRule.IdValorSaida != -1 && currentRule.IdVariavelSaida != -1 && currentRule.Conditions.Any())
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        public void updateListViewConds()
        {
            listView1.Items.Clear();

            foreach (var cond in currentRule.Conditions)
            {
                string mppdCond = "";
                string mppdOp = "";
                if (cond.CondOp == "&&")
                { mppdCond = "E"; }
                else if (cond.CondOp == "||") { mppdCond = "OU"; }
                switch (cond.Operator)
                {
                    case "!=":
                        mppdOp = "diferente de";
                        break;
                    case "==":
                        mppdOp = "igual a";
                        break;
                    case "<":
                        mppdOp = "menor que";
                        break;
                    case "<=":
                        mppdOp = "menor ou igual a";
                        break;
                    case ">":
                        mppdOp = "maior que";
                        break;
                    case ">=":
                        mppdOp = "maior ou igual a";
                        break;
                }
                string conditionalStringFrmtd = $"{mppdCond} {cond.Variable}     {mppdOp}     {cond.Value}";
                ListViewItem item = new ListViewItem(conditionalStringFrmtd);
                listView1.Items.Add(item);
            }
        }

        public void updateListViewObj()
        {
            List<(int, string)> varNames = dbMan.GetVarNamesIds();
            foreach ((int id, string name) in varNames)
            {
                if (!variaveisIDictionary.ContainsKey(name))
                {
                    variaveisIDictionary.Add(name, id);
                }
            }
            string varSaidaName = varNames.Where(x => x.Item1 == currentRule.IdVariavelSaida)
                                        .Select(x => x.Item2)
                                        .FirstOrDefault();

            string valName = dbMan.GetValName(currentRule.IdValorSaida);

            if (currentRule.IdVariavelSaida != -1 && currentRule.IdValorSaida != -1)
            {
                ListViewItem item = new ListViewItem($"{varSaidaName}   =   {valName}");
                listView2.Items.Add(item);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && currentRule.IdValorSaida != -1 && currentRule.IdVariavelSaida != -1 && currentRule.Conditions.Any())
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kbQueryFromCond = "";
            string usQueryFromCond = "";
            foreach (var cond in currentRule.Conditions)
            {
                string mppdCond = "";
                string mppdOp = "";

                if (cond.CondOp == "&&")
                { mppdCond = "E"; }
                else if (cond.CondOp == "||")
                { mppdCond = "OU"; }

                switch (cond.Operator)
                {
                    case "!=":
                        mppdOp = "diferente de";
                        break;
                    case "==":
                        mppdOp = "igual a";
                        break;
                    case "<":
                        mppdOp = "menor que";
                        break;
                    case "<=":
                        mppdOp = "menor ou igual a";
                        break;
                    case ">":
                        mppdOp = "maior que";
                        break;
                    case ">=":
                        mppdOp = "maior ou igual a";
                        break;
                }
                usQueryFromCond += mppdCond + " " + cond.Variable + " " + mppdOp + " " + cond.Value + ",";
            }

            currentRule.FatorConfiabilidade = numericUpDown1.Value;
            currentRule.Nome = textBox1.Text;
            currentRule.setUserQuery(usQueryFromCond);
            foreach (var conditions in currentRule.Conditions)
            {
                kbQueryFromCond += conditions.CondOp + conditions.Variable + conditions.Operator + conditions.Value + ",";
            }
            currentRule.setKBQuery(kbQueryFromCond);

            dbMan.InsertRule(currentRule);

            /*
            Debug.WriteLine("Nome: "+currentRule.Nome);                 //ok
            Debug.WriteLine("Id: "+currentRule.Id);                    //ok
            Debug.WriteLine("User Query: "+currentRule.UserQuery);             //ok
            Debug.WriteLine("KB Query: "+currentRule.KBQuery);               //ok
            Debug.WriteLine("Id var saida: "+currentRule.IdVariavelSaida);       //ok
            Debug.WriteLine("Id val saida:"+currentRule.IdValorSaida);          //ok
            Debug.WriteLine("fator conf.: "+currentRule.FatorConfiabilidade);   //ok*/
        }
    }
}
