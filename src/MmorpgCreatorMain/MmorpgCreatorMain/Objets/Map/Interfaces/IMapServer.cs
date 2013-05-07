using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MmorpgCreatorMain
{
    public interface IMapServer
    {
        Boolean HitCollisionTest(Vector2 location);
        void LoadMap();
        void SaveMap();
       // void create_collision(Rectangle zone);

       // void respawn_npc();

    }
}
