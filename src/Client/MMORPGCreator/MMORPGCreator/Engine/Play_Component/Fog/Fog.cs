using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MmorpgEngine
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Fog : Microsoft.Xna.Framework.DrawableGameComponent
    {
        //Composant de dessin  
        public SpriteBatch spriteBatch;

        public Texture2D _Fog;
        public Int32 _FogX = 0;
        public Int32 _FogY = 0;

        Timer fogtimer = new Timer(30, true);


        public Fog(Game game)
            : base(game)
        {
         
    
        }
        
        public override void Initialize()
        {
            // TODO : Code
           
            this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (GlobalDataGame.CurrentMap != null)
            {
                if (GlobalDataGame.CurrentMap.FogMove == true && GlobalDataGame.CurrentMap.Fog == true)
                {
                    fogtimer.time += gameTime.ElapsedGameTime.Milliseconds;

                    if (fogtimer.Istime())
                    {
                        _FogX += 1 * GlobalDataGame.CurrentMap.FogSpeedX;
                        _FogY += 1 * GlobalDataGame.CurrentMap.FogSpeedY;

                        if (_FogX >= _Fog.Width)
                        {
                            _FogX = 0;
                        }

                        if (_FogY >= _Fog.Height)
                        {
                            _FogY = 0;
                        }
                    }
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (GlobalDataGame.CurrentMap.Fog == true && _Fog != null)
                {
                    this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
                    int copyx = 1024 / _Fog.Width;
                    int copyy = 768 / _Fog.Width;

                    for (int x = -1; x < copyx + 1; x++)
                    {
                        for (int y = -1; y < copyy + 1; y++)
                        {
                            this.spriteBatch.Draw(_Fog, new Rectangle((_Fog.Width * x) + _FogX, (_Fog.Width * y) + _FogY, _Fog.Width, _Fog.Height), new Color(255, 255, 255, 50));
                        }
                    }
                    this.spriteBatch.End();
                }


            base.Draw(gameTime);
        }


    }
}
