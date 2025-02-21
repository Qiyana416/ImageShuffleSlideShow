namespace ImageShuffleSlideShow
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            titleBar = new TableLayoutPanel();
            btnFullScreen = new Button();
            titleTxt = new Label();
            titleImg = new PictureBox();
            btnExit = new Button();
            panelTopImgPreview = new Panel();
            labelPreview = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            DropDownTimer = new System.Windows.Forms.Timer(components);
            browsePanel = new TableLayoutPanel();
            btnBrowse = new Button();
            txtBoxBrowsePath = new VerticalTextBox();
            labelImageExists = new Label();
            langPanelM = new Panel();
            langPanelD = new Panel();
            langJpn = new Button();
            langKor = new Button();
            langEng = new Button();
            btnDropdown = new Button();
            labelImgCnt = new Label();
            btnStartSlideShow = new Button();
            btnShuffle = new Button();
            ImgFilesInPath = new WithoutScrollbarListBoxControl();
            labelNoticeCopy = new Label();
            noticeClipboardTimerSec = new System.Windows.Forms.Timer(components);
            noticeClipboardTimerColor = new System.Windows.Forms.Timer(components);
            panelImgPreview = new Panel();
            ImgPreview = new DevExpress.XtraEditors.Controls.ImageSlider();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtBoxSearch = new VerticalTextBox();
            titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)titleImg).BeginInit();
            panelTopImgPreview.SuspendLayout();
            browsePanel.SuspendLayout();
            langPanelM.SuspendLayout();
            langPanelD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImgFilesInPath).BeginInit();
            panelImgPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImgPreview).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // titleBar
            // 
            resources.ApplyResources(titleBar, "titleBar");
            titleBar.BackColor = Color.DimGray;
            titleBar.Controls.Add(btnFullScreen, 2, 0);
            titleBar.Controls.Add(titleTxt, 1, 0);
            titleBar.Controls.Add(titleImg, 0, 0);
            titleBar.Controls.Add(btnExit, 3, 0);
            titleBar.Controls.Add(panelTopImgPreview, 4, 0);
            titleBar.Name = "titleBar";
            titleBar.MouseDown += titleBar_MouseDown;
            titleBar.MouseMove += titleBar_MouseMove;
            titleBar.MouseUp += titleBar_MouseUp;
            // 
            // btnFullScreen
            // 
            resources.ApplyResources(btnFullScreen, "btnFullScreen");
            btnFullScreen.BackColor = Color.FromArgb(211, 227, 255);
            btnFullScreen.FlatAppearance.BorderSize = 0;
            btnFullScreen.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 242, 255);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.UseVisualStyleBackColor = false;
            // 
            // titleTxt
            // 
            resources.ApplyResources(titleTxt, "titleTxt");
            titleTxt.ForeColor = Color.FromArgb(228, 183, 208);
            titleTxt.Name = "titleTxt";
            titleTxt.MouseDown += titleBar_MouseDown;
            titleTxt.MouseMove += titleBar_MouseMove;
            titleTxt.MouseUp += titleBar_MouseUp;
            // 
            // titleImg
            // 
            resources.ApplyResources(titleImg, "titleImg");
            titleImg.BackgroundImage = Properties.Resources.Shuffle;
            titleImg.Name = "titleImg";
            titleImg.TabStop = false;
            titleImg.MouseDown += titleBar_MouseDown;
            titleImg.MouseMove += titleBar_MouseMove;
            titleImg.MouseUp += titleBar_MouseUp;
            // 
            // btnExit
            // 
            resources.ApplyResources(btnExit, "btnExit");
            btnExit.BackColor = Color.FromArgb(249, 112, 112);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 164, 164);
            btnExit.Name = "btnExit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.MouseClick += btnExitClicked;
            // 
            // panelTopImgPreview
            // 
            resources.ApplyResources(panelTopImgPreview, "panelTopImgPreview");
            panelTopImgPreview.BackColor = Color.DimGray;
            panelTopImgPreview.Controls.Add(labelPreview);
            panelTopImgPreview.Controls.Add(tableLayoutPanel1);
            panelTopImgPreview.Name = "panelTopImgPreview";
            panelTopImgPreview.MouseDown += titleBar_MouseDown;
            panelTopImgPreview.MouseMove += titleBar_MouseMove;
            panelTopImgPreview.MouseUp += titleBar_MouseUp;
            // 
            // labelPreview
            // 
            resources.ApplyResources(labelPreview, "labelPreview");
            labelPreview.ForeColor = Color.FromArgb(228, 183, 208);
            labelPreview.Name = "labelPreview";
            labelPreview.MouseDown += titleBar_MouseDown;
            labelPreview.MouseMove += titleBar_MouseMove;
            labelPreview.MouseUp += titleBar_MouseUp;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // DropDownTimer
            // 
            DropDownTimer.Enabled = true;
            DropDownTimer.Interval = 1;
            DropDownTimer.Tick += DropDownTimer_Tick;
            // 
            // browsePanel
            // 
            resources.ApplyResources(browsePanel, "browsePanel");
            browsePanel.Controls.Add(btnBrowse, 0, 0);
            browsePanel.Controls.Add(txtBoxBrowsePath, 1, 0);
            browsePanel.Name = "browsePanel";
            // 
            // btnBrowse
            // 
            resources.ApplyResources(btnBrowse, "btnBrowse");
            btnBrowse.BackColor = Color.FromArgb(108, 117, 125);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.ForeColor = Color.FromArgb(236, 216, 135);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtBoxBrowsePath
            // 
            resources.ApplyResources(txtBoxBrowsePath, "txtBoxBrowsePath");
            txtBoxBrowsePath.BackColor = Color.FromArgb(248, 245, 233);
            txtBoxBrowsePath.BorderColor = Color.Gray;
            txtBoxBrowsePath.LeftRightPadding = 2U;
            txtBoxBrowsePath.Name = "txtBoxBrowsePath";
            txtBoxBrowsePath.TextAlign = HorizontalAlignment.Left;
            txtBoxBrowsePath.TextChanged += txtBoxBrowsePath_TextChanged;
            // 
            // labelImageExists
            // 
            resources.ApplyResources(labelImageExists, "labelImageExists");
            labelImageExists.BackColor = Color.Transparent;
            labelImageExists.ForeColor = Color.FromArgb(199, 199, 199);
            labelImageExists.Name = "labelImageExists";
            // 
            // langPanelM
            // 
            resources.ApplyResources(langPanelM, "langPanelM");
            langPanelM.Controls.Add(langPanelD);
            langPanelM.Controls.Add(btnDropdown);
            langPanelM.Name = "langPanelM";
            // 
            // langPanelD
            // 
            resources.ApplyResources(langPanelD, "langPanelD");
            langPanelD.Controls.Add(langJpn);
            langPanelD.Controls.Add(langKor);
            langPanelD.Controls.Add(langEng);
            langPanelD.Name = "langPanelD";
            // 
            // langJpn
            // 
            resources.ApplyResources(langJpn, "langJpn");
            langJpn.BackColor = Color.FromArgb(108, 117, 125);
            langJpn.Cursor = Cursors.Hand;
            langJpn.FlatAppearance.BorderSize = 0;
            langJpn.ForeColor = Color.FromArgb(64, 64, 64);
            langJpn.Name = "langJpn";
            langJpn.UseVisualStyleBackColor = false;
            langJpn.Click += langJpn_Click;
            // 
            // langKor
            // 
            resources.ApplyResources(langKor, "langKor");
            langKor.BackColor = Color.FromArgb(108, 117, 125);
            langKor.Cursor = Cursors.Hand;
            langKor.FlatAppearance.BorderSize = 0;
            langKor.ForeColor = Color.FromArgb(64, 64, 64);
            langKor.Name = "langKor";
            langKor.UseVisualStyleBackColor = false;
            langKor.Click += langKor_Click;
            // 
            // langEng
            // 
            resources.ApplyResources(langEng, "langEng");
            langEng.BackColor = Color.FromArgb(108, 117, 125);
            langEng.Cursor = Cursors.Hand;
            langEng.FlatAppearance.BorderSize = 0;
            langEng.ForeColor = Color.FromArgb(64, 64, 64);
            langEng.Name = "langEng";
            langEng.UseVisualStyleBackColor = false;
            langEng.Click += langEng_Click;
            // 
            // btnDropdown
            // 
            resources.ApplyResources(btnDropdown, "btnDropdown");
            btnDropdown.BackColor = Color.FromArgb(108, 117, 125);
            btnDropdown.BackgroundImage = Properties.Resources.downArrow;
            btnDropdown.Cursor = Cursors.Hand;
            btnDropdown.FlatAppearance.BorderSize = 0;
            btnDropdown.ForeColor = Color.FromArgb(255, 224, 192);
            btnDropdown.Name = "btnDropdown";
            btnDropdown.UseVisualStyleBackColor = false;
            btnDropdown.Click += langDropdown_Click;
            // 
            // labelImgCnt
            // 
            resources.ApplyResources(labelImgCnt, "labelImgCnt");
            labelImgCnt.BackColor = Color.Transparent;
            labelImgCnt.ForeColor = Color.FromArgb(150, 150, 150);
            labelImgCnt.Name = "labelImgCnt";
            // 
            // btnStartSlideShow
            // 
            resources.ApplyResources(btnStartSlideShow, "btnStartSlideShow");
            btnStartSlideShow.BackColor = Color.FromArgb(108, 117, 125);
            btnStartSlideShow.Cursor = Cursors.Hand;
            btnStartSlideShow.FlatAppearance.BorderSize = 0;
            btnStartSlideShow.ForeColor = Color.FromArgb(236, 216, 135);
            btnStartSlideShow.Name = "btnStartSlideShow";
            btnStartSlideShow.UseVisualStyleBackColor = false;
            btnStartSlideShow.Click += btnStartSlideShow_Click;
            // 
            // btnShuffle
            // 
            resources.ApplyResources(btnShuffle, "btnShuffle");
            btnShuffle.BackColor = Color.FromArgb(108, 117, 125);
            btnShuffle.BackgroundImage = Properties.Resources.btnShuffle;
            btnShuffle.Cursor = Cursors.Hand;
            btnShuffle.FlatAppearance.BorderSize = 0;
            btnShuffle.ForeColor = Color.FromArgb(236, 216, 135);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.UseVisualStyleBackColor = false;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // ImgFilesInPath
            // 
            resources.ApplyResources(ImgFilesInPath, "ImgFilesInPath");
            ImgFilesInPath.Appearance.BackColor = (Color)resources.GetObject("ImgFilesInPath.Appearance.BackColor");
            ImgFilesInPath.Appearance.Font = (Font)resources.GetObject("ImgFilesInPath.Appearance.Font");
            ImgFilesInPath.Appearance.ForeColor = (Color)resources.GetObject("ImgFilesInPath.Appearance.ForeColor");
            ImgFilesInPath.Appearance.Options.UseBackColor = true;
            ImgFilesInPath.Appearance.Options.UseFont = true;
            ImgFilesInPath.Appearance.Options.UseForeColor = true;
            ImgFilesInPath.AppearanceSelected.BackColor = (Color)resources.GetObject("ImgFilesInPath.AppearanceSelected.BackColor");
            ImgFilesInPath.AppearanceSelected.Options.UseBackColor = true;
            ImgFilesInPath.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            ImgFilesInPath.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
            ImgFilesInPath.LookAndFeel.UseDefaultLookAndFeel = false;
            ImgFilesInPath.Name = "ImgFilesInPath";
            ImgFilesInPath.ShowFocusRect = false;
            ImgFilesInPath.SelectedIndexChanged += ImgFilesInPath_SelectedIndexChanged;
            ImgFilesInPath.DrawItem += ImgFilesInPath_DrawItem;
            ImgFilesInPath.MouseClick += ImgFilesInPath_MouseClick;
            ImgFilesInPath.MouseDoubleClick += ImgFilesInPath_MouseDoubleClick;
            ImgFilesInPath.MouseLeave += ImgFilesInPath_MouseLeave;
            ImgFilesInPath.MouseMove += ImgFilesInPath_MouseMove;
            // 
            // labelNoticeCopy
            // 
            resources.ApplyResources(labelNoticeCopy, "labelNoticeCopy");
            labelNoticeCopy.BackColor = Color.Transparent;
            labelNoticeCopy.ForeColor = Color.FromArgb(159, 188, 247);
            labelNoticeCopy.Name = "labelNoticeCopy";
            // 
            // noticeClipboardTimerSec
            // 
            noticeClipboardTimerSec.Enabled = true;
            noticeClipboardTimerSec.Interval = 1000;
            noticeClipboardTimerSec.Tick += noticeClipboardTimerSec_Tick;
            // 
            // noticeClipboardTimerColor
            // 
            noticeClipboardTimerColor.Enabled = true;
            noticeClipboardTimerColor.Interval = 50;
            noticeClipboardTimerColor.Tick += noticeClipboardTimerColor_Tick;
            // 
            // panelImgPreview
            // 
            resources.ApplyResources(panelImgPreview, "panelImgPreview");
            panelImgPreview.BackColor = Color.FromArgb(74, 74, 74);
            panelImgPreview.BorderStyle = BorderStyle.Fixed3D;
            panelImgPreview.Controls.Add(ImgPreview);
            panelImgPreview.Name = "panelImgPreview";
            // 
            // ImgPreview
            // 
            resources.ApplyResources(ImgPreview, "ImgPreview");
            ImgPreview.Appearance.BackColor = (Color)resources.GetObject("ImgPreview.Appearance.BackColor");
            ImgPreview.Appearance.Options.UseBackColor = true;
            ImgPreview.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            ImgPreview.LookAndFeel.UseDefaultLookAndFeel = false;
            ImgPreview.Name = "ImgPreview";
            ImgPreview.ScrollButtonVisibility = DevExpress.Utils.DefaultBoolean.False;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(txtBoxSearch, 0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // txtBoxSearch
            // 
            resources.ApplyResources(txtBoxSearch, "txtBoxSearch");
            txtBoxSearch.BackColor = Color.FromArgb(248, 245, 233);
            txtBoxSearch.BorderColor = Color.Gray;
            txtBoxSearch.LeftRightPadding = 10U;
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.TextAlign = HorizontalAlignment.Left;
            txtBoxSearch.TextChanged += txtBoxSearch_TextChanged;
            txtBoxSearch.Enter += txtBoxSearch_Enter;
            txtBoxSearch.Leave += txtBoxSearch_Leave;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(panelImgPreview);
            Controls.Add(labelNoticeCopy);
            Controls.Add(ImgFilesInPath);
            Controls.Add(langPanelM);
            Controls.Add(browsePanel);
            Controls.Add(titleBar);
            Controls.Add(labelImageExists);
            Controls.Add(labelImgCnt);
            Controls.Add(btnStartSlideShow);
            Controls.Add(btnShuffle);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "MainForm";
            Load += Program_Load;
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)titleImg).EndInit();
            panelTopImgPreview.ResumeLayout(false);
            panelTopImgPreview.PerformLayout();
            browsePanel.ResumeLayout(false);
            langPanelM.ResumeLayout(false);
            langPanelD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ImgFilesInPath).EndInit();
            panelImgPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ImgPreview).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel titleBar;
        private Label titleTxt;
        private PictureBox titleImg;
        private System.Windows.Forms.Timer DropDownTimer;
        private Button btnExit;
        private Button btnFullScreen;
        private TableLayoutPanel browsePanel;
        private Button btnBrowse;
        private Label labelImageExists;
        private Panel langPanelM;
        private Panel langPanelD;
        private Button langKor;
        private Button langEng;
        private Button btnDropdown;
        private Label labelImgCnt;
        private Button btnStartSlideShow;
        private Button btnShuffle;
        private VerticalTextBox txtBoxBrowsePath;
        private WithoutScrollbarListBoxControl ImgFilesInPath;
        private Label labelNoticeCopy;
        private System.Windows.Forms.Timer noticeClipboardTimerSec;
        private System.Windows.Forms.Timer noticeClipboardTimerColor;
        private Panel panelTopImgPreview;
        private Panel panelImgPreview;
        private DevExpress.XtraEditors.Controls.ImageSlider ImgPreview;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelPreview;
        private TableLayoutPanel tableLayoutPanel2;
        private VerticalTextBox txtBoxSearch;
        private Button langJpn;
    }
}
