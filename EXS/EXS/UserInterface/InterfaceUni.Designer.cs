namespace EXS.UserInterface
{
    partial class InterfaceUni
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
            button1 = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(106, 295);
            button1.Name = "button1";
            button1.Size = new Size(213, 65);
            button1.TabIndex = 0;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(368, 25);
            label1.TabIndex = 1;
            label1.Text = "Escolha uma opção que julgue apropriada";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(59, 108);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 167);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(6, 22);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(294, 139);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // InterfaceUni
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 383);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "InterfaceUni";
            Text = "InterfaceUni";
            Load += InterfaceUni_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}