namespace EXS.UserInterface
{
    partial class ResultScreen
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 33);
            label1.Name = "label1";
            label1.Size = new Size(391, 25);
            label1.TabIndex = 0;
            label1.Text = "Com base nas suas entradas, concluimos que";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            listView1.GridLines = true;
            listView1.Location = new Point(47, 81);
            listView1.Name = "listView1";
            listView1.Size = new Size(330, 222);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // ResultScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 383);
            Controls.Add(listView1);
            Controls.Add(label1);
            Name = "ResultScreen";
            Text = "Resultados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
    }
}