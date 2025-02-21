using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Path = System.IO.Path;

namespace ImageShuffleSlideShow
{
    public partial class MainForm : Form
    {
        /* Drag */
        bool mouseDown;
        Point lastLocation;

        /* Dropdown */
        int DropdownMaxHeight = 26 * 3;
        bool Dropdown_ON_OFF = false;
        int Dropdown_Speed = 6;
        int pickedLangIndex = 0;

        /* File path */
        string PreviewImg = string.Empty;
        bool pathValid = false;

        /* Listbox */
        int hoveredIndex = -1;
        List<string> imagePaths = new List<string>();
        List<string> FilteredimagePaths = new List<string>();

        List<string> beforeSearch = new List<string>();
        List<string> searchResult = new List<string>();

        /* Copy file name notice */
        int noticeCopySec = 0;

        Language language = new Language();

        public MainForm()
        {
            InitializeComponent();

            this.MouseClick += ClickEmptySpace;
            ChangeLanguage(btnDropdown.Text);
            btnDropdown.MouseWheel += btnLangWheelEvent;

            txtBoxSearch.Text = this.language.txtSearchPlaceholder;
            txtBoxSearch.ForeColor = Color.DarkGray;

            langPanelM.MouseClick += ClickEmptySpace;
            txtBoxBrowsePath.MouseClick += ClickEmptySpace;
            labelImageExists.MouseClick += ClickEmptySpace;

            labelNoticeCopy.ForeColor = this.BackColor;
        }

        private void Program_Load(object sender, EventArgs e)
        {
            // Dropdown close
            defaultProperties_DropDown();

            // Adjust UI DPI
            float dpiFactor = GetCurrentDpiFactor();
            AdjustUIFormDpi(dpiFactor);
        }

        #region Click Empty Space
        private void ClickEmptySpace(object sender, MouseEventArgs e)
        {
            /* Left Click Events */
            if (e.Button == MouseButtons.Left)
            {
                // When user clicked non dropdown space (Language)
                if (this.GetChildAtPoint(e.Location) != langPanelD)
                {
                    defaultProperties_DropDown();
                }

                // When user clicked non path textbox space
                if (this.GetChildAtPoint(e.Location) != txtBoxBrowsePath)
                {
                    txtBoxBrowsePath.DeselectAllText();
                }

                // When user clicked non search box space
                if (this.GetChildAtPoint(e.Location) != txtBoxSearch)
                {
                    txtBoxSearch.DeselectAllText();
                }

                // When user clicked non list box of images
                if (this.GetChildAtPoint(e.Location) != ImgFilesInPath)
                {
                    //ImgFilesInPath.UnSelectAll();
                    ImgFilesInPath.SelectedIndex = -1;

                    PreviewImg = string.Empty;
                    ImgPreview.Images.Clear();
                }
            }
        }
        #endregion

        #region Exit Button
        private void btnExitClicked(object sender, MouseEventArgs e)
        {
            // Exit the program.
            Application.Exit();
        }
        #endregion

        #region Form Drag Method
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y
                    );

