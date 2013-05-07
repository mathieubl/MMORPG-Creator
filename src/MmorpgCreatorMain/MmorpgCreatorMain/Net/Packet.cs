using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgCreatorMain
{
    public class Packet
    {
        public Int32 _PacketID;
        public List<String> _Datas;

        public Packet(String flux, char separator)
        {
            String[] datasArray = flux.Split(separator);

            _PacketID = Convert.ToInt32(datasArray[0]);

            Boolean firstElement = true;
            foreach(String curString in datasArray)
            {
               if (!firstElement)
                   _Datas.Add(curString);



            }


        }

    }
}
