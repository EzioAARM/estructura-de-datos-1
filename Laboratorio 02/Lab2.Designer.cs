namespace Laboratorio_02
{
    partial class Lab2
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
            this.btnCrearListaDoblementeEnlazada = new System.Windows.Forms.Button();
            this.btnCrearSimple = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.btnObtener = new System.Windows.Forms.Button();
            this.btnObtenerAlFinal = new System.Windows.Forms.Button();
            this.btnObtenerAlInicio = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEliminarAlFinal = new System.Windows.Forms.Button();
            this.btnEliminarAlInicio = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnAgregarAlFinal = new System.Windows.Forms.Button();
            this.btnAgregarAlInicio = new System.Windows.Forms.Button();
            this.lbDatos = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCrearListaDoblementeEnlazada);
            this.groupBox1.Controls.Add(this.btnCrearSimple);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Lista";
            // 
            // btnCrearListaDoblementeEnlazada
            // 
            this.btnCrearListaDoblementeEnlazada.Location = new System.Drawing.Point(34, 105);
            this.btnCrearListaDoblementeEnlazada.Name = "btnCrearListaDoblementeEnlazada";
            this.btnCrearListaDoblementeEnlazada.Size = new System.Drawing.Size(133, 46);
            this.btnCrearListaDoblementeEnlazada.TabIndex = 39;
            this.btnCrearListaDoblementeEnlazada.Text = "Crear lista doblemente enlazada";
            this.btnCrearListaDoblementeEnlazada.UseVisualStyleBackColor = true;
            this.btnCrearListaDoblementeEnlazada.Click += new System.EventHandler(this.btnCrearListaDoblementeEnlazada_Click);
            // 
            // btnCrearSimple
            // 
            this.btnCrearSimple.Location = new System.Drawing.Point(34, 53);
            this.btnCrearSimple.Name = "btnCrearSimple";
            this.btnCrearSimple.Size = new System.Drawing.Size(133, 46);
            this.btnCrearSimple.TabIndex = 38;
            this.btnCrearSimple.Text = "Crear lista enlazada";
            this.btnCrearSimple.UseVisualStyleBackColor = true;
            this.btnCrearSimple.Click += new System.EventHandler(this.btnCrearSimple_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtValor);
            this.groupBox2.Controls.Add(this.txtPosicion);
            this.groupBox2.Controls.Add(this.btnObtener);
            this.groupBox2.Controls.Add(this.btnObtenerAlFinal);
            this.groupBox2.Controls.Add(this.btnObtenerAlInicio);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnEliminarAlFinal);
            this.groupBox2.Controls.Add(this.btnEliminarAlInicio);
            this.groupBox2.Controls.Add(this.btnInsertar);
            this.groupBox2.Controls.Add(this.btnAgregarAlFinal);
            this.groupBox2.Controls.Add(this.btnAgregarAlInicio);
            this.groupBox2.Location = new System.Drawing.Point(220, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modificar Lista";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Valor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Posicion";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(125, 51);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 61;
            // 
            // txtPosicion
            // 
            this.txtPosicion.Location = new System.Drawing.Point(125, 25);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(100, 20);
            this.txtPosicion.TabIndex = 60;
            // 
            // btnObtener
            // 
            this.btnObtener.Location = new System.Drawing.Point(296, 156);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(105, 23);
            this.btnObtener.TabIndex = 59;
            this.btnObtener.Text = "Obtener";
            this.btnObtener.UseVisualStyleBackColor = true;
            this.btnObtener.Click += new System.EventHandler(this.btnObtener_Click);
            // 
            // btnObtenerAlFinal
            // 
            this.btnObtenerAlFinal.Location = new System.Drawing.Point(296, 125);
            this.btnObtenerAlFinal.Name = "btnObtenerAlFinal";
            this.btnObtenerAlFinal.Size = new System.Drawing.Size(105, 23);
            this.btnObtenerAlFinal.TabIndex = 58;
            this.btnObtenerAlFinal.Text = "Obtener el final";
            this.btnObtenerAlFinal.UseVisualStyleBackColor = true;
            this.btnObtenerAlFinal.Click += new System.EventHandler(this.btnObtenerAlFinal_Click);
            // 
            // btnObtenerAlInicio
            // 
            this.btnObtenerAlInicio.Location = new System.Drawing.Point(296, 94);
            this.btnObtenerAlInicio.Name = "btnObtenerAlInicio";
            this.btnObtenerAlInicio.Size = new System.Drawing.Size(105, 23);
            this.btnObtenerAlInicio.TabIndex = 57;
            this.btnObtenerAlInicio.Text = "Obtener al inicio";
            this.btnObtenerAlInicio.UseVisualStyleBackColor = true;
            this.btnObtenerAlInicio.Click += new System.EventHandler(this.btnObtenerAlInicio_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(166, 156);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 23);
            this.btnEliminar.TabIndex = 56;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEliminarAlFinal
            // 
            this.btnEliminarAlFinal.Location = new System.Drawing.Point(166, 125);
            this.btnEliminarAlFinal.Name = "btnEliminarAlFinal";
            this.btnEliminarAlFinal.Size = new System.Drawing.Size(107, 23);
            this.btnEliminarAlFinal.TabIndex = 55;
            this.btnEliminarAlFinal.Text = "Eliminar al final";
            this.btnEliminarAlFinal.UseVisualStyleBackColor = true;
            this.btnEliminarAlFinal.Click += new System.EventHandler(this.btnEliminarAlFinal_Click);
            // 
            // btnEliminarAlInicio
            // 
            this.btnEliminarAlInicio.Location = new System.Drawing.Point(166, 94);
            this.btnEliminarAlInicio.Name = "btnEliminarAlInicio";
            this.btnEliminarAlInicio.Size = new System.Drawing.Size(107, 23);
            this.btnEliminarAlInicio.TabIndex = 54;
            this.btnEliminarAlInicio.Text = "Eliminar al inicio";
            this.btnEliminarAlInicio.UseVisualStyleBackColor = true;
            this.btnEliminarAlInicio.Click += new System.EventHandler(this.btnEliminarAlInicio_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(38, 156);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(103, 23);
            this.btnInsertar.TabIndex = 53;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnAgregarAlFinal
            // 
            this.btnAgregarAlFinal.Location = new System.Drawing.Point(38, 125);
            this.btnAgregarAlFinal.Name = "btnAgregarAlFinal";
            this.btnAgregarAlFinal.Size = new System.Drawing.Size(103, 23);
            this.btnAgregarAlFinal.TabIndex = 52;
            this.btnAgregarAlFinal.Text = "Agregar al final";
            this.btnAgregarAlFinal.UseVisualStyleBackColor = true;
            this.btnAgregarAlFinal.Click += new System.EventHandler(this.btnAgregarAlFinal_Click);
            // 
            // btnAgregarAlInicio
            // 
            this.btnAgregarAlInicio.Location = new System.Drawing.Point(38, 94);
            this.btnAgregarAlInicio.Name = "btnAgregarAlInicio";
            this.btnAgregarAlInicio.Size = new System.Drawing.Size(103, 23);
            this.btnAgregarAlInicio.TabIndex = 51;
            this.btnAgregarAlInicio.Text = "Agregar al inicio";
            this.btnAgregarAlInicio.UseVisualStyleBackColor = true;
            this.btnAgregarAlInicio.Click += new System.EventHandler(this.btnAgregarAlInicio_Click);
            // 
            // lbDatos
            // 
            this.lbDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbDatos.FormattingEnabled = true;
            this.lbDatos.Location = new System.Drawing.Point(677, 0);
            this.lbDatos.Name = "lbDatos";
            this.lbDatos.Size = new System.Drawing.Size(314, 245);
            this.lbDatos.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 245);
            this.Controls.Add(this.lbDatos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCrearListaDoblementeEnlazada;
        private System.Windows.Forms.Button btnCrearSimple;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.Button btnObtenerAlFinal;
        private System.Windows.Forms.Button btnObtenerAlInicio;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEliminarAlFinal;
        private System.Windows.Forms.Button btnEliminarAlInicio;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnAgregarAlFinal;
        private System.Windows.Forms.Button btnAgregarAlInicio;
        private System.Windows.Forms.ListBox lbDatos;
    }
}

