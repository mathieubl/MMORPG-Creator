using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MmorpgCreatorMain
{
    [Serializable]
    public class Npc : Entity, INpcServer
    {
        public Int32 _HP;
        public Int32 _MaxHP;

        private Int32 _Attack;
        private Int32 _AttackType;
        private Int32 _DefencePhysic;
        private Int32 _DefenceMagic;
        private Int32 _SpeedAttack;
        private Int32 _AnimationAttack;
        private Int32 _XP;

      [Serializable]
       public struct lstobj
        {
            Int32 objet;
            Int32 chance;
        }

      [Serializable]
       public struct Condition
       {
          Int32 objet;
          Int32 chance;
       }

       public List<Int32> Skill = new List<Int32>();
       public List<lstobj> Drop = new List<lstobj>();
       public List<Condition> Resistance = new List<Condition>();

        public Npc(int id, string cname, int cx, int cy, string Sprite)
        {
            this._ID = id;
            Location = new Vector2(cx, cy);
            this.Name = cname;
            _Sprite = Sprite;
            NextLocation = new Vector2(cx, cy);
        }

        public Npc(Int32 id)
        {
            this.ID = id;
        }


        public Npc(Int32 id, String cname, Int32 cx, Int32 cy, Texture2D sprites)
        {
            this.ID = id;
            Location = new Vector2(cx, cy);
            this.Name = cname;
            Sprites = sprites;
            NextLocation = new Vector2(cx, cy);
        }

        void INpcServer.SaveNpc()
        {
            Stream stream;
            stream = new FileStream("database/npcs/" + ID + ".dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            
            formatter.Serialize(stream, this);

            stream.Close();
        }

        void INpcServer.LoadNpc()
        {
            Stream stream  = new FileStream("database/npcs/" + ID + ".dat", FileMode.Open);;
            try
            {
                BinaryFormatter bFormatter = new BinaryFormatter();

                Name = (String)bFormatter.Deserialize(stream);
                Speed = (Int32)bFormatter.Deserialize(stream);
                Sprite = (String)bFormatter.Deserialize(stream);
                _MaxHP = (Int32)bFormatter.Deserialize(stream);
                _Attack = (Int32)bFormatter.Deserialize(stream);
                _AttackType = (Int32)bFormatter.Deserialize(stream);
                _DefencePhysic = (Int32)bFormatter.Deserialize(stream);
                _DefenceMagic = (Int32)bFormatter.Deserialize(stream);
                _SpeedAttack = (Int32)bFormatter.Deserialize(stream);
                _AnimationAttack = (Int32)bFormatter.Deserialize(stream);
                _XP = (Int32)bFormatter.Deserialize(stream);
                Skill = (List<Int32>)bFormatter.Deserialize(stream);
                Drop = (List<lstobj>)bFormatter.Deserialize(stream);
                Resistance = (List<Condition>)bFormatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                stream.Close();

            }
        }
       
        public void ResetNpc()
        {
           _HP = 0;
           _MaxHP = 0;
        }

        #region propriétés
        public Int32 HP
        {
            get
            {
                return _HP;
            }

            set
            {
                _HP = value;
            }
        }

        public Int32 MaxHP
        {
            get
            {
                return _MaxHP;
            }

            set
            {
                _MaxHP = value;
            }
        }
        #endregion



    }


    

     
}
