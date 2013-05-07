using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MmorpgEngine
{
    class skin
    {
        Texture2D Background;
        Vector2 location;
        int sizex;
        int sizey;
        int alpha;

        public skin(Texture2D Background, Vector2 location, int sizex, int sizey, int alpha)
        {
            this.Background = Background;
            this.location = location;
            this.sizex = sizex;
            this.sizey = sizey;
            this.alpha = alpha;
        }

        

    }
}
