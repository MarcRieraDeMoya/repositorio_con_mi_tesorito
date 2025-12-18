namespace ICOMPARABLE_RECTANGLES
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOrdenarNom = new System.Windows.Forms.Button();
            this.dvRectangles = new System.Windows.Forms.DataGridView();
            this.btnOrdenarX = new System.Windows.Forms.Button();
            this.btnOrdenarAmplada = new System.Windows.Forms.Button();
            this.btnOrdenarArea = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvRectangles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOrdenarNom
            // 
            this.btnOrdenarNom.Location = new System.Drawing.Point(16, 15);
            this.btnOrdenarNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrdenarNom.Name = "btnOrdenarNom";
            this.btnOrdenarNom.Size = new System.Drawing.Size(129, 63);
            this.btnOrdenarNom.TabIndex = 0;
            this.btnOrdenarNom.Text = "ORDENAR PER NOM";
            this.btnOrdenarNom.UseVisualStyleBackColor = true;
            this.btnOrdenarNom.Click += new System.EventHandler(this.btnOrdenarNom_Click);
            // 
            // dvRectangles
            // 
            this.dvRectangles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvRectangles.Location = new System.Drawing.Point(16, 85);
            this.dvRectangles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dvRectangles.Name = "dvRectangles";
            this.dvRectangles.RowHeadersWidth = 51;
            this.dvRectangles.Size = new System.Drawing.Size(659, 454);
            this.dvRectangles.TabIndex = 1;
            // 
            // btnOrdenarX
            // 
            this.btnOrdenarX.Location = new System.Drawing.Point(153, 15);
            this.btnOrdenarX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrdenarX.Name = "btnOrdenarX";
            this.btnOrdenarX.Size = new System.Drawing.Size(129, 63);
            this.btnOrdenarX.TabIndex = 2;
            this.btnOrdenarX.Text = "ORDENAR PER X";
            this.btnOrdenarX.UseVisualStyleBackColor = true;
            this.btnOrdenarX.Click += new System.EventHandler(this.btnOrdenarX_Click);
            // 
            // btnOrdenarAmplada
            // 
            this.btnOrdenarAmplada.Location = new System.Drawing.Point(291, 15);
            this.btnOrdenarAmplada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrdenarAmplada.Name = "btnOrdenarAmplada";
            this.btnOrdenarAmplada.Size = new System.Drawing.Size(129, 63);
            this.btnOrdenarAmplada.TabIndex = 3;
            this.btnOrdenarAmplada.Text = "ORDENAR PER AMPLADA";
            this.btnOrdenarAmplada.UseVisualStyleBackColor = true;
            this.btnOrdenarAmplada.Click += new System.EventHandler(this.btnOrdenarAmplada_Click);
            // 
            // btnOrdenarArea
            // 
            this.btnOrdenarArea.Location = new System.Drawing.Point(428, 15);
            this.btnOrdenarArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrdenarArea.Name = "btnOrdenarArea";
            this.btnOrdenarArea.Size = new System.Drawing.Size(129, 63);
            this.btnOrdenarArea.TabIndex = 4;
            this.btnOrdenarArea.Text = "ORDENAR PER AREA";
            this.btnOrdenarArea.UseVisualStyleBackColor = true;
            this.btnOrdenarArea.Click += new System.EventHandler(this.btnOrdenarArea_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 554);
            this.Controls.Add(this.btnOrdenarArea);
            this.Controls.Add(this.btnOrdenarAmplada);
            this.Controls.Add(this.btnOrdenarX);
            this.Controls.Add(this.dvRectangles);
            this.Controls.Add(this.btnOrdenarNom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvRectangles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrdenarNom;
        private System.Windows.Forms.DataGridView dvRectangles;
        private System.Windows.Forms.Button btnOrdenarX;
        private System.Windows.Forms.Button btnOrdenarAmplada;
        private System.Windows.Forms.Button btnOrdenarArea;
    }
}

