namespace testingForm
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
            Button b1 = new Button();
            this.SuspendLayout();
            //
            // b1
            //
            b1.Location = new System.Drawing.Point(350, 200);
            b1.Name = "b1";
            b1.Size = new System.Drawing.Size(100, 50);
            b1.TabIndex = 0;
            b1.Text = "Click Me";
            b1.UseVisualStyleBackColor = true;
            //b1.Click += new System.EventHandler(this.b1_Click);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}
