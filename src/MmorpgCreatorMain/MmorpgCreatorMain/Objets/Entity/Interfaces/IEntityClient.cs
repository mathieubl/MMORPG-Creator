using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MmorpgCreatorMain
{
    public interface IEntityClient
    {
        void animate();
        void MoveX();
        void MoveY();
        Boolean CanMove(byte dir, Map currentMapToCheck);
        void MakeMove(byte dir);
        Vector2 Mouse(Int32 CX, Int32 CY, Int32 screenX, Int32 screenY);
    }
}
