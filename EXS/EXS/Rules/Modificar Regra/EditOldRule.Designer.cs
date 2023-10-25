namespace EXS.Rules
{
    partial class EditOldRule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            button3 = new Button();
            label3 = new Label();
            button1 = new Button();
            listView1 = new ListView();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 223);
            label2.Name = "label2";
            label2.Size = new Size(142, 21);
            label2.TabIndex = 26;
            label2.Text = "Fator de Confiança:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(160, 226);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(53, 23);
            numericUpDown1.TabIndex = 25;
            // 
            // button3
            // 
            button3.Location = new Point(203, 275);
            button3.Name = "button3";
            button3.Size = new Size(130, 38);
            button3.TabIndex = 22;
            button3.Text = "Excluir Condição";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 20;
            label3.Text = "Se :";
            // 
            // button1
            // 
            button1.Location = new Point(37, 276);
            button1.Name = "button1";
            button1.Size = new Size(130, 38);
            button1.TabIndex = 19;
            button1.Text = "Editar Condição";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.GridLines = true;
            listView1.Location = new Point(12, 68);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(520, 139);
            listView1.TabIndex = 18;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(136, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 23);
            textBox1.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 16;
            label1.Text = "Nome da regra:";
            // 
            // button2
            // 
            button2.Location = new Point(366, 275);
            button2.Name = "button2";
            button2.Size = new Size(130, 38);
            button2.TabIndex = 27;
            button2.Text = "Salvar Alterações";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // EditOldRule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 325);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "EditOldRule";
            Text = "Editar Regra Existente";
            Load += EditOldRule_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button3;
        private Label label3;
        private Button button1;
        private ListView listView1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
    }
}