                this.Update();
            }
        }
        #endregion

        #region Dropdown Method
        private void defaultProperties_DropDown()
        {
            langPanelM.Height = 78;
            langPanelD.Height = 0;
            Dropdown_ON_OFF = false;
        }

        private void btnLangWheelEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Wheel Up

                if (pickedLangIndex > 0)
                {
                    pickedLangIndex--;
                }
                else
                    pickedLangIndex = 1;
            }

            else if (e.Delta < 0)
            {
                // Wheel Down

                if (pickedLangIndex < 3)
                {
                    pickedLangIndex++;
                }
            }

            // Change Language
            switch (pickedLangIndex)
            {
                case 1:
                    // English
                    ChangeLanguage(langEng.Text);
                    break;

                case 2:
                    // ÇÑ±¹¾î
                    ChangeLanguage(langKor.Text);
                    break;

                case 3:
                    // Japanese
                    ChangeLanguage(langJpn.Text);
                    break;

                default:
                    ChangeLanguage(langEng.Text);
                    break;
            }
        }

        private void langDropdown_Click(object sender, EventArgs e)
        {
            if (Dropdown_ON_OFF == true)
            {
                Dropdown_ON_OFF = false;
            }
            else if (Dropdown_ON_OFF == false)
            {
                Dropdown_ON_OFF = true;
            }
        }

        private void DropDownTimer_Tick(object sender, EventArgs e)
        {
            int btnHeight = btnDropdown.Height;

            if (Dropdown_ON_OFF == true)
            {
                // One of list(button)'s height : 26(It can be change by screen size).
                // Current(2024-11-08) list quantity is 3

                // So this code will reply until height be 78.
                if ((langPanelD.Height + Dropdown_Speed) <= DropdownMaxHeight)
                    langPanelD.Height += Dropdown_Speed;

                else
                    langPanelD.Height = DropdownMaxHeight;

                // +Added master panel too
                if ((langPanelM.Height + Dropdown_Speed) <= DropdownMaxHeight + btnHeight)
                    langPanelM.Height += Dropdown_Speed;

                else
                    langPanelM.Height = DropdownMaxHeight + btnHeight;
            }

            else if (Dropdown_ON_OFF == false)
            {
                // Height never be under 0.
                if ((langPanelD.Height - Dropdown_Speed) >= 0)
                    langPanelD.Height -= Dropdown_Speed;

                else
                    langPanelD.Height = 0;

                // +Added master panel too
                if ((langPanelM.Height - Dropdown_Speed) >= btnHeight)
                    langPanelM.Height -= Dropdown_Speed;

                else
                    langPanelM.Height = btnHeight;
            }
        }
        #endregion

        #region Select Language Method
        private void langEng_Click(object sender, EventArgs e)
        {
            ChangeLanguage(langEng.Text);
        }

        private void langKor_Click(object sender, EventArgs e)
        {
            ChangeLanguage(langKor.Text);
        }

        private void langJpn_Click(object sender, EventArgs e)
        {
            ChangeLanguage(langJpn.Text);
        }
        #endregion

        #region Change Language Method
        private void ChangeLanguage(string Language)
        {
            bool isSearching = (txtBoxSearch.Text == this.language.txtSearchPlaceholder);

            // Update language model
            this.language = new Language(Language);

            #region Dropdown
            /* Dropdown */
            btnDropdown.Text = Language;
            defaultProperties_DropDown();

            // Dropdown list text color set (Selected language)
            foreach (Control control in langPanelD.Controls)
            {
                if (control is Button button)
                {
                    if (button.Text == Language)
                    {
                        // Active
                        button.ForeColor = Color.FromArgb(255, 224, 192);
                    }
                    else
                    {
                        // Deactive
                        button.ForeColor = Color.FromArgb(64, 64, 64);
                    }
                }
            }
            #endregion

            #region Browse Path
            /* Browse button text binding */
            btnBrowse.Text = language.txtBrowse;

            /* Path valid text */
            if (txtBoxBrowsePath.Text.GetNullToEmpty() == string.Empty)
            {
                labelImageExists.Text = language.choosePath;
            }
            else
            {
                if (pathValid)
                {
                    labelImageExists.Text = language.pathValid;
                }
                else
                {
                    labelImageExists.Text = language.pathInValid;
                }
            }
            #endregion

            // Image count label
            labelImgCnt.Text = this.language.formatCount(ImgFilesInPath.Items.Count);

            // File name copied notice label
            labelNoticeCopy.Text = language.txtCopied;

            // Preview title text
            labelPreview.Text = language.txtPreview;

            if (isSearching)
            {
                txtBoxSearch.Text = language.txtSearchPlaceholder;
            }

            // another code
        }
        #endregion

        #region Image Path and Label and Load
        /*----------------------------
         * 1. Select folder path
         * 2. Check validation
         * 3. Load file names to List
         ----------------------------*/

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folderPath = txtBoxBrowsePath.Text.GetNullToEmpty();
            if (folderPath == string.Empty)
            {
                folderPath = "C:\\";
            }

            // Main work of this method...
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // If exists path text before, use that.
                folderBrowserDialog.SelectedPath = folderPath;

                SelectedImageClear();

                // Open folder select modal.
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Binding path text into textbox
                    txtBoxBrowsePath.Text = folderBrowserDialog.SelectedPath;

                    SetImgFileNameToList();
                }
                else
                {
                    ImageExistsLabelSet(false);
                }
            }

            labelImgCnt.Text = this.language.formatCount(ImgFilesInPath.Items.Count);
        }

        private void SelectedImageClear()
        {
            PreviewImg = string.Empty;
            txtBoxBrowsePath.Text = string.Empty;
            ImgFilesInPath.Items.Clear();
            ImgPreview.Images.Clear();
            imagePaths.Clear();
        }

        private bool isThereExistsImageFiles()
        {
            string folderPath = txtBoxBrowsePath.Text;

            string[] imageExtensions = GetImageExtensions();

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    if (imageExtensions.Contains(System.IO.Path.GetExtension(file).ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ImageExistsLabelSet(bool isOK)
        {
            if (isOK)
            {
                pathValid = isThereExistsImageFiles();

                if (pathValid)
                {
                    labelImageExists.Text = this.language.pathValid;

                    // Change text color : Success
                    labelImageExists.ForeColor = Color.FromArgb(210, 255, 169);
                }
                else
                {
                    labelImageExists.Text = this.language.pathInValid;

                    // Change text color : Bad
                    labelImageExists.ForeColor = Color.FromArgb(232, 72, 72);
                }

                labelImageExists.Visible = true;
            }
            else
            {
                pathValid = false;

                labelImageExists.Text = language.choosePath;
                labelImageExists.ForeColor = Color.FromArgb(199, 199, 199);
                //labelImageExists.Visible = false;
            }
        }

        private List<string> GetImageFileName()
        {
            string folderPath = txtBoxBrowsePath.Text;

            // Get all of type of image file on system.
            string[] imageExtensions = GetImageExtensions();

            List<string> imageFiles = new List<string>();

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                // Save file name for return
                imageFiles = files.Where(file => file != null && imageExtensions.Contains(System.IO.Path.GetExtension(file).ToLower()))
                                  .Select(file => System.IO.Path.GetFileName(file))
                                  .ToList();

                // Save file path for Slide
                imagePaths = files.Where(file => imageExtensions.Contains(System.IO.Path.GetExtension(file).ToLower()))
                          .ToList();
            }
            return imageFiles;
        }

        private void SetImgFileNameToList()
        {
            // Validate check this folder
            ImageExistsLabelSet(true);

            // Load image file names and binding to listbox
            ImgFilesInPath.Items.Clear();
            List<string> imageFiles = GetImageFileName();
            beforeSearch = imageFiles;
            ImgFilesInPath.Items.AddRange(imageFiles.ToArray());
        }

        private string[] GetImageExtensions()
        {
            // Get all of type of image file on system.
            string[] SystemimageExtensions = ImageCodecInfo.GetImageDecoders()
                                                           .SelectMany(codec => codec.FilenameExtension.Split(';'))
                                                           .Select(ext => ext.Trim('*').ToLower())
                                                           .ToArray();

            // Additional other type of image files..
            string[] additionalimageExtensions = new[]
            {
                ".svg",  // Vector
                ".eps",  // Vector
                ".ai",   // Vector
                ".psd",  // Photoshop
                ".xcf",  // GIMP
                ".dng",  // Adobe
                ".raw",  // RAW
                ".arw",  // Sony RAW
                ".cr2",  // Canon RAW
                ".nef",  // Nikon RAW
                ".orf",  // Olympus RAW
                ".rw2",  // Panasonic RAW
                ".tiff", ".tif",  // Big image format
                ".dds",  // DirectDraw Surface
                ".bmp",  // Bitmap
                ".ico"   // Icon
            };

            return SystemimageExtensions.Concat(additionalimageExtensions).Distinct().ToArray();
        }
        #endregion

        private void txtBoxBrowsePath_TextChanged(object sender, EventArgs e)
        {
            // What..
        }

        #region Listbox draw
        private void ImgFilesInPath_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool isHovered = (e.Index == hoveredIndex);
            //bool isSelected = e.State.HasFlag(DrawItemState.Selected);
            bool isSelected = (e.Index == ImgFilesInPath.SelectedIndex);
            bool isFocused = e.State.HasFlag(DrawItemState.Focus);

            if (isSelected)
            {
                Color sBGColor = Color.FromArgb(108, 117, 125);
                Color sTxtColor = Color.FromArgb(255, 224, 192);

                e.Appearance.BackColor = sBGColor;
                e.Appearance.ForeColor = sTxtColor;
            }

            else if (isHovered)
            {
                Color hBGColor = Color.FromArgb(74, 74, 74);
                Color hTxtColor = Color.FromArgb(199, 199, 199);

                e.Appearance.BackColor = hBGColor;
                e.Appearance.ForeColor = hTxtColor;
            }

            else
            {
                Color dTxtColor = Color.FromArgb(199, 199, 199);

                e.Appearance.BackColor = this.BackColor;
                e.Appearance.ForeColor = dTxtColor;
            }

            e.Appearance.DrawBackground(e.Cache, e.Bounds);

            if (isFocused)
            {
                e.Graphics.DrawRectangle(Pens.Black, e.Bounds);
            }
        }

        private void ImgFilesInPath_MouseMove(object sender, MouseEventArgs e)
        {
            int index = ImgFilesInPath.IndexFromPoint(e.Location);

            if (index != hoveredIndex)
            {
                hoveredIndex = index;
                ImgFilesInPath.Invalidate();
            }
        }

        private void ImgFilesInPath_MouseLeave(object sender, EventArgs e)
        {
            hoveredIndex = -1;
            ImgFilesInPath.Invalidate();
        }
        #endregion

        #region Image name copy events
        private void ImgFilesInPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var selectedItem = ImgFilesInPath.SelectedItem;
            if (selectedItem != null)
            {
                Clipboard.SetText(selectedItem.ToString());

                labelNoticeCopy.ForeColor = Color.FromArgb(159, 188, 247);
                noticeCopySec = 2;
            }
        }

        private void noticeClipboardTimerSec_Tick(object sender, EventArgs e)
        {
            if (noticeCopySec > 0)
            {
                --noticeCopySec;
            }
            else
            {
                noticeCopySec = 0;
            }
        }

        private void noticeClipboardTimerColor_Tick(object sender, EventArgs e)
        {
            if (noticeCopySec <= 0)
            {
                labelNoticeCopy.ForeColor = InterpolateColor(labelNoticeCopy.ForeColor, this.BackColor, 0.05f);
            }
        }
        #endregion

        private void ImgFilesInPath_MouseClick(object sender, MouseEventArgs e)
        {
            defaultProperties_DropDown();
        }

        private void btnStartSlideShow_Click(object sender, EventArgs e)
        {
            #region Open Slide Show

            List<string> paramPathList = new List<string>();
            int paramIndex = 0;

            // When user selected row
            var selectedItem = ImgFilesInPath.SelectedItem;
            if (selectedItem != null)
                paramIndex = ImgFilesInPath.SelectedIndex;

            // When user searching
            if (txtBoxSearch.Text != language.txtSearchPlaceholder)
                paramPathList = FilteredimagePaths;
            else
                paramPathList = imagePaths;

            using (var ImgSlideShow = new ImageSlide(paramPathList, paramIndex))
            {
                ImgSlideShow.ShowDialog();
            }

            #endregion
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            #region Image List Shuffle

            if (imagePaths.Count > 0)
            {
                Random rand = new Random();

                // When user searching then
                if (txtBoxSearch.Text != language.txtSearchPlaceholder)
                {
                    FilteredimagePaths = imagePaths.Where(args => searchResult.Any(keyword => args.Contains(keyword))).ToList();
                    FilteredimagePaths = FilteredimagePaths.OrderBy(item => rand.Next()).ToList();
                    ImgFilesInPath.Items.Clear();

                    foreach (var imagePath in FilteredimagePaths)
                    {
                        ImgFilesInPath.Items.Add(Path.GetFileName(imagePath));
                    }
                }
                else
                {
                    imagePaths = imagePaths.OrderBy(item => rand.Next()).ToList();
                    ImgFilesInPath.Items.Clear();

                    foreach (var imagePath in imagePaths)
                    {
                        ImgFilesInPath.Items.Add(Path.GetFileName(imagePath));
                    }
                }

                SetImgPreviewImage();
            }

            #endregion
        }

        private void SetImgPreviewImage()
        {
            #region Image Preview Binding

            var selectedItem = ImgFilesInPath.SelectedItem;
            if (selectedItem != null)
            {
                if (PreviewImg != selectedItem.ToString())
                {
                    int currentIndex = currentIndex = ImgFilesInPath.SelectedIndex;
                    string selectedPath = txtBoxSearch.Text == language.txtSearchPlaceholder ? imagePaths[currentIndex] : FilteredimagePaths[currentIndex];

                    ImgPreview.Images.Clear();
                    ImageSlide otherClass = new ImageSlide();
                    if (otherClass.IsRawFile(selectedPath))
                    {
                        ImgPreview.Images.Add(otherClass.GetCompressedRaw(selectedPath, 10));
                    }
                    else
                    {
                        Image img = Image.FromFile(selectedPath);
                        ImgPreview.Images.Add(img);
                    }
                    PreviewImg = selectedItem.ToString();
                }
            }

            #endregion
        }

        private void ImgFilesInPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetImgPreviewImage();
        }

        #region Search
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            #region Searching Keyword Apply

            Thread.Sleep(40);

            if (beforeSearch.Count > 0)
            {
                if (txtBoxSearch.Text == language.txtSearchPlaceholder)
                {
                    FilteredimagePaths.Clear();
                    return;
                }

                ImgFilesInPath.Items.Clear();

                if (txtBoxBrowsePath.Text.GetNullToEmpty().Trim() != string.Empty)
                {
                    string stxt = txtBoxSearch.Text;
                    searchResult = beforeSearch.Where(txt => txt.ToLower().Contains(stxt.ToLower())).ToList();

                    ImgFilesInPath.Items.AddRange(searchResult.ToArray());
                    FilteredimagePaths = imagePaths.Where(args => searchResult.Any(keyword => args.Contains(keyword))).ToList();
                }
                else
                {
                    ImgFilesInPath.Items.AddRange(beforeSearch.ToArray());
                }
            }

            #endregion
        }

        #region Search textbox placeholder
        private void txtBoxSearch_Enter(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == this.language.txtSearchPlaceholder)
            {
                txtBoxSearch.Text = string.Empty;
                txtBoxSearch.ForeColor = Color.Black;
            }
        }

        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == string.Empty)
            {
                ClearSearchText();
            }
        }
        #endregion

        private void ClearSearchText()
        {
            txtBoxSearch.Text = this.language.txtSearchPlaceholder;
            txtBoxSearch.ForeColor = Color.DarkGray;
        }
        #endregion

        private Color InterpolateColor(Color from, Color to, float amount)
        {
            int r = (int)(from.R + (to.R - from.R) * amount);
            int g = (int)(from.G + (to.G - from.G) * amount);
            int b = (int)(from.B + (to.B - from.B) * amount);

            return Color.FromArgb(r, g, b);
        }

        #region Screen DPI

        private float GetCurrentDpiFactor()
        {
            using (Graphics g = this.CreateGraphics())
            {
                return g.DpiX / 96f;
            }
        }

        private void AdjustUIFormDpi(float dpiFactor)
        {
            DropdownMaxHeight = (int)(DropdownMaxHeight * dpiFactor);
            btnDropdown.Height = (int)(btnDropdown.Height * dpiFactor);
        }
        
        #endregion
    }
}
