namespace EEDID_Viewer
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ManufacturerName = new System.Windows.Forms.Label();
            this.ProductCode = new System.Windows.Forms.Label();
            this.WeekManufacture = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.Label();
            this.IsModelYear = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.Gamma = new System.Windows.Forms.Label();
            this.ExtensionBlockCount = new System.Windows.Forms.Label();
            this.Checksum = new System.Windows.Forms.Label();
            this.EstablishedTimingTable = new System.Windows.Forms.DataGridView();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DumpData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EstablishedTimingTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ManufacturerName
            // 
            this.ManufacturerName.AutoSize = true;
            this.ManufacturerName.Location = new System.Drawing.Point(13, 13);
            this.ManufacturerName.Name = "ManufacturerName";
            this.ManufacturerName.Size = new System.Drawing.Size(107, 13);
            this.ManufacturerName.TabIndex = 0;
            this.ManufacturerName.Text = "Manufacturer Name: ";
            // 
            // ProductCode
            // 
            this.ProductCode.AutoSize = true;
            this.ProductCode.Location = new System.Drawing.Point(45, 41);
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Size = new System.Drawing.Size(75, 13);
            this.ProductCode.TabIndex = 1;
            this.ProductCode.Text = "Product Code:";
            // 
            // WeekManufacture
            // 
            this.WeekManufacture.AutoSize = true;
            this.WeekManufacture.Location = new System.Drawing.Point(18, 69);
            this.WeekManufacture.Name = "WeekManufacture";
            this.WeekManufacture.Size = new System.Drawing.Size(102, 13);
            this.WeekManufacture.TabIndex = 2;
            this.WeekManufacture.Text = "Week Manufacture:";
            // 
            // Year
            // 
            this.Year.AutoSize = true;
            this.Year.Location = new System.Drawing.Point(88, 97);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(32, 13);
            this.Year.TabIndex = 3;
            this.Year.Text = "Year:";
            // 
            // IsModelYear
            // 
            this.IsModelYear.AutoSize = true;
            this.IsModelYear.Location = new System.Drawing.Point(51, 125);
            this.IsModelYear.Name = "IsModelYear";
            this.IsModelYear.Size = new System.Drawing.Size(69, 13);
            this.IsModelYear.TabIndex = 4;
            this.IsModelYear.Text = "IsModelYear:";
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(75, 153);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(45, 13);
            this.Version.TabIndex = 5;
            this.Version.Text = "Version:";
            // 
            // Gamma
            // 
            this.Gamma.AutoSize = true;
            this.Gamma.Location = new System.Drawing.Point(74, 181);
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(46, 13);
            this.Gamma.TabIndex = 6;
            this.Gamma.Text = "Gamma:";
            // 
            // ExtensionBlockCount
            // 
            this.ExtensionBlockCount.AutoSize = true;
            this.ExtensionBlockCount.Location = new System.Drawing.Point(3, 209);
            this.ExtensionBlockCount.Name = "ExtensionBlockCount";
            this.ExtensionBlockCount.Size = new System.Drawing.Size(117, 13);
            this.ExtensionBlockCount.TabIndex = 7;
            this.ExtensionBlockCount.Text = "Extension Block Count:";
            // 
            // Checksum
            // 
            this.Checksum.AutoSize = true;
            this.Checksum.Location = new System.Drawing.Point(60, 237);
            this.Checksum.Name = "Checksum";
            this.Checksum.Size = new System.Drawing.Size(60, 13);
            this.Checksum.TabIndex = 8;
            this.Checksum.Text = "Checksum:";
            // 
            // EstablishedTimingTable
            // 
            this.EstablishedTimingTable.AllowUserToAddRows = false;
            this.EstablishedTimingTable.AllowUserToDeleteRows = false;
            this.EstablishedTimingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EstablishedTimingTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Width,
            this.Height,
            this.Frequency});
            this.EstablishedTimingTable.Location = new System.Drawing.Point(12, 288);
            this.EstablishedTimingTable.Name = "EstablishedTimingTable";
            this.EstablishedTimingTable.ReadOnly = true;
            this.EstablishedTimingTable.Size = new System.Drawing.Size(345, 150);
            this.EstablishedTimingTable.TabIndex = 9;
            // 
            // Width
            // 
            this.Width.HeaderText = "Width (px)";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            this.Width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Height
            // 
            this.Height.HeaderText = "Height (px)";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            this.Height.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency (Hz)";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DumpData
            // 
            this.DumpData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DumpData.Location = new System.Drawing.Point(297, 9);
            this.DumpData.Name = "DumpData";
            this.DumpData.Size = new System.Drawing.Size(491, 276);
            this.DumpData.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ManufacturerName);
            this.Controls.Add(this.ProductCode);
            this.Controls.Add(this.WeekManufacture);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.IsModelYear);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.ExtensionBlockCount);
            this.Controls.Add(this.Checksum);
            this.Controls.Add(this.EstablishedTimingTable);
            this.Controls.Add(this.DumpData);
            this.Name = "Form1";
            this.Text = "E-EDID Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.EstablishedTimingTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ManufacturerName;
        private System.Windows.Forms.Label ProductCode;
        private System.Windows.Forms.Label WeekManufacture;
        private System.Windows.Forms.Label Year;
        private System.Windows.Forms.Label IsModelYear;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label Gamma;
        private System.Windows.Forms.Label ExtensionBlockCount;
        private System.Windows.Forms.Label Checksum;
        private System.Windows.Forms.DataGridView EstablishedTimingTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.Label DumpData;
    }
}

