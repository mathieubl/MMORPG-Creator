using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MmorpgCreatorMain;

namespace MmorpgEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public partial class Game : Microsoft.Xna.Framework.Game
    {
        //Clavier
         Keys[] _KeyBoardChecker = new Keys[] {
    Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
    Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
    Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
    Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
    Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
    Keys.Z, Keys.Back, Keys.Space};

        String key;

        //Mouse
        Vector2 _MouseLocation = new Vector2();
        Vector2 _MouseStartLocation= new Vector2();

        //Engine
        SpriteBatch spriteBatch;
        Camera _Camera;
        Int32 fps = 0; Int32 fps2 = 0;
        SpriteFont _SpriteFont;
        FpsCompteur _FpsComponent;
        Fog _FogComponent;

        public Game()
        {
            _FpsComponent = new FpsCompteur(this);
            _FogComponent = new Fog(this);

            GlobalDataGame.graphics = new GraphicsDeviceManager(this);

            GlobalDataGame.graphics.PreferMultiSampling = false;

            GlobalDataGame.graphics.PreferredBackBufferWidth = 1024;
            GlobalDataGame.graphics.PreferredBackBufferHeight = 768;

            this.IsMouseVisible = true;
            Content.RootDirectory = GlobalDataGame.ProjectPath + "/Content";
            this.Window.Title = GlobalDataGame.GameName;
            this.Window.AllowUserResizing = true;
            GlobalClass.AppPath = GlobalDataGame.ProjectPath;
            GlobalDataEditor.EngineEditorWinform.Navigator.Visible = true;

            if (GlobalDataGame.online == false)
                this.Window.Title += " (Hors Ligne)";
 
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
       
            base.Initialize();
            _Camera = new Camera();
            if (GlobalDataGame.online == true)
            {
                socket.SendJoinGame();
            }
            else
            {
                GlobalDataGame.screen = GlobalEnum.XNAScreensType.Loading;
                GlobalDataGame.NeedMap = true;
                GlobalDataGame.character.Clear();
                GlobalDataGame.CurrentMap = new Map(System.Convert.ToInt32(1));
                 ((IMapClient)GlobalDataGame.CurrentMap).LoadMap(true);

                Stream stream1;
                stream1 = File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/entities/angel.png");
                GlobalDataGame.character.Add(new Player(1, "Local", 2, 2, Texture2D.FromStream(GlobalDataGame.graphics.GraphicsDevice, stream1)));

                GlobalDataGame.Index = GlobalDataGame.FindPlayer(1);
                GlobalDataGame.screen = GlobalEnum.XNAScreensType.Play;
            }

            GlobalDataGame.ingame = true;
        }

        protected override void LoadContent()
        {
            Int32 i = 0;
            Stream stream;

            //Chargement de base
            stream = File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/rect.png");
            _RectangleTexture = Texture2D.FromStream(GraphicsDevice, stream);

            this._SpriteFont = Content.Load<SpriteFont>("font");
            
            //Chargement des TileSet
            while (File.Exists(GlobalDataGame.ProjectPath + "/graphics/tileset/" + i + ".png"))
            {
                GlobalDataGame.maptileset.Add(new maptile(Texture2D.FromStream(GraphicsDevice, File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/tileset/" + i + ".png")), "name"));
                i++;
            }

            i = 0;

            //Chargement des AutoTiles
            while (File.Exists(GlobalDataGame.ProjectPath + "/graphics/tiles/" + i + ".png"))
            {
                GlobalDataGame.maptile.Add(new maptile(Texture2D.FromStream(GraphicsDevice, File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/tiles/" + i + ".png")), "name"));
                i++;
            }
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GlobalDataGame.screen == GlobalEnum.XNAScreensType.Loading)
                this.update_loading(gameTime);

            if (GlobalDataGame.NeedMap == true)
                Refresh_Map();

            if (GlobalDataGame.NeedMap == false && GlobalDataGame.NeedEffect == true)
                Refresh_Effects();

            if (GlobalDataGame.screen == GlobalEnum.XNAScreensType.Play)
              this.Update_Play(gameTime);

            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            if (GlobalDataGame.screen == GlobalEnum.XNAScreensType.Loading)
                this.draw_loading(gameTime);

            if (GlobalDataGame.screen == GlobalEnum.XNAScreensType.Play)
                //Écran principale
                this.draw_play(gameTime);

            base.Draw(gameTime);
        }

        protected void Draw_Transition()
        {

        }

        private void Key_AddChar(string textbox, Keys key, Boolean Shifted)
        {
            String newChar = String.Empty;
            if (textbox == "chatbox")
            {
                newChar = _ChatText;
            }
           
            switch (key)
            {
                case Keys.A:
                    newChar += "a";
                    break;
                case Keys.B:
                    newChar += "b";
                    break;
                case Keys.C:
                    newChar += "c";
                    break;
                case Keys.D:
                    newChar += "d";
                    break;
                case Keys.E:
                    newChar += "e";
                    break;
                case Keys.F:
                    newChar += "f";
                    break;
                case Keys.G:
                    newChar += "g";
                    break;
                case Keys.H:
                    newChar += "h";
                    break;
                case Keys.I:
                    newChar += "i";
                    break;
                case Keys.J:
                    newChar += "j";
                    break;
                case Keys.K:
                    newChar += "k";
                    break;
                case Keys.L:
                    newChar += "l";
                    break;
                case Keys.M:
                    newChar += "m";
                    break;
                case Keys.N:
                    newChar += "n";
                    break;
                case Keys.O:
                    newChar += "o";
                    break;
                case Keys.P:
                    newChar += "p";
                    break;
                case Keys.Q:
                    newChar += "q";
                    break;
                case Keys.R:
                    newChar += "r";
                    break;
                case Keys.S:
                    newChar += "s";
                    break;
                case Keys.T:
                    newChar += "t";
                    break;
                case Keys.U:
                    newChar += "u";
                    break;
                case Keys.V:
                    newChar += "v";
                    break;
                case Keys.W:
                    newChar += "w";
                    break;
                case Keys.X:
                    newChar += "x";
                    break;
                case Keys.Y:
                    newChar += "y";
                    break;
                case Keys.Z:
                    newChar += "z";
                    break;
                case Keys.Space:
                    newChar += " ";
                    break;
                case Keys.Back:
                    if (newChar.Length - 1 != 0)
                    {
                        newChar = newChar.Remove(newChar.Length - 1, 1);
                    }
                    break;
                default:
                    newChar = "";
                    break;
            }

            if (Shifted == true)
            {
                newChar = newChar.ToUpper();
            }

            _ChatText = newChar;
        }



    }
}
