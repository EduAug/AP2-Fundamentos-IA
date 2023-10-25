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
    public partial class modRule : Form
    {
        public DatabaseManager dbMan = DatabaseManager.Instance;
        private Dictionary<string, int> variaveisIDictionary = new Dictionary<string, int>();
        public List<(int, string)> variables = new List<(int, string)>();
        public List<Regra> regras = new List<Regra>();
        public modRule()
        {
            InitializeComponent();
            button1.Enabled = false;

            button3.Enabled = false;
            button4.Enabled = false;

            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
        }

        public void FillRuleList()
        {
            listView1.Items.Clear();
            regras = dbMan.GetRegras();
            variables = dbMan.GetVarNamesIds();
            listView2.Items.Clear();
            foreach (var regra in regras)
            {
                listView1.Items.Add(regra.Nome);
            }
        }

        public void FillOutList(Regra selectedRule)
        {
            listView2.Items.Clear();
            foreach (var thisRule in regras)
            {
                if (thisRule == selectedRule)
                {
                    string varSaidaNome = dbMan.GetVarName(selectedRule.IdVariavelSaida);
                    string valSaidaNome = dbMan.GetValName(selectedRule.IdValorSaida);

                    listView2.Items.Add(varSaidaNome + "=" + valSaidaNome);
                }
            }
        }

        private void modRule_Load(object sender, EventArgs e)
        {
            FillRuleList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
                Regra thisRule = regras[selectedIndex];
                listView2.Items.Clear();
                FillOutList(thisRule);

                button1.Enabled = true;
                button3.Enabled = true;

                button4.Enabled = false;

                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditOldRule edtExisting = new EditOldRule(regras[listView1.SelectedItems[0].Index]);
            edtExisting.ShowDialog();
            FillRuleList();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                button1.Enabled = false;
                button3.Enabled = false;

                button4.Enabled = true;

                comboBox4.Enabled = true;
                comboBox5.Enabled = true;

                comboFill1();
            }
            else
            {
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
            }
        }

        private void comboFill1()
        {
            foreach ((int id, string name) in variables)
            {
                if (!variaveisIDictionary.ContainsKey(name))
                {
                    comboBox5.Items.Add(name);
                    variaveisIDictionary.Add(name, id);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
                if (selectedIndex >= 0 && selectedIndex < regras.Count)
                {
                    Regra ruleToDel = regras[selectedIndex];
                    dbMan.DeleteRule(ruleToDel.Id);
                }
            }
            FillRuleList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valToEditName = comboBox4.SelectedItem.ToString();

            int newValueId = dbMan.GetValIdBasedOnName(valToEditName);
            int newVariableId = dbMan.GetVarIdFromValName(valToEditName);

            if (newValueId != -1 && newVariableId != -1)
            {
                regras[listView1.SelectedIndices[0]].IdValorSaida = newValueId;
                regras[listView1.SelectedIndices[0]].IdVariavelSaida = newVariableId;

                dbMan.UpdateRule_output(regras[listView1.SelectedIndices[0]]);
                FillRuleList();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            string selectedVar = comboBox5.SelectedItem.ToString();
            List<string> varVals = dbMan.GetVarValues(selectedVar);
            foreach (var value in varVals)
            {
                comboBox4.Items.Add(value);
            }
        }
    }
}
