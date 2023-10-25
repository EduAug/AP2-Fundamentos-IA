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

namespace EXS.UserInterface
{
    public partial class InterfaceUni : Form
    {
        List<RuleCondition> UInputs = new List<RuleCondition>();
        Variavel currentUniValued;
        public InterfaceUni(List<RuleCondition> currentUserConds, Variavel thisNumFor)
        {
            InitializeComponent();
            label1.Text = "Escolha uma opção que julgue apropriada\npara ``" + thisNumFor.Nome + "``:";
            this.currentUniValued = thisNumFor;
            this.UInputs = currentUserConds;
            this.Text = thisNumFor.Nome;
            button1.Enabled = false;
            LoadValueButtons();
        }

        private void InterfaceUni_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RuleCondition testCond = new RuleCondition();
            testCond.CondOp = "";
            testCond.Variable = currentUniValued.Nome;
            testCond.Operator = "==";
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is RadioButton radioButton && radioButton.Checked)
                {
                    testCond.Value = radioButton.Text;
                }
            }
            UInputs.Add(testCond);
            this.Close();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool radioButtonSelected = false;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    radioButtonSelected = true;
                    break;
                }
            }

            button1.Enabled = radioButtonSelected;
        }

        public void LoadValueButtons()
        {
            List<string> varValues = currentUniValued.Valores.Split(',').ToList();
            varValues.RemoveAll(string.IsNullOrEmpty);
            foreach (var val in varValues)
            {
                var radioButton = new RadioButton();
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
                radioButton.Text = val;
                flowLayoutPanel1.Controls.Add(radioButton);
            }
        }
    }
}
