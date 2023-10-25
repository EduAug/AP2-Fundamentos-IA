using EXS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EXS.Rules
{
    public partial class ObjectiveWindow : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;
        private Dictionary<string, int> variaveisIDictionary = new Dictionary<string, int>();
        private Regra regraInProgress;

        private int currentRuleId;
        public ObjectiveWindow(int _ruleId, Regra _currentRule)
        {
            InitializeComponent();
            button1.Enabled = false;
            this.currentRuleId = _ruleId;
            this.regraInProgress = _currentRule;
        }
        private void ObjectiveWindow_Load(object sender, EventArgs e)
        {
            comboFill1();
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
            comboBox2.Items.Clear();
            string selectedVar = comboBox1.SelectedItem.ToString();
            List<string> varVals = dbMan.GetVarValues(selectedVar);
            foreach (var value in varVals)
            {
                comboBox2.Items.Add(value);
            }
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            regraInProgress.IdVariavelSaida = dbMan.GetVarIdFromValName(comboBox2.SelectedItem.ToString());
            regraInProgress.IdValorSaida = dbMan.GetValIdBasedOnName(comboBox2.SelectedItem.ToString());
        }
    }
}
