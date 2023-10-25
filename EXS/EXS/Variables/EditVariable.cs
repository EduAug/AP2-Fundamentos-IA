using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXS
{
    public partial class EditVariable : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;

        public EditVariable()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void FillVariableList()
        {
            List<(int, string)> varNames = dbMan.GetVarNamesIds();
            listView1.Items.Clear();
            foreach ((int id, string name) in varNames)
            {
                listView1.Items.Add(name);
            }
        }

        private void FillValueList(string selectedVar)
        {
            List<string> valueNames = dbMan.GetVarValues(selectedVar);
            listView2.Items.Clear();
            foreach (var name in valueNames)
            {
                listView2.Items.Add(name);
            }
        }

        private void EditVariable_Load(object sender, EventArgs e)
        {
            FillVariableList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                listView2.Items.Clear();
                string selectedVar = listView1.SelectedItems[0].Text;
                //Debug.WriteLine(selectedVar);
                if (!string.IsNullOrEmpty(selectedVar))
                {
                    FillValueList(selectedVar);
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                button4.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedVal = listView1.SelectedItems[0].Text;
                ConfirmDelete confDel = new ConfirmDelete(selectedVal,true);
                confDel.ShowDialog();
                FillVariableList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string selectedVal = listView2.SelectedItems[0].Text;
                ConfirmDelete confDel = new ConfirmDelete(selectedVal,false);
                confDel.ShowDialog();
                FillValueList(listView1.SelectedItems[0].Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<(int, string)> varNames = dbMan.GetVarNamesIds();

            if (listView1.SelectedItems.Count > 0)
            {
                string newNameToUpd = textBox1.Text;
                if (!string.IsNullOrEmpty(newNameToUpd))
                {
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    //Debug.WriteLine(selectedItem.Text);

                    int selectedItemIdToUpd = 100000;
                    foreach ((int id, string name) in varNames)
                    {
                        //Debug.WriteLine("Current name iterating: "+name);
                        if (name == selectedItem.Text)
                        {
                            //Debug.WriteLine(name + ": " + newNameToUpd);
                            selectedItemIdToUpd = id;
                        }
                    }
                    //Debug.WriteLine(newNameToUpd);
                    //Debug.WriteLine(selectedItemIdToUpd);
                    dbMan.UpdateVariable(selectedItemIdToUpd, newNameToUpd);
                }
            }
            FillVariableList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems.Count > 0)
            {
                string newNameToUpd = textBox1.Text;
                if (!string.IsNullOrEmpty(newNameToUpd))
                { 
                    ListViewItem selectedItem = listView2.SelectedItems[0];

                    dbMan.UpdateValue_name(selectedItem.Text,newNameToUpd);
                    selectedItem.Text = newNameToUpd;
                }
            }
            FillValueList(listView1.SelectedItems[0].Text);
        }
    }
}
