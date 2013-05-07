using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgCreatorMain
{
    public enum EnumServerPacket
    {
        Login,
        JoinGame,
        RequestWarp,
        Msg,
        MovePlayer,
        RequestNpcEditorList,
        RequestMapEditorList,
        RequestSendMap,
        SendSendMap
    }
}
