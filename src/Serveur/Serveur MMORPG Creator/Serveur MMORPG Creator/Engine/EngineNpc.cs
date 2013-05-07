using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmorpgCreatorMain;

namespace MmorpgEngine
{
    public class EngineNpc
    {
        public List<Npc> _Npcs = new List<Npc>();

        public List<Npc> Npcs
        {
            get
            {
                return _Npcs;
            }

            set
            {
                _Npcs = value;
            }
        }
    }
}
