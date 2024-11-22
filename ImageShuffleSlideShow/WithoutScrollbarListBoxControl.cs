using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShuffleSlideShow
{
    public class WithoutScrollbarListBoxControl : ListBoxControl
    {
        protected override DevExpress.XtraEditors.ViewInfo.BaseStyleControlViewInfo CreateViewInfo()
        {
            object res = base.CreateViewInfo();
            return new WithoutScrollbarListBoxControlInfo(this);
        }
    }

    public class WithoutScrollbarListBoxControlInfo : DevExpress.XtraEditors.ViewInfo.BaseListBoxViewInfo
    {
        public WithoutScrollbarListBoxControlInfo(BaseListBoxControl owner) : base(owner) { }
        protected override bool CalcVScrollVisibility(System.Drawing.Rectangle bounds)
        {
            return false;
        }
    }
}
