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
    /// Composant du jeu qui implémente IUpdateable.
    /// </summary>
    public class Skin : Microsoft.Xna.Framework.GameComponent
    {

        public SpriteBatch spriteBatch;

        public Skin(Game game)
            : base(game)
        {

        }

        /// <summary>
        /// Permet au composant de jeu d’effectuer une initialisation si nécessaire avant l’exécution.
        /// Il peut alors demander les services nécessaires et charger du contenu.
        /// </summary>
        public override void Initialize()
        {
            // TODO : ajouter le code d’initialisation ici

            base.Initialize();
        }

        /// <summary>
        /// Permet au composant de jeu de se mettre à jour.
        /// </summary>
        /// <param name="gameTime">Fournit un aperçu des valeurs de temps.</param>
        public override void Update(GameTime gameTime)
        {
            this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            
            foreach(SkinWindow curSkinWindow in GlobalDataGame.UserInterfaceKit)
            {

            }


            this.spriteBatch.End();

            base.Update(gameTime);
        }
    }
}
