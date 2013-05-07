using System;
namespace MmorpgEngine
{
    [Serializable]
    public class MapObject
    {
        public Int32 sx;
        public Int32 sy;
        public Int32 sizex;
        public Int32 sizey;
        public Int32 alpha;

        public Int32 idtile;
        public Int32 tilex;
        public Int32 tiley;
        public Int32 tilesizex;
        public Int32 tilesizey;

        public MapObject(Int32 sx, Int32 sy, Int32 sizex, Int32 sizey, Int32 alpha, Int32 idtile, Int32 tilex, Int32 tiley, Int32 tilesizex, Int32 tilesizey)
        {
            this.sx = sx;
            this.sy = sy;
            this.sizex = sizex;
            this.sizey = sizey;
            this.alpha = alpha;
            this.tilex = tilex;
            this.tiley = tiley;
            this.tilesizex = tilesizex;
            this.tilesizey = tilesizey;
            this.idtile = idtile;
        }

    }
}



