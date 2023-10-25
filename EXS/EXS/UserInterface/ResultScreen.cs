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
    public partial class ResultScreen : Form
    {
        public ResultScreen(List<(string variable, string value)> results)
        {
            InitializeComponent();
            foreach (var (variable,value) in results)
            {
                if (!string.IsNullOrEmpty(variable) && !string.IsNullOrEmpty(value))
                {
                    listView1.Items.Add(variable + " = " + value);
                }
            }
        }
    }
}
