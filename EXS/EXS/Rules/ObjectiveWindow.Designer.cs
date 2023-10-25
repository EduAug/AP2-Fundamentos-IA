namespace EXS.Rules
{
    partial class ObjectiveWindow
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
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(71, 30);
            label1.TabIndex = 0;
            label1.Text = "Então:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(211, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(267, 58);
            label2.Name = "label2";
            label2.Size = new Size(25, 25);
            label2.TabIndex = 2;
            label2.Text = "=";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(335, 63);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(211, 23);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Location = new Point(218, 107);
            button1.Name = "button1";
            button1.Size = new Size(122, 23);
            button1.TabIndex = 4;
            button1.Text = "Adicionar objetivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ObjectiveWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 142);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "ObjectiveWindow";
            Text = "Objetivo";
            Load += ObjectiveWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Button button1;
    }
}