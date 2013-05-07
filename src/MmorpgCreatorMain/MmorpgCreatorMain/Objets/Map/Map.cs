using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using MmorpgEngine;
namespace MmorpgCreatorMain
{
    public class Map : IMapServer, IMapClient
    {
        //General        
        private Int32 _ID;
        private String _Name;
        private Int32 _SizeX = 0;
        private Int32 _SizeY = 0;
        private Int32 _Revision = 0;
        private Boolean _IsModified = false;

        //Ambiance
        private Boolean _Time;
        private bool _Meteo;

        //Fog
        public Boolean _Fog;
        public String _FogTexture = String.Empty;
        public Boolean _FogMove = false;
        public Int32 _FogSpeedX = 1;
        public Int32 _FogSpeedY = 1;
        public Int32 _Fogalpha = 25;

        //Panorama
        public Boolean _Panorama;
        public String _PanoramaTexture = null;
        public Byte _PanoramaType = 0;
        public Int32 _PanoramaSpeedX = 1;
        public Int32 _PanoramaSpeedY = 1;

        //Paramètres autres
        public Boolean _ShowMapName = true;

        //Data
        public ground[,] _Groundl1;
        public List<zone_block> _Block = new List<zone_block>();
        public List<zone_event> _Events = new List<zone_event>();
        public List<MapObject> _LayerTop = new List<MapObject>();
        public List<MapObject> _LayerBot = new List<MapObject>();
        public List<npc_location> _Npc = new List<npc_location>();

        //Actif
        public List<Npc> _Npc_actif = new List<Npc>();
        public ArrayList _VarMap = new ArrayList();


        [Serializable]
        public struct ground
        {
            public int sheet;
            public int x;
            public int y;
        }

        [Serializable]
        public struct npc_location
        {
            public int id;
            public int x;
            public int y;
        }

        [Serializable]
        public struct zone_event
        {

        }

        [Serializable]
        public struct zone_block
        {
            public int x;
            public int y;
            public int x2;
            public int y2;
            public Byte Type;
            public int value;
        }

        public Map(Int32 id)
        {
            this._ID = id;
        }


        public void map_reset()
        {
            Name = "Carte #" + _ID;
            ground defaultfloor = new ground();
            defaultfloor.x = 0;
            defaultfloor.y = 0;
            defaultfloor.sheet = 1;
            SizeX = 100 * 16;
            SizeY = 100 * 16;
            Groundl1 = new ground[100, 100];

            for (int xi = 0; xi < 100; xi++)
            {
                for (int yi = 0; yi < 100; yi++)
                {
                    Groundl1[xi, yi] = defaultfloor;
                }

            }

        }


        public void resize_map(int nsizex, int nsizey)
        {
            int osizex = SizeX;
            int osizey = SizeY;
            SizeX = nsizex;
            SizeY = nsizey;

            ground[,] ngroundl1 = new ground[SizeX / 16, SizeY / 16];

            for (int xi = 0; xi < osizex / 16 && xi < SizeX / 16; xi++)
            {
                for (int yi = 0; yi < osizey / 16 && yi < SizeY / 16; yi++)
                {
                    ngroundl1[xi, yi] = Groundl1[xi, yi];
                }
            }

            Groundl1 = ngroundl1;

            for (int i = 0; i < LayerBot.Count; i++)
            {
                MapObject obj = (MapObject)LayerBot[i];

                if (obj.sx > nsizex || obj.sy > nsizey)
                {
                    LayerBot.RemoveAt(i);
                }
            }


            for (int i = 0; i < LayerTop.Count; i++)
            {
                MapObject obj = (MapObject)LayerTop[i];

                if (obj.sx > nsizex || obj.sy > nsizey)
                {
                    LayerTop.RemoveAt(i);
                }
            }


  
        }

        public void set_ground(int x, int y, int id, int xs, int ys)
        {
            Groundl1[x, y].sheet = id;
            Groundl1[x, y].x = xs;
            Groundl1[x, y].y = ys;
        }

        public void create_collision(int x, int y, int sizex, int sizey)
        {
            zone_block block_temp;
            Block.Add(new zone_block());
            block_temp.x = x;
            block_temp.y = y;
            block_temp.x2 = x + sizex;
            block_temp.y2 = y + sizey;
            block_temp.Type = 0;
            block_temp.value = 0;
            Block[Block.Count - 1] = block_temp;
        }

