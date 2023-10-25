namespace EXS
{
    partial class VariavelForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            radioButton1 = new RadioButton();
            label2 = new Label();
            radioButton2 = new RadioButton();
            textBox2 = new TextBox();
            label3 = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            button1 = new Button();
            button2 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(267, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 18);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome da variável:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(3, 36);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(144, 19);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "Univalorada (Sim,Não)";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 18);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 3;
            label2.Text = "Tipo da variável:";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(3, 61);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(113, 19);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "Numérica (1,2,n)";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(267, 23);
            textBox2.TabIndex = 0;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 5);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Valor:";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(comboBox2);
            splitContainer1.Panel2.Controls.Add(comboBox1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(radioButton1);
            splitContainer1.Panel2.Controls.Add(radioButton2);
            splitContainer1.Size = new Size(582, 223);
            splitContainer1.SplitterDistance = 360;
            splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(textBox1);
            splitContainer2.Panel1.Controls.Add(button1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(label3);
            splitContainer2.Panel2.Controls.Add(button2);
            splitContainer2.Panel2.Controls.Add(textBox2);
            splitContainer2.Size = new Size(344, 216);
            splitContainer2.SplitterDistance = 110;
            splitContainer2.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(3, 64);
            button1.Name = "button1";
            button1.Size = new Size(122, 23);
            button1.TabIndex = 9;
            button1.Text = "Adicionar variável";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 52);
            button2.Name = "button2";
            button2.Size = new Size(122, 23);
            button2.TabIndex = 10;
            button2.Text = "Adicionar valor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(3, 193);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(175, 23);
            comboBox2.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 137);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 174);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 8;
            label5.Text = "Valores:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 119);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 6;
            label4.Text = "Variáveis:";
            // 
            // VariavelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 247);
            Controls.Add(splitContainer1);
            Name = "VariavelForm";
            Text = "Criar variável e valor";
            Load += VariavelForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private RadioButton radioButton1;
        private Label label2;
        private RadioButton radioButton2;
        private TextBox textBox2;
        private Label label3;
        private SplitContainer splitContainer1;
        private Button button1;
        private Button button2;
        private SplitContainer splitContainer2;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}