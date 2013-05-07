using System;
using System.Collections;

using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace amdaro
{
    class map
    {
        string name;
        public int sizex = 0;
        public int sizey = 0;
       
        public struct tile
        {
            public int idtiles;
            public int sx;
            public int sy;
            public int sizex;
            public int sizey;
            public int alpha;
            public bool collision;
        }

        public struct zone
        {
           public Vector2 location1;
           public Vector2 location2;
        }


        public int[,] ground;
        public ArrayList block = new ArrayList();
        public ArrayList layertop = new ArrayList();
        public ArrayList layerbot = new ArrayList();
       public map(int csizex, int csizey, string cname)
       {
           name = cname;
           sizex = csizex;
           sizey = csizey;
           this.ground = new int[sizex / 32, sizey / 32];
       }

       public void create_collision(Vector2 coordonnee1, Vector2 coordonnee2)
       {
           zone block_temp;
           block.Add(new zone());
           block_temp.location1 = coordonnee1;
           block_temp.location2 = coordonnee2;
           block[block.Count - 1] = block_temp;
       }

       public void create_objets(Boolean layer, int idtiles, int sx, int sy, int sizex, int sizey, int alpha, Boolean collision)
        {
            if (layer == true)
            {
                tile layertop_temps;
                layertop.Add(new tile());
                layertop_temps.idtiles = idtiles;
                layertop_temps.sx = sx;
                layertop_temps.sy = sy;
                layertop_temps.sizex = sizex;
                layertop_temps.sizey = sizey;
                layertop_temps.alpha = alpha;
                layertop_temps.collision = collision;
                layertop[layertop.Count - 1] = layertop_temps;
            }
            else
            {
                tile layerbot_temps;
                layerbot.Add(new tile());
                layerbot_temps.idtiles = idtiles;
                layerbot_temps.sx = sx;
                layerbot_temps.sy = sy;
                layerbot_temps.sizex = sizex;
                layerbot_temps.sizey = sizey;
                layerbot_temps.alpha = alpha;
                layerbot_temps.collision = collision;
                layerbot[layerbot.Count - 1] = layerbot_temps;
            }
        }

       public void delete_objets(int x, int y)
       {
           layertop.Clear();

           for (int i = 0; i < layerbot.Count; i++)
           {
               tile layerbot_temps = (tile)layerbot[i];

               if (layerbot_temps.idtiles != 0)
               {
                   if (x > layerbot_temps.sx && x < layerbot_temps.sx + layerbot_temps.sizex && y > layerbot_temps.sy && y < layerbot_temps.sy + layerbot_temps.sizey)
                   {
                       layerbot_temps.idtiles = 0;
                      layerbot[i] = layerbot_temps;
                   }
               }
           }
      
       }
    }
}
