using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace MmorpgEngine
{
    [Serializable]
    class condition
    {
        public int id;
        public string name;
        public string color;


        public condition(int id)
        {
            this.id = id;
        }

        public condition(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void SaveConditionOnServer()
        {
            if (GlobalDataGame.online == true)
            {

            }
            else
            {
                Stream stream;

                stream = new FileStream(GlobalDataGame.ProjectPath + "../Server/database/conditions/" + id + ".dat", FileMode.Truncate, FileAccess.Write, FileShare.None);
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, name);
                formatter.Serialize(stream, color);

                stream.Close();
            }
        }

    }


}