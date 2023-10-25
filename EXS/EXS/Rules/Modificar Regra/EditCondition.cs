using EXS.Entities;
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

namespace EXS.Rules.Modificar_Regra
{
    public partial class EditCondition : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;
        private Dictionary<string, int> variaveisIDictionary = new Dictionary<string, int>();
        private RuleCondition thisCond;
        public EditCondition(RuleCondition currCon)
        {
            InitializeComponent();
            this.thisCond = currCon;
        }
        private void EditCondition_Load(object sender, EventArgs e)
        {
            comboBox1.Text = thisCond.Variable;
            comboBox2.Text = thisCond.Operator;
            comboBox3.Text = thisCond.Value;
            if (thisCond.CondOp == "||")
            {
                radioButton1.Enabled = true;

                radioButton2.Enabled = true;
                radioButton2.Checked = true;
            }
            else if (thisCond.CondOp == "&&")
            {
                radioButton1.Enabled = true;
                radioButton1.Checked = true;

                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            comboFill1();
            LoadComboBox2AndComboBox3Options(comboBox1.Text);
        }

        private void comboFill1()
        {
            List<(int, string)> varNames = dbMan.GetVarNamesIds();
            foreach ((int id, string name) in varNames)
            {
                if (!variaveisIDictionary.ContainsKey(name))
                {
                    comboBox1.Items.Add(name);
                    variaveisIDictionary.Add(name, id);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                string currVar = comboBox1.SelectedItem.ToString();
                LoadComboBox2AndComboBox3Options(currVar);
            }
        }

        private void LoadComboBox2AndComboBox3Options(string selectedVar)
        {
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();

            if (!string.IsNullOrEmpty(selectedVar))
            {
                string selectedVarType = dbMan.GetVarType(selectedVar);

                if (selectedVarType == "Univalorada")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("==");
                    comboBox2.Items.Add("!=");
                }
                else if (selectedVarType == "Numerica")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("==");
                    comboBox2.Items.Add("<");
                    comboBox2.Items.Add("<=");
                    comboBox2.Items.Add(">");
                    comboBox2.Items.Add(">=");
                }

                List<string> varVals = dbMan.GetVarValues(selectedVar);
                foreach (var value in varVals)
                {
                    comboBox3.Items.Add(value);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                thisCond.CondOp = "&&";
            }
            else if (radioButton2.Checked)
            {
                thisCond.CondOp = "||";
            }
            else 
            {
                thisCond.CondOp = "";
            }
            thisCond.Variable = comboBox1.Text;
            thisCond.Operator = comboBox2.Text;
            thisCond.Value = comboBox3.Text;
        }
    }
}
