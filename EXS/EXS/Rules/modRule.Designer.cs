namespace EXS.Rules
{
    partial class modRule
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
            listView1 = new ListView();
            label2 = new Label();
            listView2 = new ListView();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            comboBox4 = new ComboBox();
            label4 = new Label();
            comboBox5 = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Regras:";
            // 
            // listView1
            // 
            listView1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.Location = new Point(12, 39);
            listView1.Name = "listView1";
            listView1.Size = new Size(310, 323);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 21);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Saídas:";
            // 
            // listView2
            // 
            listView2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listView2.Location = new Point(328, 39);
            listView2.Name = "listView2";
            listView2.Size = new Size(236, 323);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 368);
            button1.Name = "button1";
            button1.Size = new Size(107, 42);
            button1.TabIndex = 5;
            button1.Text = "Excluir regra";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(125, 368);
            button3.Name = "button3";
            button3.Size = new Size(107, 42);
            button3.TabIndex = 7;
            button3.Text = "Modificar regra";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(328, 368);
            button4.Name = "button4";
            button4.Size = new Size(107, 42);
            button4.TabIndex = 8;
            button4.Text = "Modificar saída";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(260, 445);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(115, 23);
            comboBox4.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(197, 445);
            label4.Name = "label4";
            label4.Size = new Size(25, 25);
            label4.TabIndex = 17;
            label4.Text = "=";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(12, 447);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(148, 23);
            comboBox5.TabIndex = 16;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 423);
            label5.Name = "label5";
            label5.Size = new Size(52, 21);
            label5.TabIndex = 15;
            label5.Text = "Então:";
            // 
            // modRule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 483);
            Controls.Add(comboBox4);
            Controls.Add(label4);
            Controls.Add(comboBox5);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(listView2);
            Controls.Add(label2);
            Controls.Add(listView1);
            Controls.Add(label1);
            Name = "modRule";
            Text = "Modificar regras";
            Load += modRule_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
        private Label label2;
        private ListView listView2;
        private Button button1;
        private Button button3;
        private Button button4;
        private ComboBox comboBox4;
        private Label label4;
        private ComboBox comboBox5;
        private Label label5;
    }
}