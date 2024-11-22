using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageShuffleSlideShow
{
    public class MyTableLayoutPanel : TableLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020;
                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //
        }
    }
}
