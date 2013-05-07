using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgCreatorMain
{
    public enum EnumClientPacket
    {
        Msg,
        Logged,
        RefreshMap,
        PlayerJoinMap,
        PlayerLeaveMap,
        PlayerBaseData,
        PlayerMove,
        AlertMsg,
        NpcJoinMap,
        NpcEditorList,
        MapEditorList,
        MapSendMap
    }
}
