using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace MmorpgEngine
{

   public class chat
    {

        public struct line
        {
           public string text;
           public Color color;
        }

        private ArrayList msg = new ArrayList();

        public void newmsg(string text, Color couleur)
        {
            if (text.Length >= 255)
            {
                return;
            }

            line msg_temp = new line();
            msg_temp.text = text;
            msg_temp.color = couleur;
            this.msg.Add(new line());
            this.msg[msg.Count - 1] = msg_temp;
        }

        public ArrayList entry()
        {
            return this.msg;
        }

    }

}
