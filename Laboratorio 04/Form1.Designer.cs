namespace Laboratorio_04
{
    partial class frmArbolesBinarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCrearAVL = new System.Windows.Forms.Button();
            this.btnCrearAbb = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnOI = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnEI = new System.Windows.Forms.Button();
            this.btnAI = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtLlave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbArbol = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArbol)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCrearAVL);
            this.groupBox1.Controls.Add(this.btnCrearAbb);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Arbol";
            // 
            // btnCrearAVL
            // 
            this.btnCrearAVL.Location = new System.Drawing.Point(7, 86);
            this.btnCrearAVL.Name = "btnCrearAVL";
            this.btnCrearAVL.Size = new System.Drawing.Size(96, 55);
            this.btnCrearAVL.TabIndex = 1;
            this.btnCrearAVL.Text = "Crear AVL";
            this.btnCrearAVL.UseVisualStyleBackColor = true;
            this.btnCrearAVL.Click += new System.EventHandler(this.btnCrearAVL_Click);
            // 
            // btnCrearAbb
            // 
            this.btnCrearAbb.Location = new System.Drawing.Point(7, 20);
            this.btnCrearAbb.Name = "btnCrearAbb";
            this.btnCrearAbb.Size = new System.Drawing.Size(96, 59);
            this.btnCrearAbb.TabIndex = 0;
            this.btnCrearAbb.Text = "Crear ABB";
            this.btnCrearAbb.UseVisualStyleBackColor = true;
            this.btnCrearAbb.Click += new System.EventHandler(this.btnCrearAbb_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPost);
            this.groupBox2.Controls.Add(this.btnOI);
            this.groupBox2.Controls.Add(this.btnIn);
            this.groupBox2.Controls.Add(this.btnPre);
            this.groupBox2.Controls.Add(this.btnEI);
            this.groupBox2.Controls.Add(this.btnAI);
            this.groupBox2.Controls.Add(this.txtValor);
            this.groupBox2.Controls.Add(this.txtLlave);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(137, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modificar Arbol";
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(169, 102);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 9;
            this.btnPost.Text = "Post Orden";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnOI
            // 
            this.btnOI.Location = new System.Drawing.Point(169, 76);
            this.btnOI.Name = "btnOI";
            this.btnOI.Size = new System.Drawing.Size(75, 23);
            this.btnOI.TabIndex = 8;
            this.btnOI.Text = "Obtener";
            this.btnOI.UseVisualStyleBackColor = true;
            this.btnOI.Click += new System.EventHandler(this.btnOI_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(88, 102);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "In Orden";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(7, 102);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 6;
            this.btnPre.Text = "Pre Orden";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnEI
            // 
            this.btnEI.Location = new System.Drawing.Point(88, 76);
            this.btnEI.Name = "btnEI";
            this.btnEI.Size = new System.Drawing.Size(75, 23);
            this.btnEI.TabIndex = 5;
            this.btnEI.Text = "Eliminar";
            this.btnEI.UseVisualStyleBackColor = true;
            this.btnEI.Click += new System.EventHandler(this.btnEI_Click);
            // 
            // btnAI
            // 
            this.btnAI.Location = new System.Drawing.Point(7, 76);
            this.btnAI.Name = "btnAI";
            this.btnAI.Size = new System.Drawing.Size(75, 23);
            this.btnAI.TabIndex = 4;
            this.btnAI.Text = "Agregar";
            this.btnAI.UseVisualStyleBackColor = true;
            this.btnAI.Click += new System.EventHandler(this.btnAI_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(73, 43);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 3;
            // 
            // txtLlave
            // 
            this.txtLlave.Location = new System.Drawing.Point(73, 17);
            this.txtLlave.Name = "txtLlave";
            this.txtLlave.Size = new System.Drawing.Size(100, 20);
            this.txtLlave.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Llave:";
            // 
            // pbArbol
            // 
            this.pbArbol.Location = new System.Drawing.Point(405, 12);
            this.pbArbol.Name = "pbArbol";
            this.pbArbol.Size = new System.Drawing.Size(527, 472);
            this.pbArbol.TabIndex = 2;
            this.pbArbol.TabStop = false;
            // 
            // frmArbolesBinarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 496);
            this.Controls.Add(this.pbArbol);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmArbolesBinarios";
            this.Text = "Listas Enlazadas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArbol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCrearAVL;
        private System.Windows.Forms.Button btnCrearAbb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnOI;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnEI;
        private System.Windows.Forms.Button btnAI;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtLlave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbArbol;
    }
}

