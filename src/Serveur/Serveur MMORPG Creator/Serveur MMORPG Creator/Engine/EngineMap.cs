using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmorpgCreatorMain;

namespace MmorpgEngine
{
    public class EngineMap
    {
        private List<Map> _Maps = new List<Map>();

        public List<Map> Maps
        {
            get
            {
                return _Maps;
            }

            set
            {
                _Maps = value;
            }
        }


        public void SpawnNpc(Int32 mapIndex, Int32 npcIndex, Int32 x, Int32 y)
        {
            Npc currentNPCPattern = GlobalEngine._NpcEngine.Npcs[npcIndex];

            _Maps[mapIndex].Npc_actif.Add(new Npc(_Maps[mapIndex].Npc_actif.Count, currentNPCPattern.Name, x, y, currentNPCPattern.Sprite));

            GlobalEngine.Socket.Packet_AddMapNpc(mapIndex, _Maps[mapIndex].Npc_actif.Count - 1);

        }

    }
}
