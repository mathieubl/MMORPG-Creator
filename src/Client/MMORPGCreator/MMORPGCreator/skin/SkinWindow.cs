using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MmorpgEngine
{
    public class SkinWindow
    {
        Texture2D Background;
        Vector2 location;
        int sizex;
        int sizey;
        int alpha;
        private static List<SkinButton> button = new List<SkinButton>();
  //      private static List<skin_label> label = new List<skin_button>();

        public SkinWindow(Texture2D Background, Vector2 location, int sizex, int sizey, int alpha)
        {
            this.Background = Background;
            this.location = location;
            this.sizex = sizex;
            this.sizey = sizey;
            this.alpha = alpha;
        }

        public void AddButton(Delegate functionToAdd)
        {

        }
        
        public string MouseCheck(int mousex, int mousey, Boolean Clicked)
        {
            if (mousex < location.X || mousey < location.Y || mousex > location.X + sizex || mousey > location.Y + sizey)
            {
                return null;
            }

            foreach (SkinButton buttons in button)
            {
                if (location.X > buttons.Location.X && location.X < buttons.Location.X + buttons.ImgNormal.Width && location.Y > buttons.Location.Y && location.Y < buttons.Location.Y + buttons.ImgNormal.Height)
                {
                    buttons.hover();
                    return buttons.name;
                }
              //  Cli.Send(Packet);
            }

            return null;
        }

    }
}
