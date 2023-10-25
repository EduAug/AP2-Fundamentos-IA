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
    public partial class InterfaceNum : Form
    {
        List<RuleCondition> UInputs = new List<RuleCondition>();
        Variavel currentNumValued;
        public InterfaceNum(List<RuleCondition> currentUserConds, Variavel thisNumFor)
        {
            InitializeComponent();
            label1.Text = "Insira um valor que julgue apropriado\npara ``" + thisNumFor.Nome + "``:";
            this.currentNumValued = thisNumFor;
            this.UInputs = currentUserConds;
            this.Text = thisNumFor.Nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RuleCondition testCond = new RuleCondition();
            testCond.CondOp = "";
            testCond.Variable = currentNumValued.Nome;
            testCond.Operator = "==";
            testCond.Value = numericUpDown1.Value.ToString();
            UInputs.Add(testCond);
            this.Close();
        }
    }
}
