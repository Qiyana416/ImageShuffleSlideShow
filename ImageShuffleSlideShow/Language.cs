using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShuffleSlideShow
{
    public class Language
    {
        private string language = string.Empty;

        public string txtBrowse = string.Empty;
        public string txtSearchPlaceholder = string.Empty;

        public string txtYes = string.Empty;
        public string txtNo = string.Empty;

        public string choosePath = string.Empty;
        public string pathValid = string.Empty;
        public string pathInValid = string.Empty;

        public string txtCount = string.Empty;
        public string txtCopied = string.Empty;

        public string txtPreview = string.Empty;

        public Language()
        {
            setEng();
        }

        public Language(string language)
        {
            switch (language)
            {
                case "English":
                    {
                        setEng();
                        break;
                    }

                case "한국어":
                    {
                        setKor();
                        break;
                    }

                case "日本語":
                    {
                        setJpn();
                        break;
                    }

                /*-------------------*/
                default:
                    {
                        setEng();
                        break;
                    }
            }

            this.language = language;
        }

        private void setEng()
        {
            this.txtBrowse = "Browse";
            this.txtSearchPlaceholder = "Search...";

            this.txtYes = "Yes";
            this.txtNo = "No";

            this.choosePath = "Please choose path your own";
            this.pathValid = "The path is valid.";
            this.pathInValid = "The path is invalid.\n(There's no image file...)";

            this.txtCopied = "File name copied!";

            this.txtPreview = "Preview";
        }

        private void setKor()
        {
            this.txtBrowse = "찾아보기";
            this.txtSearchPlaceholder = "검색어...";

            this.txtYes = "예";
            this.txtNo = "아니오";

            this.choosePath = "경로를 선택해 주세요.";
            this.pathValid = "선택된 경로는 사용할 수 있습니다.";
            this.pathInValid = "선택된 경로는 사용할 수 없습니다.\n(이미지 파일이 존재하지 않음...)";

            this.txtCopied = "파일 이름을 복사했습니다!";

            this.txtPreview = "미리보기";
        }

        private void setJpn()
        {
            this.txtBrowse = "Browse";
            this.txtSearchPlaceholder = "検索...";

            this.txtYes = "はい";
            this.txtNo = "いいえ";

            this.choosePath = "フォルダパスを決めてください。";
            this.pathValid = "ご選択頂いたフォルダパスは使用できます。";
            this.pathInValid = "ご選択頂いたフォルダパスは使用できません。\n(イメージファイルが存在していません。)";

            this.txtCopied = "ファイル名をコピーしました！";

            this.txtPreview = "プレビュー";
        }

        public string formatCount(int count)
        {
            string rtnStr;

            switch (language)
            {
                case "English":
                    {
                        rtnStr = "Count: " + count.ToString();
                        break;
                    }

                case "한국어":
                    {
                        rtnStr = count.ToString() + "개";
                        break;
                    }

                case "日本語":
                    {
                        rtnStr = count.ToString() + "個";
                        break;
                    }

                /*-------------------*/
                default:
                    {
                        rtnStr = count.ToString();
                        break;
                    }
            }

            return rtnStr;
        }
    }
}
