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

namespace EXS
{
    public partial class ConfirmDelete : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;
        public string CurrentDeletion { get; set; }
        private bool isVar { get; set; }
        public ConfirmDelete(string itemName, bool isVariable)
        {
            InitializeComponent();
            this.CurrentDeletion = itemName;
            this.isVar = isVariable;

            if (isVariable)
            {
                label1.Text = $"Excluir variável '{CurrentDeletion}' ?";
            }
            else {
                label1.Text = $"Excluir valor '{CurrentDeletion}' ?";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<(int, string)> varNames = dbMan.GetVarNamesIds();
            if (isVar)
            {
                string currentDeletableVar = CurrentDeletion;
                foreach ((int id, string name) in varNames)
                {
                    if (name == currentDeletableVar)
                    {
                        dbMan.DeleteVariable(id);
                        break;
                    }
                }
                this.Close();
            }
            else 
            {
                string currentDeletableVal = CurrentDeletion;
                int foundIdOffValName = dbMan.GetVarIdFromValName(currentDeletableVal);
                //Debug.WriteLine(foundIdOffValName);
                dbMan.DeleteValue(currentDeletableVal, foundIdOffValName);

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
