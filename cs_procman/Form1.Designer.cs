namespace TaskManager
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.prop_dgv = new System.Windows.Forms.DataGridView();
            this.name_dgv = new System.Windows.Forms.DataGridView();
            this.log_textbox = new System.Windows.Forms.TextBox();
            this.prop_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.no_chart_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prop_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.name_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prop_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // prop_dgv
            // 
            this.prop_dgv.AllowUserToAddRows = false;
            this.prop_dgv.AllowUserToDeleteRows = false;
            this.prop_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.prop_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prop_dgv.Location = new System.Drawing.Point(288, 12);
            this.prop_dgv.Name = "prop_dgv";
            this.prop_dgv.ReadOnly = true;
            this.prop_dgv.RowHeadersVisible = false;
            this.prop_dgv.RowTemplate.Height = 24;
            this.prop_dgv.Size = new System.Drawing.Size(459, 258);
            this.prop_dgv.TabIndex = 0;
            this.prop_dgv.Click += new System.EventHandler(this.displayGraph);
            // 
            // name_dgv
            // 
            this.name_dgv.AllowUserToAddRows = false;
            this.name_dgv.AllowUserToDeleteRows = false;
            this.name_dgv.AllowUserToOrderColumns = true;
            this.name_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.name_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.name_dgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.name_dgv.Location = new System.Drawing.Point(12, 12);
            this.name_dgv.MultiSelect = false;
            this.name_dgv.Name = "name_dgv";
            this.name_dgv.RowHeadersVisible = false;
            this.name_dgv.RowTemplate.Height = 24;
            this.name_dgv.Size = new System.Drawing.Size(270, 500);
            this.name_dgv.TabIndex = 1;
            this.name_dgv.Click += new System.EventHandler(this.listDetails);
            // 
            // log_textbox
            // 
            this.log_textbox.Location = new System.Drawing.Point(753, 12);
            this.log_textbox.Multiline = true;
            this.log_textbox.Name = "log_textbox";
            this.log_textbox.ReadOnly = true;
            this.log_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log_textbox.Size = new System.Drawing.Size(450, 500);
            this.log_textbox.TabIndex = 3;
            // 
            // prop_chart
            // 
            chartArea1.Name = "prop_chartarea";
            this.prop_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.prop_chart.Legends.Add(legend1);
            this.prop_chart.Location = new System.Drawing.Point(288, 275);
            this.prop_chart.Name = "prop_chart";
            this.prop_chart.Size = new System.Drawing.Size(459, 236);
            this.prop_chart.TabIndex = 4;
            this.prop_chart.Text = "chart1";
            this.prop_chart.Visible = false;
            // 
            // no_chart_label
            // 
            this.no_chart_label.AutoSize = true;
            this.no_chart_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_chart_label.Location = new System.Drawing.Point(358, 379);
            this.no_chart_label.Name = "no_chart_label";
            this.no_chart_label.Size = new System.Drawing.Size(320, 29);
            this.no_chart_label.TabIndex = 5;
            this.no_chart_label.Text = "No Data for this properties";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 523);
            this.Controls.Add(this.prop_chart);
            this.Controls.Add(this.log_textbox);
            this.Controls.Add(this.name_dgv);
            this.Controls.Add(this.prop_dgv);
            this.Controls.Add(this.no_chart_label);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.prop_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.name_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prop_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView prop_dgv;
        private System.Windows.Forms.DataGridView name_dgv;
        private System.Windows.Forms.TextBox log_textbox;
        private System.Windows.Forms.DataVisualization.Charting.Chart prop_chart;
        private System.Windows.Forms.Label no_chart_label;

    }
}