        public void create_objets(int idtile, Boolean layer, int sx, int sy, int sizex, int sizey, int alpha, int tilex, int tiley, int tilesizex, int tilesizey)
        {
            if (layer == true)
            {
                LayerTop.Add(new MapObject(sx, sy, sizex, sizey, alpha, idtile, tilex, tiley, tilesizex, tilesizey));
            }
            else
            {
                LayerBot.Add(new MapObject(sx, sy, sizex, sizey, alpha, idtile, tilex, tiley, tilesizex, tilesizey));
            }
        }

        public void delete_objets(bool layer, int x, int y)
        {

            if (layer == true)
            {
                for (int i = 0; i < LayerTop.Count; i++)
                {
                    MapObject layertop_temps = (MapObject)LayerTop[i];

                    if (x > layertop_temps.sx && x < layertop_temps.sx + layertop_temps.sizex && y > layertop_temps.sy && y < layertop_temps.sy + layertop_temps.sizey)
                    {
                        LayerTop.RemoveAt(i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < LayerBot.Count; i++)
                {
                    MapObject layerbot_temps = (MapObject)LayerBot[i];

                    if (x > layerbot_temps.sx && x < layerbot_temps.sx + layerbot_temps.sizex && y > layerbot_temps.sy && y < layerbot_temps.sy + layerbot_temps.sizey)
                    {
                        LayerBot.RemoveAt(i);
                    }
                }
            }
        }

        public void SerializeMap(String patch)
        {
            Stream stream;
            IFormatter formatter;

            stream = new FileStream(patch, FileMode.Create);
            formatter = new BinaryFormatter();


            formatter.Serialize(stream, _Name);
            formatter.Serialize(stream, _SizeX);
            formatter.Serialize(stream, _SizeY);


            formatter.Serialize(stream, Time);
            formatter.Serialize(stream, Meteo);
            formatter.Serialize(stream, Fog);
            formatter.Serialize(stream, FogTexture);
            formatter.Serialize(stream, FogMove);
            formatter.Serialize(stream, FogSpeedX);
            formatter.Serialize(stream, FogSpeedY);

            formatter.Serialize(stream, Groundl1);
            formatter.Serialize(stream, Block);
            formatter.Serialize(stream, Events);
            formatter.Serialize(stream, LayerBot);
            formatter.Serialize(stream, LayerTop);
            formatter.Serialize(stream, Npc);
            stream.Close();
        }

        public MemoryStream SerializeMapMemory()
        {
            MemoryStream stream;
            IFormatter formatter;

            stream = new MemoryStream();
            formatter = new BinaryFormatter();


            formatter.Serialize(stream, Name);
            formatter.Serialize(stream, SizeX);
            formatter.Serialize(stream, SizeY);


            formatter.Serialize(stream, Time);
            formatter.Serialize(stream, Meteo);
            formatter.Serialize(stream, Fog);
            formatter.Serialize(stream, FogTexture);
            formatter.Serialize(stream, FogMove);
            formatter.Serialize(stream, FogSpeedX);
            formatter.Serialize(stream, FogSpeedY);

            formatter.Serialize(stream, Groundl1);
            formatter.Serialize(stream, Block);
            formatter.Serialize(stream, Events);
            formatter.Serialize(stream, LayerBot);
            formatter.Serialize(stream, LayerTop);
            formatter.Serialize(stream, Npc);

            return stream;
        }
        
        public void DeserializeMap(String patch)
        {
            try
            {
                Stream stream;
                stream = new FileStream(patch, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                Name = (String)bFormatter.Deserialize(stream);
                SizeX = (Int32)bFormatter.Deserialize(stream);
                SizeY = (Int32)bFormatter.Deserialize(stream);

                Time = (Boolean)bFormatter.Deserialize(stream);
                Meteo = (Boolean)bFormatter.Deserialize(stream);

                Fog = (Boolean)bFormatter.Deserialize(stream);
                FogTexture = (String)bFormatter.Deserialize(stream);
                FogMove = (Boolean)bFormatter.Deserialize(stream);
                FogSpeedX = (Int32)bFormatter.Deserialize(stream);
                FogSpeedY = (Int32)bFormatter.Deserialize(stream);

                Groundl1 = (ground[,])bFormatter.Deserialize(stream);

                Block = (List<zone_block>)bFormatter.Deserialize(stream);

                Events = (List<zone_event>)bFormatter.Deserialize(stream);

                LayerBot = (List<MapObject>)bFormatter.Deserialize(stream);
                LayerTop = (List<MapObject>)bFormatter.Deserialize(stream);
                Npc = (List<npc_location>)bFormatter.Deserialize(stream);

                stream.Close();
            }
            catch
            {
                map_reset();
            }
        }

        public void DeserializeMap(MemoryStream stream)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();


            _Name = (String)bFormatter.Deserialize(stream);
            SizeX = (Int32)bFormatter.Deserialize(stream);
            SizeY = (Int32)bFormatter.Deserialize(stream);

            _Time = (Boolean)bFormatter.Deserialize(stream);
            _Meteo = (Boolean)bFormatter.Deserialize(stream);

            _Fog = (Boolean)bFormatter.Deserialize(stream);
            FogTexture = (String)bFormatter.Deserialize(stream);
            FogMove = (Boolean)bFormatter.Deserialize(stream);
            FogSpeedX = (Int32)bFormatter.Deserialize(stream);
            FogSpeedY = (Int32)bFormatter.Deserialize(stream);

            _Groundl1 = (ground[,])bFormatter.Deserialize(stream);

            _Block = (List<zone_block>)bFormatter.Deserialize(stream);

            _Events = (List<zone_event>)bFormatter.Deserialize(stream);

            _LayerBot = (List<MapObject>)bFormatter.Deserialize(stream);
            _LayerTop = (List<MapObject>)bFormatter.Deserialize(stream);
            _Npc = (List<npc_location>)bFormatter.Deserialize(stream);

            stream.Close();
        }


        #region propriétés

        public Int32 ID
        {
            get
            {
                return  _ID;
            }

            set
            {
                 _ID = value;
            }
        }

        public String Name
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


        public int SizeX
        {
            get
            {
                return _SizeX;
            }

            set
            {
                _SizeX = value;
            }
        }

        public int SizeY
        {
            get
            {
                return _SizeY;
            }

            set
            {
                _SizeY = value;
            }
        }

        public Int32 Revision
        {
            get
            {
                return _Revision;
            }

            set
            {
                _Revision = value;
            }
        }

        public Boolean IsModified
        {
            get
            {
                return _IsModified;
            }

            set
            {
                _IsModified = value;
            }
        }

        public Boolean Time
        {
            get
            {
                return _Time;
            }

            set
            {
                _Time = value;
            }
        }

        public Boolean Meteo
        {
            get
            {
                return _Meteo;
            }

            set
            {
                _Meteo = value;
            }
        }

        public Boolean Fog
        {
            get
            {
                return _Fog;
            }

            set
            {
                _Fog = value;
            }
        }

        public String FogTexture
        {
            get
            {
                return _FogTexture;
            }

            set
            {
                _FogTexture = value;
            }
        }


        public Boolean FogMove
        {
            get
            {
                return _FogMove;
            }

            set
            {
                _FogMove = value;
            }
        }


        public Int32 FogSpeedX
        {
            get
            {
                return _FogSpeedX;
            }

            set
            {
                _FogSpeedX = value;
            }
        }

        public Int32 FogSpeedY
        {
            get
            {
                return _FogSpeedY;
            }

            set
            {
                _FogSpeedY = value;
            }
        }

        public Int32 Fogalpha
        {
            get
            {
                return _Fogalpha;
            }

            set
            {
                _Fogalpha = value;
            }
        }

        public Boolean Panorama
        {
            get
            {
                return _Panorama;
            }

            set
            {
                _Panorama = value;
            }
        }

        public String PanoramaTexture
        {
            get
            {
                return _PanoramaTexture;
            }

            set
            {
                _PanoramaTexture = value;
            }
        }

        public Byte PanoramaType
        {
            get
            {
                return _PanoramaType;
            }

            set
            {
                _PanoramaType = value;
            }
        }

        public Int32 PanoramaSpeedX
        {
            get
            {
                return _PanoramaSpeedX;
            }

            set
            {
                _PanoramaSpeedX = value;
            }
        }

        public Int32 PanoramaSpeedY
        {
            get
            {
                return _PanoramaSpeedY;
            }

            set
            {
                _PanoramaSpeedY = value;
            }
        }

        public Boolean ShowMapName
        {
            get
            {
                return _ShowMapName;
            }

            set
            {
                _ShowMapName = value;
            }
        }


        public ground[,] Groundl1
        {
            get
            {
                return _Groundl1;
            }

            set
            {
                _Groundl1 = value;
            }
        }


        public List<zone_block> Block
        {
            get
            {
                return _Block;
            }

            set
            {
                _Block = value;
            }
        }

        public List<zone_event> Events
        {
            get
            {
                return _Events;
            }

            set
            {
                _Events = value;
            }
        }

        public List<MapObject> LayerTop
        {
            get
            {
                return _LayerTop;
            }

            set
            {
                _LayerTop = value;
            }
        }

        public List<MapObject> LayerBot
        {
            get
            {
                return _LayerBot;
            }

            set
            {
                _LayerBot = value;
            }
        }

        public List<npc_location> Npc
        {
            get
            {
                return _Npc;
            }

            set
            {
                _Npc = value;
            }
        }


        public List<Npc> Npc_actif
        {
            get
            {
                return _Npc_actif;
            }

            set
            {
                _Npc_actif = value;
            }
        }


        public ArrayList VarMap
        {
            get
            {
                return _VarMap;
            }

            set
            {
                _VarMap = value;
            }
        }
        #endregion


        #region Client Commande

        void IMapClient.LoadMap(Boolean onServer = false, String mapName = null)
        {
            String nameOfMap = String.Empty;
            String patch = String.Empty;
            if (mapName == null)
            {
                nameOfMap = _ID.ToString() + ".dat";
            }
            else
            {
                nameOfMap = mapName;
            }

            if (onServer == true)
            {
                patch = GlobalClass.AppPath + "../Server/database/maps/" + nameOfMap;
            }
            else
            {
                patch = GlobalClass.AppPath + "/data/maps/" + nameOfMap;
            }


            DeserializeMap(patch);
        
        }

        void IMapClient.SaveMap(Boolean onServer = false)
        {
            String patch = "";

            if (onServer == false)
            {
                patch = GlobalClass.AppPath + "/data/maps/" + _ID + ".dat";

            }
            else
            {
                patch = GlobalClass.AppPath + "../Server/database/maps/" + _ID + ".dat";
            }

            SerializeMap(patch);
        }

        Boolean IMapClient.HitCollisionTest(Vector2 location)
        {
            //Charge les joueurs de la map
            foreach (zone_block collision in Block)
            {
                if (location.X > collision.x && location.X < collision.x2 && location.Y > collision.y && location.Y < collision.y2)
                {
                    return false;
                }
            }
            return true;
        }
#endregion


        #region Serveur commande


       /* void IMapServer.create_collision(Rectangle zone)
        {
            /* zone_block block_temp;
             block.Add(new zone_block());
             block_temp.location = zone;
             block_temp.Type = 0;
             block_temp.value = 0;
             block[block.Count - 1] = block_temp;
             * 
             * 
        }*/

        void IMapServer.SaveMap()
        {
            Stream stream;

            stream = new FileStream("database/maps/" + _ID + ".dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, Name);
            formatter.Serialize(stream, SizeX);
            formatter.Serialize(stream, SizeY);

            formatter.Serialize(stream, Time);
            formatter.Serialize(stream, Meteo);
            formatter.Serialize(stream, Fog);
            formatter.Serialize(stream, FogTexture);
            formatter.Serialize(stream, FogMove);
            formatter.Serialize(stream, FogSpeedX);
            formatter.Serialize(stream, FogSpeedY);

            formatter.Serialize(stream, Groundl1);
            formatter.Serialize(stream, Block);
            formatter.Serialize(stream, Events);
            formatter.Serialize(stream, LayerBot);
            formatter.Serialize(stream, LayerTop);
            formatter.Serialize(stream, Npc);
            stream.Close();
        }


        void IMapServer.LoadMap()
        {
            String Patch = "database/maps/" + ID + ".dat";

            DeserializeMap(Patch);
        }

       Boolean IMapServer.HitCollisionTest(Vector2 location)
        {

            /*//Charge les joueurs de la map
            foreach (zone_block collision in this.block)
            {
                if (location.X > collision.location.Left && location.X < collision.location.Right && location.Y > collision.location.Top && location.Y < collision.location.Bottom)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
           
            */
            return true;
        }
        #endregion
    }
}
