using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MmorpgEngine;
using Microsoft.Xna.Framework.Graphics;
namespace MmorpgCreatorMain
{
     [Serializable]
    public abstract class Entity : IEntityServer, IEntityClient
    {
        //VARIABLE GENERAL
        private String _Name;
        public Int32 _ID;
        public Int32 _Speed = 1;
        public Byte _Dir = 1;
        //MOUVEMENT
        public Vector2 Location = new Vector2(50,50);
        public Vector2 NextLocation = new Vector2(50, 50);
         Byte _Direction;
        public Int32 _Value = 0;
        //ANIMATION
        Byte _Frame;
        private Byte Timer;
        public String _Sprite;

         [NonSerialized]
        public Texture2D Sprites;
        public Boolean Anim = false;

        #region

        void IEntityClient.animate()
        {
            if (Anim == true)
            {
                Timer++;
                if (Timer > 5)
                {
                    if (this.Frame < 3)
                    {
                        this.Frame++;
                    }
                    else
                    {
                        this.Frame = 0;
                        Anim = false;
                    }

                    Timer = 0;
                }
            }
            else
            {
                if (this.Frame != 0)
                {
                    if (this.Frame == 3)
                    {
                        this.Frame = 0;
                    }
                    else
                    {
                        this.Frame++;
                    }
                }
            }

        }

        void IEntityClient.MoveX()
        {
            Anim = true;
            if ((Int32)this.NextLocation.X < (Int32)Location.X)
                Location.X -= Speed;
            else
                Location.X += Speed;
        }

        void IEntityClient.MoveY()
        {
            Anim = true;

            if ((Int32)this.NextLocation.Y < (Int32)Location.Y)
                Location.Y -= Speed;
            else
                Location.Y += Speed;
        }

        Boolean IEntityClient.CanMove(byte dir, Map currentMapToCheck)
        {
            Vector2 newlocation = Location;

            if (dir == 0)
                newlocation.Y = (Int32)(newlocation.Y + Speed);
            if (dir == 1)
                newlocation.X = (Int32)(newlocation.X - Speed);
            if (dir == 2)
                newlocation.X = (Int32)(newlocation.X + Speed);
            if (dir == 3)
                newlocation.Y = (Int32)(newlocation.Y - Speed);

            return ((IMapClient)currentMapToCheck).HitCollisionTest(newlocation);
        }

        void IEntityClient.MakeMove(byte dir)
        {
            Direction = dir;
            if (dir == 0)
                NextLocation.Y = (Int32)Location.Y + Speed;
            if (dir == 1)
                NextLocation.X = (Int32)Location.X - Speed;
            if (dir == 2)
                NextLocation.X = (Int32)Location.X + Speed;
            if (dir == 3)
                NextLocation.Y = (Int32)Location.Y - Speed;

            Value += Convert.ToInt32(Math.Sqrt(Sqr(NextLocation.Y - Location.Y) + Sqr(NextLocation.X - Location.X)));
        }

        static public double Sqr(double a)
        {
            return a * a;
        }
 

        Vector2 IEntityClient.Mouse(Int32 CX, Int32 CY, Int32 screenX, Int32 screenY)
        {
            Int32 X = (Int32)this.Location.X - ((screenX / 2) - CX);
            Int32 Y = (Int32)this.Location.Y - ((screenY / 2) - CY);
            return new Vector2(X, Y);
        }
        #endregion
        #region Server functions

        #endregion
        #region GetSet

        public Int32 ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public byte Frame
        {
            get
            {
                return _Frame;
            }

            set
            {
                _Frame = value;
            }
        }

        public byte Direction
        {
            get
            {
                return _Direction;
            }

            set
            {
                _Direction = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }




        public Int32 Speed
        {
            get
            {
                return _Speed;
            }

            set
            {
                _Speed = value;
            }
        }


        public String Sprite
        {
            get
            {
                return _Sprite;
            }

            set
            {
                _Sprite = value;
            }
        }
        public Int32 Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }

        
        #endregion
    }
}