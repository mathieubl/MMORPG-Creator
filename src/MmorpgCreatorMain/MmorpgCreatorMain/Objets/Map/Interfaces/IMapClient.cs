using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MmorpgCreatorMain
{
    public interface IMapClient
    {
        Boolean HitCollisionTest(Vector2 location);
        void SaveMap(Boolean onServer = false);
        void LoadMap(Boolean onServer = false, String mapName = null);
    }
}
