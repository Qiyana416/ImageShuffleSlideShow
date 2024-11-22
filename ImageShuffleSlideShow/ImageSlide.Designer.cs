using DevExpress.XtraEditors.Controls;

namespace ImageShuffleSlideShow
{
    partial class ImageSlide
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
            imageSlider = new ImageSlider();
            ToLeft = new Label();
            ToRight = new Label();
            ((System.ComponentModel.ISupportInitialize)imageSlider).BeginInit();
            SuspendLayout();
            // 
            // imageSlider
            // 
            imageSlider.Appearance.BackColor = Color.FromArgb(64, 64, 64);
            imageSlider.Appearance.Options.UseBackColor = true;
            imageSlider.Dock = DockStyle.Fill;
            imageSlider.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            imageSlider.Location = new Point(0, 0);
            imageSlider.LookAndFeel.UseDefaultLookAndFeel = false;
            imageSlider.Margin = new Padding(0);
            imageSlider.Name = "imageSlider";
            imageSlider.ScrollButtonVisibility = DevExpress.Utils.DefaultBoolean.False;
            imageSlider.Size = new Size(298, 268);
            imageSlider.TabIndex = 0;
            imageSlider.PreviewKeyDown += ImageSlide_PreviewKeyDown;
            // 
            // ToLeft
            // 
            ToLeft.Font = new Font("한컴 말랑말랑 Regular", 40F, FontStyle.Bold);
            ToLeft.ForeColor = Color.Black;
            ToLeft.Location = new Point(0, 3);
            ToLeft.Name = "ToLeft";
            ToLeft.Size = new Size(50, 260);
            ToLeft.TabIndex = 1;
            ToLeft.Text = "<";
            ToLeft.TextAlign = ContentAlignment.MiddleCenter;
            ToLeft.MouseClick += ToLeft_MouseClick;
            ToLeft.MouseEnter += MouseEnterInScreen;
            ToLeft.MouseLeave += MouseLeaveInScreen;
            // 
            // ToRight
            // 
            ToRight.Font = new Font("한컴 말랑말랑 Regular", 40F, FontStyle.Bold);
            ToRight.ForeColor = Color.Black;
            ToRight.Location = new Point(248, 3);
            ToRight.Name = "ToRight";
            ToRight.Size = new Size(50, 260);
            ToRight.TabIndex = 2;
            ToRight.Text = ">";
            ToRight.TextAlign = ContentAlignment.MiddleCenter;
            ToRight.MouseClick += ToRight_MouseClick;
            ToRight.MouseEnter += MouseEnterInScreen;
            ToRight.MouseLeave += MouseLeaveInScreen;
            // 
            // ImageSlide
            // 
            Appearance.BackColor = Color.FromArgb(64, 64, 64);
            Appearance.ForeColor = Color.FromArgb(199, 199, 199);
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseFont = true;
            Appearance.Options.UseForeColor = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 268);
            Controls.Add(ToRight);
            Controls.Add(ToLeft);
            Controls.Add(imageSlider);
            Font = new Font("한컴 말랑말랑 Regular", 9F);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            IconOptions.ShowIcon = false;
            KeyPreview = true;
            Name = "ImageSlide";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImageSlide";
            Load += ImageSlide_Load;
            SizeChanged += ImageSlide_SizeChanged;
            PreviewKeyDown += ImageSlide_PreviewKeyDown;
            ((System.ComponentModel.ISupportInitialize)imageSlider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider;
        private Label ToLeft;
        private Label ToRight;
    }
}