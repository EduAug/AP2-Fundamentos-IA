namespace EXS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripComboBox2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            verVariáveisToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            criarRegraToolStripMenuItem = new ToolStripMenuItem();
            excluirRegraToolStripMenuItem = new ToolStripMenuItem();
            iniciarQuestionárioToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox2, toolStripMenuItem1, iniciarQuestionárioToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBox2
            // 
            toolStripComboBox2.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem3, verVariáveisToolStripMenuItem });
            toolStripComboBox2.Name = "toolStripComboBox2";
            toolStripComboBox2.Size = new Size(64, 20);
            toolStripComboBox2.Text = "Variáveis";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(178, 22);
            toolStripMenuItem3.Text = "Criar variável/valor";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // verVariáveisToolStripMenuItem
            // 
            verVariáveisToolStripMenuItem.Name = "verVariáveisToolStripMenuItem";
            verVariáveisToolStripMenuItem.Size = new Size(178, 22);
            verVariáveisToolStripMenuItem.Text = "Editar variável/valor";
            verVariáveisToolStripMenuItem.Click += verVariáveisToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { criarRegraToolStripMenuItem, excluirRegraToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(54, 20);
            toolStripMenuItem1.Text = "Regras";
            // 
            // criarRegraToolStripMenuItem
            // 
            criarRegraToolStripMenuItem.Name = "criarRegraToolStripMenuItem";
            criarRegraToolStripMenuItem.Size = new Size(163, 22);
            criarRegraToolStripMenuItem.Text = "Criar Regra";
            criarRegraToolStripMenuItem.Click += criarRegraToolStripMenuItem_Click;
            // 
            // excluirRegraToolStripMenuItem
            // 
            excluirRegraToolStripMenuItem.Name = "excluirRegraToolStripMenuItem";
            excluirRegraToolStripMenuItem.Size = new Size(163, 22);
            excluirRegraToolStripMenuItem.Text = "Modificar Regras";
            excluirRegraToolStripMenuItem.Click += excluirRegraToolStripMenuItem_Click;
            // 
            // iniciarQuestionárioToolStripMenuItem
            // 
            iniciarQuestionárioToolStripMenuItem.Name = "iniciarQuestionárioToolStripMenuItem";
            iniciarQuestionárioToolStripMenuItem.Size = new Size(122, 20);
            iniciarQuestionárioToolStripMenuItem.Text = "Iniciar Questionário";
            iniciarQuestionárioToolStripMenuItem.Click += iniciarQuestionárioToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(884, 483);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "EXS'";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripComboBox2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem verVariáveisToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem criarRegraToolStripMenuItem;
        private ToolStripMenuItem excluirRegraToolStripMenuItem;
        private ToolStripMenuItem iniciarQuestionárioToolStripMenuItem;
    }
}