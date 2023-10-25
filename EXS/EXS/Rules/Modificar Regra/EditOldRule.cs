using EXS.Entities;
using EXS.Rules.Modificar_Regra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXS.Rules
{
    public partial class EditOldRule : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;
        private Regra thisRule;
        public EditOldRule(Regra currentRuleToEdit)
        {
            InitializeComponent();
            textBox1.Text = currentRuleToEdit.Nome;
            numericUpDown1.Value = (decimal)currentRuleToEdit.FatorConfiabilidade;
            currentRuleToEdit.Conditions = SplitConditions(currentRuleToEdit.KBQuery);
            thisRule = currentRuleToEdit;

            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void EditOldRule_Load(object sender, EventArgs e)
        {
            updateListViewConds();
        }

        public List<RuleCondition> SplitConditions(string conditionsSegment)
        {
            List<RuleCondition> conditionsList = new List<RuleCondition>();

            string[] conditionItems = conditionsSegment.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string conditionItem in conditionItems)
            {
                RuleCondition condition = new RuleCondition();
                string tempConditionItem = conditionItem;

                if (tempConditionItem.StartsWith("&&") || tempConditionItem.StartsWith("||"))
                {
                    int opLength = 2;
                    condition.CondOp = tempConditionItem.Substring(0, opLength);
                    tempConditionItem = tempConditionItem.Substring(opLength);
                }

                string[] parts = tempConditionItem.Split(new string[] { "==", "!=", "<=", ">=", "<", ">" }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    string[] comparators = { "==", "!=", "<=", ">=", "<", ">" };
                    string operadorMat = "";
                    foreach (var comparator in comparators)
                    {
                        if (tempConditionItem.Contains(comparator))
                        {
                            operadorMat = comparator;
                            break;
                        }
                    }

                    condition.Variable = parts[0].Trim();
                    condition.Operator = operadorMat.Trim();
                    condition.Value = parts[1].Trim();
                }

                conditionsList.Add(condition);
            }

            return conditionsList;
        }

        public void updateListViewConds()
        {
            listView1.Items.Clear();

            foreach (var cond in thisRule.Conditions)
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
                button1.Enabled = true;
                button3.Enabled = selectedIndex != 0;
            }
            else
            {
                button1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedListIdx = listView1.SelectedItems[0].Index;
                if (selectedListIdx >= 0 && selectedListIdx < thisRule.Conditions.Count)
                {
                    EditCondition editCon = new EditCondition(thisRule.Conditions[selectedListIdx]);
                    editCon.ShowDialog();
                    updateListViewConds();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listView1.SelectedItems[0].Index;
            if (selectedIndex >= 0 && selectedIndex < thisRule.Conditions.Count)
            {
                thisRule.Conditions.RemoveAt(selectedIndex);
                updateListViewConds();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Salvar as alterações à regra
            //Após modificar as condições, concatenar novamente em string e atribuir ao campo KBQuery
            //Modificar também o campo UQuery (algo assim)
            string kbQueryFromCond = "";
            string usQueryFromCond = "";
            foreach (var cond in thisRule.Conditions)
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
            thisRule.setUserQuery(usQueryFromCond);
            foreach (var conditions in thisRule.Conditions)
            {
                kbQueryFromCond += conditions.CondOp + conditions.Variable + conditions.Operator + conditions.Value + ",";
            }
            thisRule.setKBQuery(kbQueryFromCond);
            thisRule.Nome = textBox1.Text;
            thisRule.FatorConfiabilidade = numericUpDown1.Value;

            /*
            Debug.WriteLine("Nome: " + thisRule.Nome);                 //ok
            Debug.WriteLine("Id: " + thisRule.Id);                    //ok
            Debug.WriteLine("User Query: " + thisRule.UserQuery);             //ok
            Debug.WriteLine("KB Query: " + thisRule.KBQuery);               //ok
            Debug.WriteLine("Id var saida: " + thisRule.IdVariavelSaida);       //ok
            Debug.WriteLine("Id val saida:" + thisRule.IdValorSaida);          //ok
            Debug.WriteLine("fator conf.: " + thisRule.FatorConfiabilidade);   //ok
            */
            dbMan.UpdateRule_conditions(thisRule);
            this.Close();
        }
    }
}
