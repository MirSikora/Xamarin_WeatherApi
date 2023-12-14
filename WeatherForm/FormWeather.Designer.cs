namespace WeatherForms {
    partial class FormWeather {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lbCity = new Label();
            lbWeather = new Label();
            lbTemperature = new Label();
            lbWind = new Label();
            lbPrecipitation = new Label();
            cbCities = new ComboBox();
            pbWeather = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbWeather).BeginInit();
            SuspendLayout();
            // 
            // lbCity
            // 
            lbCity.AutoSize = true;
            lbCity.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lbCity.Location = new Point(237, 111);
            lbCity.Name = "lbCity";
            lbCity.Size = new Size(92, 51);
            lbCity.TabIndex = 0;
            lbCity.Text = "City";
            // 
            // lbWeather
            // 
            lbWeather.AutoSize = true;
            lbWeather.Location = new Point(285, 184);
            lbWeather.Name = "lbWeather";
            lbWeather.Size = new Size(77, 25);
            lbWeather.TabIndex = 1;
            lbWeather.Text = "Weather";
            // 
            // lbTemperature
            // 
            lbTemperature.AutoSize = true;
            lbTemperature.Location = new Point(285, 224);
            lbTemperature.Name = "lbTemperature";
            lbTemperature.Size = new Size(110, 25);
            lbTemperature.TabIndex = 2;
            lbTemperature.Text = "Temperature";
            // 
            // lbWind
            // 
            lbWind.AutoSize = true;
            lbWind.Location = new Point(285, 265);
            lbWind.Name = "lbWind";
            lbWind.Size = new Size(54, 25);
            lbWind.TabIndex = 3;
            lbWind.Text = "Wind";
            // 
            // lbPrecipitation
            // 
            lbPrecipitation.AutoSize = true;
            lbPrecipitation.Location = new Point(285, 305);
            lbPrecipitation.Name = "lbPrecipitation";
            lbPrecipitation.Size = new Size(110, 25);
            lbPrecipitation.TabIndex = 4;
            lbPrecipitation.Text = "Precipitation";
            // 
            // cbCities
            // 
            cbCities.FormattingEnabled = true;
            cbCities.Items.AddRange(new object[] { "Ostrava", "Rovaniemi", "Rome", "Sydney", "Reykjavik" });
            cbCities.Location = new Point(164, 49);
            cbCities.Name = "cbCities";
            cbCities.Size = new Size(308, 33);
            cbCities.TabIndex = 5;
            cbCities.SelectedIndexChanged += cbCities_SelectedIndexChanged;
            // 
            // pbWeather
            // 
            pbWeather.Location = new Point(137, 184);
            pbWeather.Name = "pbWeather";
            pbWeather.Size = new Size(133, 132);
            pbWeather.SizeMode = PictureBoxSizeMode.StretchImage;
            pbWeather.TabIndex = 6;
            pbWeather.TabStop = false;
            // 
            // WeatherForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 450);
            Controls.Add(pbWeather);
            Controls.Add(cbCities);
            Controls.Add(lbPrecipitation);
            Controls.Add(lbWind);
            Controls.Add(lbTemperature);
            Controls.Add(lbWeather);
            Controls.Add(lbCity);
            Name = "WeatherForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WeatherForm";
            ((System.ComponentModel.ISupportInitialize)pbWeather).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbCity;
        private Label lbWeather;
        private Label lbTemperature;
        private Label lbWind;
        private Label lbPrecipitation;
        private ComboBox cbCities;
        private PictureBox pbWeather;
    }
}
