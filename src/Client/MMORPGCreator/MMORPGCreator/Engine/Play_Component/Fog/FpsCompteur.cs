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
    public class FpsCompteur : Microsoft.Xna.Framework.DrawableGameComponent
    {
        //Composant de dessin
        public SpriteBatch spriteBatch;
        //Police de caractêres
        public SpriteFont spriteFont;
        //Nombre d'images par secondes
        public double FPS = 0.0f;
        public FpsCompteur(Game game): base(game)
        {
            // TODO : Code
        }

        public override void Initialize()
        {
            // TODO : Code
           
            this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteFont = this.Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //Calcul du nombre d'image par secondes
            this.FPS = 1000.0d / gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Formatage de la chaine
            string texte = string.Format("{0:00.00} fps", this.FPS);
            //Calcul de la taille de la chaine pour la police de caractère choisie
            Vector2 taille = this.spriteFont.MeasureString(texte);
            //Affichage de la chaine
            this.spriteBatch.Begin();
            this.spriteBatch.DrawString(this.spriteFont, texte, new Vector2(this.GraphicsDevice.Viewport.Width - taille.X, 5), Color.Green);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
