using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace MmorpgEngine
{
    [Serializable]
    public class Condition
    {
        public Int32 id;
        public String name;
        public String color;

        public Condition(Int32 id)
        {
            this.id = id;
        }

        public Condition(String name, String color)
        {
            this.name = name;
            this.color = color;
        }

        public void SaveConditionOnServer()
        {
                Stream stream;

                stream = new FileStream("database/conditions/" + id + ".dat", FileMode.Truncate, FileAccess.Write, FileShare.None);
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, name);
                formatter.Serialize(stream, color);

                stream.Close();

        }
    }


}