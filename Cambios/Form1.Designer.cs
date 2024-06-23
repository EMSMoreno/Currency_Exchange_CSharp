namespace Cambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            TextBoxValor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ComboBoxOrigem = new ComboBox();
            ComboBoxDestino = new ComboBox();
            ButtonConverter = new Button();
            LabelResultado = new Label();
            LabelStatus = new Label();
            ProgressBar1 = new ProgressBar();
            buttonTroca = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 46);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 0;
            label1.Text = "Valor:";
            // 
            // TextBoxValor
            // 
            TextBoxValor.Location = new Point(163, 45);
            TextBoxValor.Name = "TextBoxValor";
            TextBoxValor.Size = new Size(167, 23);
            TextBoxValor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 99);
            label2.Name = "label2";
            label2.Size = new Size(123, 17);
            label2.TabIndex = 2;
            label2.Text = "Moeda de Origem:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 154);
            label3.Name = "label3";
            label3.Size = new Size(125, 17);
            label3.TabIndex = 3;
            label3.Text = "Moeda de Destino:";
            // 
            // ComboBoxOrigem
            // 
            ComboBoxOrigem.FormattingEnabled = true;
            ComboBoxOrigem.Location = new Point(163, 98);
            ComboBoxOrigem.Name = "ComboBoxOrigem";
            ComboBoxOrigem.Size = new Size(167, 23);
            ComboBoxOrigem.TabIndex = 4;
            // 
            // ComboBoxDestino
            // 
            ComboBoxDestino.FormattingEnabled = true;
            ComboBoxDestino.Location = new Point(163, 153);
            ComboBoxDestino.Name = "ComboBoxDestino";
            ComboBoxDestino.Size = new Size(167, 23);
            ComboBoxDestino.TabIndex = 5;
            // 
            // ButtonConverter
            // 
            ButtonConverter.Enabled = false;
            ButtonConverter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonConverter.Location = new Point(381, 34);
            ButtonConverter.Name = "ButtonConverter";
            ButtonConverter.Size = new Size(91, 40);
            ButtonConverter.TabIndex = 6;
            ButtonConverter.Text = "Converter";
            ButtonConverter.UseVisualStyleBackColor = true;
            ButtonConverter.Click += ButtonConverter_Click;
            // 
            // LabelResultado
            // 
            LabelResultado.AutoSize = true;
            LabelResultado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelResultado.Location = new Point(112, 215);
            LabelResultado.Name = "LabelResultado";
            LabelResultado.Size = new Size(290, 17);
            LabelResultado.TabIndex = 7;
            LabelResultado.Text = "Escolha um valor, moeda de origem e destino";
            // 
            // LabelStatus
            // 
            LabelStatus.AutoSize = true;
            LabelStatus.Location = new Point(34, 287);
            LabelStatus.Name = "LabelStatus";
            LabelStatus.Size = new Size(38, 15);
            LabelStatus.TabIndex = 8;
            LabelStatus.Text = "status";
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(381, 287);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(148, 23);
            ProgressBar1.TabIndex = 9;
            // 
            // buttonTroca
            // 
            buttonTroca.Enabled = false;
            buttonTroca.Image = (Image)resources.GetObject("buttonTroca.Image");
            buttonTroca.Location = new Point(381, 115);
            buttonTroca.Name = "buttonTroca";
            buttonTroca.Size = new Size(91, 56);
            buttonTroca.TabIndex = 10;
            buttonTroca.UseVisualStyleBackColor = true;
            buttonTroca.Click += buttonTroca_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 407);
            Controls.Add(buttonTroca);
            Controls.Add(ProgressBar1);
            Controls.Add(LabelStatus);
            Controls.Add(LabelResultado);
            Controls.Add(ButtonConverter);
            Controls.Add(ComboBoxDestino);
            Controls.Add(ComboBoxOrigem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxValor);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Câmbios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxValor;
        private Label label2;
        private Label label3;
        private ComboBox ComboBoxOrigem;
        private ComboBox ComboBoxDestino;
        private Button ButtonConverter;
        private Label LabelResultado;
        private Label LabelStatus;
        private ProgressBar ProgressBar1;
        private Button buttonTroca;
    }
}
