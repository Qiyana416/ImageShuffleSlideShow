namespace ImageShuffleSlideShow
{
    static class FuncEx
    {
        public static string GetNullToEmpty(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            else if (obj.ToString().Trim().Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }
    }
}
