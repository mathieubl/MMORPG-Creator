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
namespace amdaro
{
    class entity
    {
        string name;
        public Vector2 location;
        public int x;
        public int nextx;
        public int nexty;
        public int y;
        byte _frame;
        byte _direction;
        public Texture2D Sprites;

        public entity(string cname, int cx, int cy, Texture2D sprites)
        {
            location = new Vector2(cx, cy);
            name = cname;
            x = cx;
            y = cy;
            Sprites = sprites;
            nextx = -1;
            nexty = -1;
        }
        public void movex()
        {
            if (this.frame < 3)
            {
                frame++;
            }
            else
            {
                frame = 1;
            }
            if (direction == 1)
            {
                x-=2;
                nextx--;
            }
            else
            {
                x+=2;
                nextx--;
            }
        }

        public void movey()
        {
            if (this.frame < 3)
            {
                frame++;
            }
            else
            {
                frame = 1;
            }
            if (direction == 0)
            {
                y++;
                nexty--;
            }
            else
            {
                y--;
                nexty--;
            }
        }

        public void makemove(byte dir)
        {
            direction = dir;
            if (dir == 0)
            {
                nexty++;
            }
            if (dir == 1)
            {
                nextx++;
            }
            if (dir == 2)
            {
                nextx++;
            }
            if (dir == 3)
            {
                nexty++;
            }
        }
        public byte frame
        {
            get
            {
                return _frame;
            }

            set
            {
                _frame = value;
            }
        }

        public byte direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }


        public Vector2 Mouse(int CX, int CY)
        {
            int X = this.x - ((config.screenx / 2) - CX) - Sprites.Width / 4;
            int Y = this.y - ((config.screeny / 2) - CY) - Sprites.Height / 4;
            return new Vector2(X, Y);
        }


    }
}
