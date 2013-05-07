using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MmorpgEngine
{

    public class SkinButton
    {
        Delegate Function;
        public String name;
        public Texture2D Img;
        Texture2D ImgHover;
        public Texture2D ImgNormal;
        public Vector2 Location;
        Boolean visible;

        public SkinButton(Texture2D Hover, Texture2D Normal, Vector2 Location)
        {
            this.ImgHover = Hover;
            this.ImgNormal = Normal;
            this.Location = Location;
        }

        public void hover()
        {

        }

    }
}
