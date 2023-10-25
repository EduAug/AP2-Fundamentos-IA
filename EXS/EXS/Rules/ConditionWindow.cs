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

namespace EXS.Rules
{
    public partial class ConditionWindow : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;
        private Dictionary<string, int> variaveisIDictionary = new Dictionary<string, int>();
        private Regra regraInProgress;

        private int currentRuleId;

        public ConditionWindow(int ruleId, Regra _regraInProgress)
        {
            InitializeComponent();
            currentRuleId = ruleId;
            regraInProgress = _regraInProgress;
            button1.Enabled = false;

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            this.regraInProgress = _regraInProgress;
        }
        private void ConditionWindow_Load(object sender, EventArgs e)
        {
            comboFill1();

            if (regraInProgress.Conditions.Count > 0)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
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
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();

            if (!string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                string selectedVarType = dbMan.GetVarType(comboBox1.SelectedItem.ToString());
                //Debug.WriteLine(selectedVarType);

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

                string selectedVar = comboBox1.SelectedItem.ToString();
                List<string> varVals = dbMan.GetVarValues(selectedVar);
                foreach (var value in varVals)
                {
                    comboBox3.Items.Add(value);
                }

                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RuleCondition thisCond = new RuleCondition
            {
                Variable = comboBox1.SelectedItem.ToString(),
                Operator = comboBox2.SelectedItem.ToString(),
                Value = comboBox3.SelectedItem.ToString()
            };
            //Debug.WriteLine(thisCond);
            if (radioButton2.Checked)
            {
                thisCond.CondOp = "&&";
            }
            else if (radioButton1.Checked)
            {
                thisCond.CondOp = "||";
            } else
            {
                thisCond.CondOp = "";
            }

            regraInProgress.Conditions.Add(thisCond);

            if (regraInProgress.Conditions.Count > 0)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
