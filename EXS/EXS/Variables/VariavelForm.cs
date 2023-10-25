using EXS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXS
{
    public partial class VariavelForm : Form
    {
        private DatabaseManager dbMan = DatabaseManager.Instance;   //Forma de criar uma instancia do "dbmanager"
        private Dictionary<string, int> variaveisIDictionary = new Dictionary<string, int>(); //Dicionário para pegar Id e nome das variáveis
        public VariavelForm()
        {
            InitializeComponent();

            textBox2.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
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

            comboBox2.Items.Clear();
        }

        private void comboFill2()
        {
            comboBox2.Items.Clear();

            string selectedVar = comboBox1.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedVar))
            {
                textBox2.Enabled = comboBox1.SelectedIndex >= 0;
                button2.Enabled = (comboBox1.SelectedIndex >= 0 && !string.IsNullOrEmpty(textBox2.Text));

                List<string> varValores = dbMan.GetVarValues(selectedVar);
                foreach (var nomes in varValores)
                {
                    comboBox2.Items.Add(nomes);
                }
            }
        }

        private void VariavelForm_Load(object sender, EventArgs e)
        {
            comboFill1();
        }
        // Documentação informal p anotar ideia:
        //Referente ao "tipo" ao criar, pegar o valor do radioButton (univalorada ou numérica)
        //SE o valor for univalorada, Valor novoValor = new Valor(..., TRUE, ...);
        //SE o valor for numérica, Valor novoValor = new Valor(..., 1, ...);

        //Criar, então, classes para as tabelas do banco
        // - Variável | - Valor | - Regra | - VariávelValor(?)


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = (!string.IsNullOrEmpty(textBox1.Text) &&
                                (radioButton1.Checked || radioButton2.Checked));

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = (!string.IsNullOrEmpty(textBox1.Text) &&
                                (radioButton1.Checked || radioButton2.Checked));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (!string.IsNullOrEmpty(textBox1.Text) &&
                                (radioButton1.Checked || radioButton2.Checked));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string variableName = textBox1.Text;
            string variableValue = radioButton1.Checked ? "Univalorada" : (radioButton2.Checked ? "Numerica" : "Univalorada");

            Variavel varToInsert = new Variavel(variableName, variableValue, "");

            dbMan.InsertVariable(varToInsert);

            textBox1.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboFill1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFill2();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = (comboBox1.SelectedIndex >= 0 && !string.IsNullOrEmpty(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedVar = comboBox1.SelectedItem.ToString();
            if (variaveisIDictionary.TryGetValue(selectedVar, out int varId))
            {
                string valueName = textBox2.Text;
                Valor valueToInsert = new Valor(varId, valueName);
                dbMan.InsertValue(valueToInsert);
            }
            textBox2.Clear();
            comboFill2();
        }
    }
}
