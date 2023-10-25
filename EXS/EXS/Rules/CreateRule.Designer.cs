namespace EXS.Rules
{
    partial class CreateRule
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
            label1 = new Label();
            textBox1 = new TextBox();
            listView1 = new ListView();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            listView2 = new ListView();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 0;
            label1.Text = "Nome da regra:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(136, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listView1
            // 
            listView1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.GridLines = true;
            listView1.Location = new Point(12, 63);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(520, 139);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // button1
            // 
            button1.Location = new Point(42, 365);
            button1.Name = "button1";
            button1.Size = new Size(130, 38);
            button1.TabIndex = 6;
            button1.Text = "Incluir Condição";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 39);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 8;
            label3.Text = "Se :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 217);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 9;
            label4.Text = "Então :";
            // 
            // button3
            // 
            button3.Location = new Point(202, 365);
            button3.Name = "button3";
            button3.Size = new Size(130, 38);
            button3.TabIndex = 10;
            button3.Text = "Incluir Finalidade";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView2
            // 
            listView2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listView2.Location = new Point(12, 241);
            listView2.Name = "listView2";
            listView2.Size = new Size(520, 66);
            listView2.TabIndex = 12;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            // 
            // button2
            // 
            button2.Location = new Point(359, 365);
            button2.Name = "button2";
            button2.Size = new Size(130, 38);
            button2.TabIndex = 13;
            button2.Text = "Criar Regra";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(160, 328);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(53, 23);
            numericUpDown1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 325);
            label2.Name = "label2";
            label2.Size = new Size(142, 21);
            label2.TabIndex = 15;
            label2.Text = "Fator de Confiança:";
            // 
            // CreateRule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(544, 425);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(listView2);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "CreateRule";
            Text = "Editor de Regra";
            Load += CreateRule_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private ListView listView1;
        private Button button1;
        private Label label3;
        private Label label4;
        private Button button3;
        private ListView listView2;
        private Button button2;
        private NumericUpDown numericUpDown1;
        private Label label2;
    }
}