using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace MmorpgEngine.objects
{
    class animation
    {
        string name;
        struct frame
        {
            public int sheet;
            public Vector2 location;
            public int alpha;
            public Color couleur;
        }
    }
}
