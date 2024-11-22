using DevExpress.Pdf.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using ImageMagick.Drawing;

namespace ImageShuffleSlideShow
{
    public partial class ImageSlide : DevExpress.XtraEditors.XtraForm
    {
        // 0 : Disable auto slide
        private int AutoSlideSpeed = 0; // Second

        private List<string> ImgName = new List<string>();
        private List<string> ImgPaths = new List<string>();

        private int currentIndex = 0;

        private bool mouseEntered = false;
        private int VisibleCooldown = 0;

        public ImageSlide()
        {
            InitializeComponent();
        }

        public ImageSlide(List<string> ImgPaths, int Startindex = 0)
        {
            InitializeComponent();

            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width / 2;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height / 2;

            if (Startindex != 0)
                this.currentIndex = Startindex;

            this.Size = new Size(ScreenWidth, ScreenHeight);

            this.ImgPaths = ImgPaths;
            Initializing();
        }

        private void Initializing()
        {
            // Get Names of Images
            ImgName = GetNameOfImages(ImgPaths);

            // Set Image of Current Index
            LoadImage();

            if (ImgName.Count > 0 && currentIndex >= 0)
            {
                this.Text = ImgName[currentIndex];
                Clipboard.SetText(ImgName[currentIndex]);
            }

            else
                this.Text = "Empty slide";
        }

        private void ImageSlide_Load(object sender, EventArgs e)
        {
            SetLeftRightSizeLocation();

            ToLeft.Text = string.Empty;
            ToRight.Text = string.Empty;

            ToLeft.Parent = imageSlider;
            ToRight.Parent = imageSlider;

            ToLeft.BackColor = Color.Transparent;
            ToRight.BackColor = Color.Transparent;
        }

        private List<string> GetNameOfImages(List<string> ImgPaths)
        {
            List<string> rtnArrImgNm = new List<string>();

            foreach (var path in ImgPaths)
            {
                if (File.Exists(path))
                {
                    rtnArrImgNm.Add(Path.GetFileName(path));
                }
            }

            return rtnArrImgNm;
        }

        private void LoadImage()
        {
            if (currentIndex >= 0 && currentIndex < ImgPaths.Count)
            {
                string imagePath = ImgPaths[currentIndex];
                if (File.Exists(imagePath))
                {
                    try
                    {
                        imageSlider.Images.Clear();

                        if (IsRawFile(imagePath))
                        {
                            imageSlider.Images.Add(GetCompressedRaw(imagePath, 100));
                            //imageSlider.Images.Add(new Bitmap(1, 1));
                        }
                        else
                        {
                            Image img = Image.FromFile(imagePath);
                            imageSlider.Images.Add(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Load image error: " + ex.Message);
                    }
                }
            }
        }

        public bool IsRawFile(string filePath)
        {
            string[] rawExtensions = { ".cr2", ".nef", ".arw", ".dng", ".raf", ".orf" };
            return rawExtensions.Contains(Path.GetExtension(filePath).ToLower());
        }

        public Image GetCompressedRaw(string filePath, uint Quality)
        {
            try
            {
                using (var magickImage = new MagickImage(filePath))
                {
                    magickImage.Format = MagickFormat.Jpeg;
                    magickImage.Quality = Quality;

                    using (var memoryStream = new MemoryStream())
                    {
                        magickImage.Write(memoryStream);

                        memoryStream.Seek(0, SeekOrigin.Begin);
                        Image image = new Bitmap(memoryStream);

                        return image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return new Bitmap(1, 1);
            }
        }

        private void ToLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LeftRightMouseClick("Left");
            }
        }

        private void ToRight_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LeftRightMouseClick("Right");
            }
        }

        private void LeftRightMouseClick(string direction)
        {
            int prevIndex = currentIndex;
            int nextIndex = 0;

            if (direction.ToLower() == "left")
            {
                if (prevIndex > 0)
                {
                    nextIndex = --currentIndex;
                }
            }
            else if (direction.ToLower() == "right")
            {
                if (prevIndex < ImgName.Count - 1)
                {
                    nextIndex = ++currentIndex;
                }
            }
            if (ImgName.Count > 0)
                this.Text = ImgName[currentIndex];

            if (prevIndex != nextIndex)
            {
                Clipboard.SetText(ImgName[nextIndex]);
                LoadImage();
            }
        }

        private void ImageSlide_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int prevIndex = currentIndex;
            int nextIndex = 0;

            if (e.KeyCode == Keys.Left)
            {
                if (prevIndex > 0)
                    nextIndex = --currentIndex;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (prevIndex < ImgName.Count - 1)
                    nextIndex = ++currentIndex;
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

            if (ImgName.Count > 0)
                this.Text = ImgName[currentIndex];

            if (prevIndex != nextIndex)
            {
                Clipboard.SetText(ImgName[nextIndex]);
                LoadImage();
            }
        }

        private void MouseEnterInScreen(object sender, EventArgs e)
        {
            ToLeft.Text = "<";
            ToRight.Text = ">";
        }

        private void MouseLeaveInScreen(object sender, EventArgs e)
        {
            ToLeft.Text = string.Empty;
            ToRight.Text = string.Empty;
        }

        private void SetLeftRightSizeLocation()
        {
            int LeftRightWidth = (int)(this.Width * 0.2);

            ToLeft.Width = LeftRightWidth;
            ToLeft.Height = this.Height;
            ToLeft.Location = new Point(0, 0);

            ToRight.Width = LeftRightWidth;
            ToRight.Height = this.Height;
            ToRight.Location = new Point((this.Width - LeftRightWidth), 0);
        }

        private void ImageSlide_SizeChanged(object sender, EventArgs e)
        {
            SetLeftRightSizeLocation();
        }
    }
}