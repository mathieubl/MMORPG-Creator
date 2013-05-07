using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;
namespace MmorpgEngine
{
    public class TexteStyle
    {
        public  const string STYLE_REGULAR = "normal";
        public  const string STYLE_BOLD = "bold";
        public  const string STYLE_ITALIC = "italic";
        public   const string STYLE_UNDERLINE = "underline";
        public const string STYLE_STRIKEOUT = "strikeout";

        public static FontStyle StyleTexte(string texte)
        {
            FontStyle txtStyle = new FontStyle();
            switch (texte)
            {
                case STYLE_REGULAR:
                    txtStyle = FontStyle.Regular;
                    break;
                case STYLE_BOLD:
                    txtStyle = FontStyle.Bold;
                    break;

                case STYLE_ITALIC:
                    txtStyle = FontStyle.Italic;
                    break;

                case STYLE_UNDERLINE:
                    txtStyle = FontStyle.Underline;
                    break;

                case STYLE_STRIKEOUT:
                    txtStyle = FontStyle.Strikeout;
                    break;
                default:
                    txtStyle = FontStyle.Regular;
                    break;
            }

            return txtStyle;
        }
    }
}
