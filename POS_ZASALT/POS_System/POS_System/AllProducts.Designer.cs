namespace POS_System
{
    partial class AllProducts
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
            ProductsPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // ProductsPanel
            // 
            ProductsPanel.BackColor = SystemColors.ButtonHighlight;
            ProductsPanel.Location = new Point(15, 10);
            ProductsPanel.Name = "ProductsPanel";
            ProductsPanel.Size = new Size(873, 428);
            ProductsPanel.TabIndex = 0;
            ProductsPanel.Paint += ProductsPanel_Paint;
            // 
            // AllProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 450);
            Controls.Add(ProductsPanel);
            Name = "AllProducts";
            Text = "AllProducts";
            Load += AllProducts_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel ProductsPanel;
    }
}