using System;
using System.Collections;
using System.Linq;
using System.Text;
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
    public partial class Game : Microsoft.Xna.Framework.Game
    {
        Texture2D _RectangleTexture;

        Timer _Mousetimer = new Timer(75, false);
        Timer _KeyTimer = new Timer(100, true);
        Timer _TextEditorTimer = new Timer(10, true);
        
        Vector2 _MouseLocalisation;

        KeyboardState _KeyboardOldState;

        private string _ChatText = "";
        public const char sep_char = (char)255;

        #region Update

        public void Update_Play(GameTime gameTime)
        {
 
            if (GlobalDataGame.connected == true || GlobalDataGame.online == false)
            {
                fps += gameTime.ElapsedGameTime.Milliseconds;
                fps2 += gameTime.ElapsedGameTime.Milliseconds;
                _Mousetimer.time += gameTime.ElapsedGameTime.Milliseconds;

                PressKey_play(Keyboard.GetState());

                //Empêche le débordement
                if (this.IsActive == true && Mouse.GetState().X >= 0 && Mouse.GetState().Y >= 0 && Mouse.GetState().X <= this.Window.ClientBounds.Width && Mouse.GetState().Y <= this.Window.ClientBounds.Height)
                {
                    if (_Mousetimer.Istime())
                        PressMouse_play(Mouse.GetState());
                }

                if (fps >= 8)
                {
                    UpdateCharacter_play();

                    fps = 0;
                }

                UpdateCamera_play();
            }
            else
            {
                Exit();
                EndRun();
            }
        }

        public void UpdateCamera_play()
        {
            Player character_temp = (Player)GlobalDataGame.character[GlobalDataGame.Index];
            if (character_temp.Location.X > this.Window.ClientBounds.Width / 2 && character_temp.Location.X < GlobalDataGame.CurrentMap.SizeX - (this.Window.ClientBounds.Width / 2))
                _Camera.PosX = character_temp.Location.X - (this.Window.ClientBounds.Width / 2);

            if (character_temp.Location.Y > this.Window.ClientBounds.Height / 2 && character_temp.Location.Y < GlobalDataGame.CurrentMap.SizeY - (this.Window.ClientBounds.Height / 2))
                _Camera.PosY = character_temp.Location.Y - (this.Window.ClientBounds.Height / 2);
        }
        protected void UpdateCharacter_play()
        {
            for (int i = 0; i < GlobalDataGame.character.Count; i++)
            {
                Player character_temp = (Player)GlobalDataGame.character[i];

                if (character_temp.Location.X != character_temp.NextLocation.X || character_temp.Location.Y != character_temp.NextLocation.Y)
                {
                    if (character_temp.Location.X != character_temp.NextLocation.X)
                        ((IEntityClient)character_temp).MoveX();

                    if (character_temp.Location.Y != character_temp.NextLocation.Y)
                        ((IEntityClient)character_temp).MoveY();
                }
                else
                {
                    character_temp.Anim = false;
                }
            }
        }

        protected void UpdateNpc_Play()
        {
            for (int i = 0; i < GlobalDataGame.npc_actif.Count; i++)
            {
                Npc character_temp = GlobalDataGame.npc_actif[i];

                if (character_temp.Location.X != character_temp.NextLocation.X)
                     ((IEntityClient)character_temp).MoveX();

                if (character_temp.Location.Y != character_temp.NextLocation.Y)
                    ((IEntityClient)character_temp).MoveY();
            }
        }

        #region bouton
        protected void PressMouse_play(MouseState mouseState)
        {
            Player character_temp = (Player)GlobalDataGame.character[GlobalDataGame.Index];
            Vector2 Mousexy = ((IEntityClient)character_temp).Mouse(Mouse.GetState().X, Mouse.GetState().Y, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
            int x = 0;
            int y = 0;

            //CALCULE DE COORDONNÉES DE SOURIS
            if (character_temp.Location.X > this.Window.ClientBounds.Width / 2 && character_temp.Location.X < GlobalDataGame.CurrentMap.SizeX - (this.Window.ClientBounds.Width / 2))
            {
                x = (int)Mousexy.X;
            }
            else
            {
                if (character_temp.Location.X > GlobalDataGame.CurrentMap.SizeX - (this.Window.ClientBounds.Width / 2))
                {
                    x = (GlobalDataGame.CurrentMap.SizeX - this.Window.ClientBounds.Width) + Mouse.GetState().X;
                }
                else
                {
                    x = Mouse.GetState().X;
                }
            }

            if (character_temp.Location.Y > this.Window.ClientBounds.Height / 2 && character_temp.Location.Y < GlobalDataGame.CurrentMap.SizeY - (this.Window.ClientBounds.Height / 2))
            {
                y = (int)Mousexy.Y;
            }
            else
            {
                if (character_temp.Location.Y > GlobalDataGame.CurrentMap.SizeY - (this.Window.ClientBounds.Height / 2))
                {
                    y = (GlobalDataGame.CurrentMap.SizeY - this.Window.ClientBounds.Height) + Mouse.GetState().Y;
                }
                else
                {
                    y = Mouse.GetState().Y;
                }
            }

            //Bouton pressé
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditCollision)
                {
                    if (_MouseStartLocation.X <= 0 && _MouseStartLocation.Y <= 0)
                    {
                        _MouseStartLocation.X = x;
                        _MouseStartLocation.Y = y;
                    }
                    else
                    {
                        _MouseLocation.X = x;
                        _MouseLocation.Y = y;
                    }
                }

                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditMapObj)
                {
                    int magnetismex = 0, magnetismey = 0;
                    if (GlobalDataEditor.EngineEditorParameter.IsMagnetism == true)
                    {
                        magnetismex = (x / 32) * 32;
                        magnetismey = (y / 32) * 32;
                    }
                    else
                    {
                        magnetismex = x;
                        magnetismey = y;
                    }

                    GlobalDataGame.CurrentMap.create_objets(GlobalDataEditor.EngineEditorParameter.SelectedTilesetID, GlobalDataEditor.EngineEditorWinform.SelectObject.chklayer_Checked, magnetismex - ((int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value / 2), magnetismey - ((int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value / 2), (int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value, (int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value, (int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownalpha_Value, GlobalDataEditor.EngineEditorWinform.SelectTileset.locationx, GlobalDataEditor.EngineEditorWinform.SelectTileset.locationy, GlobalDataEditor.EngineEditorWinform.SelectTileset.sizex, GlobalDataEditor.EngineEditorWinform.SelectTileset.sizey);
                }

                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditGround)
                {
                    int locx = 0, locy = 0;
                    locx = (x / 16);
                    locy = (y / 16);


                    int EditGround_Selectx = GlobalDataEditor.EngineEditorWinform.SelectGround.locationx / 16;
                    int EditGround_Selecty = GlobalDataEditor.EngineEditorWinform.SelectGround.locationy / 16;
                    int EditGround_Sizex = GlobalDataEditor.EngineEditorWinform.SelectGround.sizex / 16;
                    int EditGround_Sizey = GlobalDataEditor.EngineEditorWinform.SelectGround.sizey / 16;
                    int EditGround_Sheet = GlobalDataEditor.EngineEditorWinform.SelectGround.tilescroll.Value;

                    for (int xi = 0; xi < EditGround_Sizex && xi <= 6; xi++)
                    {
                        for (int yi = 0; yi < EditGround_Sizey &&  yi < EditGround_Sizey && yi <= 8; yi++)
                        {
                            GlobalDataGame.CurrentMap.set_ground(locx + (xi), locy + (yi), EditGround_Sheet, EditGround_Selectx + (xi), EditGround_Selecty + (yi));

                        }
                    }
                }
            }
           
            //RELÂCHEMENT
            if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditCollision && Mouse.GetState().LeftButton == ButtonState.Released && _MouseStartLocation.X > 0 && _MouseStartLocation.Y > 0)
            {
                _MouseLocation.X = _MouseLocation.X - _MouseStartLocation.X;
                _MouseLocation.Y = _MouseLocation.Y - _MouseStartLocation.Y;

                GlobalDataGame.CurrentMap.create_collision((Int32)_MouseStartLocation.X, (Int32)_MouseStartLocation.Y, (Int32)_MouseLocation.X, (Int32)_MouseLocation.Y);

                _MouseStartLocation.X = 0;
                _MouseStartLocation.Y = 0;
                _MouseLocation.X = 0;
                _MouseLocation.Y = 0;
            }
            
            //BOUTON DROIT
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditMapObj)
                {
                    GlobalDataGame.CurrentMap.delete_objets(GlobalDataEditor.EngineEditorWinform.SelectObject.chklayer_Checked, x, y);
                }

                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditCollision && GlobalDataEditor.EngineEditorParameter.IsEditorActif == true)
                {

                }
            }
        }
        protected void PressKey_play(KeyboardState keyState)
        {
            if (this.IsActive == false)
                return;
 

            if (GlobalDataGame.character.Count > GlobalDataGame.Index)
            {
                Player character_temp = (Player)GlobalDataGame.character[GlobalDataGame.Index];
            
            #region KeyDown


            if (keyState.IsKeyDown(Keys.Up))
            {
             
                if (((IEntityClient)character_temp).CanMove(3, GlobalDataGame.CurrentMap))
                {
                    ((IEntityClient)character_temp).MakeMove(3);
                }
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                if (((IEntityClient)character_temp).CanMove(0, GlobalDataGame.CurrentMap))
                {
                    ((IEntityClient)character_temp).MakeMove(0);


                }
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                if (((IEntityClient)character_temp).CanMove(1, GlobalDataGame.CurrentMap))
                {
                    ((IEntityClient)character_temp).MakeMove(1);
                }
            }



            if (keyState.IsKeyDown(Keys.Right))
            {
                if (((IEntityClient)character_temp).CanMove(2, GlobalDataGame.CurrentMap))
                {
                    ((IEntityClient)character_temp).MakeMove(2);
                }
            }


            if (character_temp.Value >= 10)
            {
                character_temp.Value = 0;
                if (GlobalDataGame.online == true)
                {
                    socket.SendMove(character_temp.Direction, (int)character_temp.Location.X, (int)character_temp.Location.Y);
                }
            }
            //////////////////////
            //KEYS////////////////
            //////////////////////
            foreach (Keys curKey in keyState.GetPressedKeys())
            {
                if (curKey.ToString() != "LeftShift" || curKey.ToString() != "RightShift")
                {
                    this.key = curKey.ToString();
                }
            }


            #endregion
            #region KeyUp

            //Collision
            if (keyState.IsKeyUp(Keys.F11) && this.key == "F11")
            {
                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditCollision)
                {
                    GlobalDataGame.TypeScreen = 0;
                }
                else
                {
                    GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.EditCollision;
                    GlobalDataEditor.EngineEditorWinform.SelectObject.Visible = false;
                    GlobalDataEditor.EngineEditorWinform.SelectTileset.Visible = false;
                }
                this.key = "";
            }

            //Éditeur de map
            if (keyState.IsKeyUp(Keys.F12) && this.key == "F12")
            {
                if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditMapObj)
                {
                    GlobalDataEditor.EngineEditorWinform.SelectObject.Visible = false;
                    GlobalDataEditor.EngineEditorWinform.SelectTileset.Visible = false;
                    GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.Normal;
                }
                else
                {

                    GlobalDataEditor.EngineEditorWinform.SelectObject.Visible = true;
                    GlobalDataEditor.EngineEditorWinform.SelectTileset.Visible = true;
                    GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.EditMapObj;
                }
                this.key = "";
            }

            ///////////
            //CHAT/////
            ///////////
            if (keyState.IsKeyUp(Keys.Enter) && this.key == "Enter")
            {
                if (GlobalDataGame.focused == "chatbox")
                {
                    if (GlobalDataGame.online == true && _ChatText != String.Empty)
                        socket.SendMsg(_ChatText);

                    GlobalDataGame.focused = "";
                    _ChatText = "";
                    
                }
                else
                {
                    GlobalDataGame.focused = "chatbox";
                }
                this.key = "";
            }


            //TextBox Entry
            if (GlobalDataGame.focused == "chatbox")
            {
                foreach (Keys keyy in _KeyBoardChecker)
                {
                    Boolean UpperCase = false;
                    if (keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift))
                    {
                        UpperCase = true;
                    }
                    if (keyState.IsKeyDown(keyy) && this.key == keyy.ToString() && !_KeyboardOldState.IsKeyDown(keyy))
                    {
                        Key_AddChar("chatbox", keyy, UpperCase);
                        this.key = "";
                    }
                }
            }

            _KeyboardOldState = keyState;
            #endregion
            }
        }
        #endregion

        #endregion

        #region Draw

        public void draw_play(GameTime gametime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera.get_transformation(spriteBatch.GraphicsDevice));
            this.DrawGround_Play();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, null, null, null, null, _Camera.get_transformation(spriteBatch.GraphicsDevice));
            this.DrawMapBot_Play();
            this.DrawCharacter_Play();
            this.DrawNpc_Play();
            this.DrawMapTop_Play();

            if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditCollision) { this.DrawCollision_Play(); }
            if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditCollision) { this.DrawSelectCollision_Play(); }

            spriteBatch.End();

            spriteBatch.Begin();

            this.DrawChat_Play(gametime);
            this.DrawSkin_Play();
            this.DrawFps_Play();
            if (GlobalDataGame.TypeScreen == GlobalEnum.ScreenModeEnum.EditMapObj) { this.DrawSelectObj_play(); }

            spriteBatch.End();

            DrawNight_Play();


        }

        public void DrawNight_Play()
        {
     /*       BasicEffect BE = new BasicEffect(data.graphics.GraphicsDevice);
            BE.Texture = rect;

            BE.();
            //spriteBatch.Draw(rect, new Rectangle(0, 0, 1024, 768), new Color(0,0,0,15));

            spriteBatch.End();
            spriteBatch.Begin();

            spriteBatch.End();
      * */
        }

        //AFFICHAGE DE LA MAP//
        protected void DrawGround_Play()
        {
            for (int xi = 0; xi < GlobalDataGame.CurrentMap.SizeX / 16; xi++)
            {
                for (int yi = 0; yi < GlobalDataGame.CurrentMap.SizeY / 16; yi++)
                {
                    maptile tile_temp = (maptile)GlobalDataGame.maptile[GlobalDataGame.CurrentMap.Groundl1[xi, yi].sheet];

                    spriteBatch.Draw(tile_temp.sprites, new Rectangle(xi * 16, yi * 16, 16, 16), new Rectangle(GlobalDataGame.CurrentMap.Groundl1[xi, yi].x * 16, GlobalDataGame.CurrentMap.Groundl1[xi, yi].y * 16, 16, 16), Color.White);
                }
            }
        }
        
        //AFFICHAGE DE LA COUCHE HAUT
        protected void DrawMapTop_Play()
        {
            foreach(MapObject curMapObject in GlobalDataGame.CurrentMap.LayerTop)
            {
                if (curMapObject.idtile != -1)
                {
                    maptile tile_temp = (maptile)GlobalDataGame.maptileset[curMapObject.idtile];
                    spriteBatch.Draw(tile_temp.sprites, new Rectangle(curMapObject.sx, curMapObject.sy, curMapObject.sizex, curMapObject.sizey), new Rectangle(curMapObject.tilex, curMapObject.tiley, curMapObject.tilesizex, curMapObject.tilesizey), new Color(255, 255, 255, curMapObject.alpha));
                }
            }
        }

        //AFFICHAGE DE LA COUCHE BAS
        protected void DrawMapBot_Play()
        {
            foreach (MapObject curMapObject in GlobalDataGame.CurrentMap.LayerBot)
            {
                if (curMapObject.idtile != -1)
                {
                    maptile tile_temp = (maptile)GlobalDataGame.maptileset[curMapObject.idtile];
                    spriteBatch.Draw(tile_temp.sprites, new Rectangle(curMapObject.sx, curMapObject.sy, curMapObject.sizex, curMapObject.sizey), new Rectangle(curMapObject.tilex, curMapObject.tiley, curMapObject.tilesizex, curMapObject.tilesizey), new Color(255, 255, 255, curMapObject.alpha));
                }
            }
        }

        //AFFICHAGE DES NPC
        protected void DrawNpc_Play()
        {
            Color shadow = new Color(100, 100, 100, 255);

            foreach(Npc curNpc in GlobalDataGame.npc_actif)
            {
                //Déclaration
                Vector2 FontOrigin = this._SpriteFont.MeasureString(curNpc.Name) / 2;

                //Draw Sprite
                spriteBatch.Draw(curNpc.Sprites, new Rectangle((int)curNpc.Location.X - ((curNpc.Sprites.Width / 4) / 2) + (curNpc.Sprites.Width / 4), (int)curNpc.Location.Y - (curNpc.Sprites.Height / 4) + (curNpc.Sprites.Height / 4), curNpc.Sprites.Width / 4, curNpc.Sprites.Height / 4), new Rectangle(curNpc.Frame * (curNpc.Sprites.Width / 4), curNpc.Direction * (curNpc.Sprites.Height / 4), curNpc.Sprites.Width / 4, curNpc.Sprites.Height / 4), new Color(0, 0, 0, 100), 180, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
                spriteBatch.Draw(curNpc.Sprites, new Rectangle((int)curNpc.Location.X - ((curNpc.Sprites.Width / 4) / 2), (int)curNpc.Location.Y - (curNpc.Sprites.Height / 4), curNpc.Sprites.Width / 4, curNpc.Sprites.Height / 4), new Rectangle(curNpc.Frame * (curNpc.Sprites.Width / 4), curNpc.Direction * (curNpc.Sprites.Height / 4), curNpc.Sprites.Width / 4, curNpc.Sprites.Height / 4), new Color(255, 255, 255, 255));

                //Draw Name
                this.spriteBatch.DrawString(this._SpriteFont, curNpc.Name, new Vector2(curNpc.Location.X + ((curNpc.Sprites.Width / 4) / 2) - ((curNpc.Sprites.Width / 4) / 2), curNpc.Location.Y - ((curNpc.Sprites.Height / 4) / 2) + 2 - (curNpc.Sprites.Height / 4)), shadow, 0, FontOrigin, 0.8f, SpriteEffects.None, 0);
                this.spriteBatch.DrawString(this._SpriteFont, curNpc.Name, new Vector2(curNpc.Location.X + ((curNpc.Sprites.Width / 4) / 2) - ((curNpc.Sprites.Width / 4) / 2), curNpc.Location.Y - ((curNpc.Sprites.Height / 4) / 2) - (curNpc.Sprites.Height / 4)), Color.White, 0, FontOrigin, 0.8f, SpriteEffects.None, 0);
                
                //Draw HP
                if (curNpc.HP != curNpc.MaxHP)
                {
                    spriteBatch.Draw(_RectangleTexture, new Rectangle((int)curNpc.Location.X - 1 - ((curNpc.Sprites.Width / 4) / 2), (int)curNpc.Location.Y + (curNpc.Sprites.Height / 4) - 1 - (curNpc.Sprites.Height / 4), ((curNpc.Sprites.Width / 4) + 2) * 90 / 100, 5), new Color(0, 25, 0, 200));//(Shadow)
                    spriteBatch.Draw(_RectangleTexture, new Rectangle((int)curNpc.Location.X - ((curNpc.Sprites.Width / 4) / 2), (int)(curNpc.Location.Y + (curNpc.Sprites.Height / 4)) - (curNpc.Sprites.Height / 4), ((curNpc.Sprites.Width / 4) * 90 / 100) * curNpc.HP / curNpc.MaxHP, 3), new Color(0, 255, 0, 200));//(Barre)
                }
                //Draw Mp
                //  spriteBatch.Draw(rect, new Rectangle((int)(character_temp.location.X - 1), (int)character_temp.location.Y - ((character_temp.Sprites.Height / 4) / 2) + 14 + 6, ((character_temp.Sprites.Width / 4) + 2) * 90 / 100, 5), new Color(0, 0, 25, 200));
                // spriteBatch.Draw(rect, new Rectangle((int)character_temp.location.X, (int)character_temp.location.Y - ((character_temp.Sprites.Height / 4) / 2) + 15 + 6, (character_temp.Sprites.Width / 4) * 90 / 100, 3), new Color(0, 0, 255, 200));
            }

        }

        //AFFICHAGE DES PERSONNAGES//
        protected void DrawCharacter_Play()
        {
            Color shadow = new Color(100, 100, 100, 255);
            foreach (Player curPlayer in GlobalDataGame.character)
            {
                //Déclaration
                ((IEntityClient)curPlayer).animate();
                Vector2 FontOrigin = this._SpriteFont.MeasureString(curPlayer.Name) / 2;

                //Draw Shadow
                // spriteBatch.Draw(character_temp.Sprites, new Rectangle((int)character_temp.location.X - ((character_temp.Sprites.Width / 4) / 2) + ((character_temp.Sprites.Width / 4) / 2), (int)character_temp.location.Y - (character_temp.Sprites.Height / 4) + (character_temp.Sprites.Height / 4), character_temp.Sprites.Width / 4, character_temp.Sprites.Height / 4), new Rectangle(character_temp.frame * (character_temp.Sprites.Width / 4), character_temp.direction * (character_temp.Sprites.Height / 4), character_temp.Sprites.Width / 4, character_temp.Sprites.Height / 4), new Color(0, 0, 0, 100), 180, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);

                //Dray shadow
                spriteBatch.Draw(curPlayer.Sprites, new Rectangle((int)curPlayer.Location.X - ((curPlayer.Sprites.Width / 4) / 2), (int)curPlayer.Location.Y - (curPlayer.Sprites.Height / 4), curPlayer.Sprites.Width / 4, curPlayer.Sprites.Height / 4), new Rectangle(curPlayer.Frame * (curPlayer.Sprites.Width / 4), curPlayer.Direction * (curPlayer.Sprites.Height / 4), curPlayer.Sprites.Width / 4, curPlayer.Sprites.Height / 4), new Color(255, 255, 255, 255));

                //Draw Name
                this.spriteBatch.DrawString(this._SpriteFont, curPlayer.Name, new Vector2(curPlayer.Location.X + ((curPlayer.Sprites.Width / 4) / 2) - ((curPlayer.Sprites.Width / 4) / 2), curPlayer.Location.Y - ((curPlayer.Sprites.Height / 4) / 2) + 2 - (curPlayer.Sprites.Height / 4)), shadow, 0, FontOrigin, 0.8f, SpriteEffects.None, 0);
                this.spriteBatch.DrawString(this._SpriteFont, curPlayer.Name, new Vector2(curPlayer.Location.X + ((curPlayer.Sprites.Width / 4) / 2) - ((curPlayer.Sprites.Width / 4) / 2), curPlayer.Location.Y - ((curPlayer.Sprites.Height / 4) / 2) - (curPlayer.Sprites.Height / 4)), Color.White, 0, FontOrigin, 0.8f, SpriteEffects.None, 0);
                //Draw HP
                if (curPlayer.hp != curPlayer.maxhp)
                {
                    spriteBatch.Draw(_RectangleTexture, new Rectangle((int)curPlayer.Location.X - 1 - ((curPlayer.Sprites.Width / 4) / 2), (int)curPlayer.Location.Y + (curPlayer.Sprites.Height / 4) - 1 - (curPlayer.Sprites.Height / 4), ((curPlayer.Sprites.Width / 4) + 2) * 90 / 100, 5), new Color(0, 25, 0, 200));//(Shadow)
                    spriteBatch.Draw(_RectangleTexture, new Rectangle((int)curPlayer.Location.X - ((curPlayer.Sprites.Width / 4) / 2), (int)(curPlayer.Location.Y + (curPlayer.Sprites.Height / 4)) - (curPlayer.Sprites.Height / 4), ((curPlayer.Sprites.Width / 4) * 90 / 100) * curPlayer.hp / curPlayer.maxhp, 3), new Color(0, 255, 0, 200));//(Barre)
                }
                //Draw Mp
                //  spriteBatch.Draw(rect, new Rectangle((int)(character_temp.location.X - 1), (int)character_temp.location.Y - ((character_temp.Sprites.Height / 4) / 2) + 14 + 6, ((character_temp.Sprites.Width / 4) + 2) * 90 / 100, 5), new Color(0, 0, 25, 200));
                // spriteBatch.Draw(rect, new Rectangle((int)character_temp.location.X, (int)character_temp.location.Y - ((character_temp.Sprites.Height / 4) / 2) + 15 + 6, (character_temp.Sprites.Width / 4) * 90 / 100, 3), new Color(0, 0, 255, 200));
            }
        }

        protected void DrawSkin_Play()
        {
            //spriteBatch.Draw(this.skin, new Rectangle(5, 5, this.skin.Width, this.skin.Height), Color.White);
        }

        //AFFICHAGE DES SÉLECTIONS//
        protected void DrawSelectCollision_Play()
        {
            int sizex = (Int32)_MouseLocation.X - (Int32)_MouseStartLocation.X;
            int sizey = (Int32)_MouseLocation.Y - (Int32)_MouseStartLocation.Y;

            if (sizex > 0 && sizey > 0)
            {
                spriteBatch.Draw(_RectangleTexture, new Rectangle((Int32)_MouseStartLocation.X, (Int32)_MouseStartLocation.Y, sizex, sizey), new Color(50, 50, 50, 50));
            }
        }

        protected void DrawSelectObj_play()
        {
            MouseState mouseState = Mouse.GetState();

            Player character_temp = (Player)GlobalDataGame.character[GlobalDataGame.Index];
            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;
            if (GlobalDataEditor.EngineEditorParameter.IsMagnetism == true)
            {
                x = ((x / 32) * 32) - ((int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value / 2);
                y = ((y / 32) * 32) - ((int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value / 2);
            }
            else
            {
                x = x - ((int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value / 2);
                y = y - ((int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value / 2);
            }

            maptile tile = (maptile)GlobalDataGame.maptileset[GlobalDataEditor.EngineEditorParameter.SelectedTilesetID];

            spriteBatch.Draw(tile.sprites, new Rectangle(x, y, (int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value, (int)GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value), new Rectangle(GlobalDataEditor.EngineEditorWinform.SelectTileset.locationx, GlobalDataEditor.EngineEditorWinform.SelectTileset.locationy, (int)GlobalDataEditor.EngineEditorWinform.SelectTileset.sizex, (int)GlobalDataEditor.EngineEditorWinform.SelectTileset.sizey), new Color(10, 75, 0, 200));
        }

        protected void DrawCollision_Play()
        {
            Color rectcolor;
            for (int i = 0; i < GlobalDataGame.CurrentMap.Block.Count; i++)
            {
                Map.zone_block block_temp = (Map.zone_block)GlobalDataGame.CurrentMap.Block[i];
                
                if ((int)_MouseLocalisation.X > (int)block_temp.x && (int)_MouseLocalisation.Y > (int)block_temp.y && (int)_MouseLocalisation.X < (int)block_temp.x + (block_temp.x2 - block_temp.x) && (int)_MouseLocalisation.Y < (int)block_temp.y + (block_temp.y2 - block_temp.y))
                    rectcolor = new Color(100, 100, 100, 100);
                else
                    rectcolor = new Color(50, 50, 50, 50);

                spriteBatch.Draw(_RectangleTexture, new Rectangle((int)block_temp.x, (int)block_temp.y, (int)block_temp.x2 - block_temp.x, (int)block_temp.y2 - block_temp.y), rectcolor);
            }
        }

        protected void DrawChat_Play(GameTime gametime)
        {
            int i = GlobalDataGame.max_line;
            ArrayList LineArray_Temp = GlobalDataGame.ChatChannel.entry();
            chat.line line_temp;
            Color shadow = Color.Black;
            Vector2 FontOrigin = new Vector2(0, 0);

                while (i <= GlobalDataGame.max_line && i > 0)
                {
                    if (LineArray_Temp.Count - i > -1)
                    {
                        line_temp = (chat.line)LineArray_Temp[LineArray_Temp.Count - i];
                        this.spriteBatch.DrawString(this._SpriteFont, line_temp.text, new Vector2(20, ((this.Window.ClientBounds.Height - 20) - (GlobalDataGame.max_line - i) * 15) + 2), shadow, 0, FontOrigin, 0.6F, SpriteEffects.None, 0);
                        this.spriteBatch.DrawString(this._SpriteFont, line_temp.text, new Vector2(20, (this.Window.ClientBounds.Height - 20) - (GlobalDataGame.max_line - i) * 15), line_temp.color, 0, FontOrigin, 0.6F, SpriteEffects.None, 0);
                    }
                    i--;
            }

            if (GlobalDataGame.focused == "chatbox")
            {
                _KeyTimer.time += gametime.ElapsedGameTime.Milliseconds;
                if (_KeyTimer.Istime())
                    this.spriteBatch.DrawString(this._SpriteFont, "Message: " + _ChatText, new Vector2(20, ((this.Window.ClientBounds.Height - 20) - (GlobalDataGame.max_line + 1) * 15) + 2), Color.White, 0, FontOrigin, 0.7F, SpriteEffects.None, 0);
                else
                    this.spriteBatch.DrawString(this._SpriteFont, "Message: " + _ChatText + "|", new Vector2(20, ((this.Window.ClientBounds.Height - 20) - (GlobalDataGame.max_line + 1) * 15) + 2), Color.White, 0, FontOrigin, 0.7F, SpriteEffects.None, 0);
            }

        }
        protected void DrawFps_Play()
        {
            //   this.spriteBatch.DrawString(this.spriteFont, this.fpsc.ToString(), new Vector2(config.screenx - 20, 10), Color.White);
        }
        #endregion


        #region Traitement
        protected void Refresh_Map()
        {
            GlobalDataGame.screen = 0;
            Int32 mapid = GlobalDataGame.maplocation;
            Map curmaptemp = new Map(mapid);

            if (GlobalDataGame.online == false)
            {
                //DirectLoad
                ((IMapClient)curmaptemp).LoadMap(false);
                GlobalDataGame.CurrentMap = curmaptemp;
                GlobalDataGame.NeedEffect = true;
                GlobalDataGame.NeedMap = false;
                GlobalDataGame.screen = GlobalEnum.XNAScreensType.Play;
            }
            else
            {
                //NeedMap to continue
                //if (curmaptemp.revision != data.MapRevision)
                //{
                if (socket.IsWaitMap == false)
                {
                    socket.SendRequestSendMap();
                    socket.IsWaitMap = true;
                }
            }
        }

        protected void Refresh_Effects()
        {
            if (GlobalDataGame.CurrentMap.FogTexture != String.Empty || GlobalDataGame.CurrentMap.FogTexture  != null)
            {
                if (File.Exists(GlobalDataGame.ProjectPath + "/graphics/fogs/" + GlobalDataGame.CurrentMap.FogTexture))
                {
                    if (this.Components.Contains(_FogComponent))
                        this.Components.Remove(_FogComponent);

                    this.Components.Add(_FogComponent);
                    Stream stream1 = File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/fogs/" + GlobalDataGame.CurrentMap.FogTexture);
                    _FogComponent._Fog = Texture2D.FromStream(GlobalDataGame.graphics.GraphicsDevice, stream1);
                }
            }
        }
            
        #endregion
    }
}
