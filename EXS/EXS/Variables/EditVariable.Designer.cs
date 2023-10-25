namespace EXS
{
    partial class EditVariable
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
            splitContainer1 = new SplitContainer();
            listView1 = new ListView();
            listView2 = new ListView();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listView2);
            splitContainer1.Size = new Size(490, 314);
            splitContainer1.SplitterDistance = 241;
            splitContainer1.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.GridLines = true;
            listView1.LabelWrap = false;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(218, 289);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // listView2
            // 
            listView2.Location = new Point(13, 12);
            listView2.Name = "listView2";
            listView2.Size = new Size(218, 289);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 338);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 320);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 2;
            label1.Text = "Editar nome:";
            // 
            // button1
            // 
            button1.Location = new Point(258, 337);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 3;
            button1.Text = "Renomear variável";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(258, 368);
            button2.Name = "button2";
            button2.Size = new Size(115, 23);
            button2.TabIndex = 4;
            button2.Text = "Excluir variável";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(372, 337);
            button3.Name = "button3";
            button3.Size = new Size(104, 23);
            button3.TabIndex = 5;
            button3.Text = "Renomear valor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(372, 368);
            button4.Name = "button4";
            button4.Size = new Size(104, 23);
            button4.TabIndex = 6;
            button4.Text = "Excluir valor";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // EditVariable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 403);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(splitContainer1);
            Name = "EditVariable";
            Text = "Editar variável e valor";
            Load += EditVariable_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListView listView1;
        private ListView listView2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}