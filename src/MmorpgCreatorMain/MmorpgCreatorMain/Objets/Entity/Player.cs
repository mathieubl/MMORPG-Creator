using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MmorpgCreatorMain
{
     [Serializable]
    public class Player : Entity, IPlayerServer
    {
        //General
        public Int32 Map = 1;
 

        //PARAMÈTRES
        Int32 access = 0;
        Int32 group = 0;
        Int32 guild = 0;

        //STATS GENERAL
        public Int32 hp = 1;
        public Int32 maxhp = 1;
        Int32 mp = 0;
        Int32 xp = 0;

        Int32 strength = 0;//Force de frappe
        Int32 agility = 0;//Vitesse d'attaque
        Int32 intelligence = 0;//Capacité à utiliser les spells
        Int32 constitution = 0;//Points de vie
        Int32 dexterity = 0;//Capacité à évité
        public ArrayList skill = new ArrayList();//Talents
        public ArrayList spell = new ArrayList();//Techniques

        //EQUIPEMENTS
        Int32 helmet = 0;
        Int32 righthand = 0;
        Int32 lefthand = 0;
        Int32 armor = 0;
        Int32 amulet1 = 0;
        Int32 amulet2 = 0;

        public Player(int id, string cname, int cx, int cy, Texture2D sprites)
        {
            this.ID = id;
            Location = new Vector2(cx, cy);
            this.Name = cname;
            Sprites = sprites;
            NextLocation = new Vector2(cx, cy);
        }

        public Player(String name)
        {
            this.Name = name;
        }

        #region Server functions

        public Boolean PasswordVerification(String pass)
        {
            Boolean value = new Boolean();
        
            XPathDocument doc = new XPathDocument("database/accounts/" + this.Name + ".xml");
            XPathNavigator nav = doc.CreateNavigator();
            // On récupère un XPathNodeIterator sur les Record
            XPathNodeIterator iter = nav.Select("account/character");
            // Pour chaque Record
            while (iter.MoveNext())
            {
                if (pass == iter.Current.SelectSingleNode("password").Value)
                    value = true;
                else
                    value = false;
            }
            return value;
        }

        void IPlayerServer.LoadPlayer()
        {
            XPathDocument doc = new XPathDocument("database/accounts/" + this.Name + ".xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select("account/character");
            while (iter.MoveNext())
            {
                this.Name = iter.Current.SelectSingleNode("name").Value;
                this.ID = System.Convert.ToInt32(iter.Current.SelectSingleNode("id").Value);
                _Sprite = iter.Current.SelectSingleNode("sprite").Value;
                Map = System.Convert.ToInt32(iter.Current.SelectSingleNode("location").SelectSingleNode("map").Value);
                Location.X = System.Convert.ToInt32(iter.Current.SelectSingleNode("location").SelectSingleNode("x").Value);
                Location.Y = System.Convert.ToInt32(iter.Current.SelectSingleNode("location").SelectSingleNode("y").Value);
            }
        }

        void IPlayerServer.SavePlayer()
        {

        }
        #endregion
    }
}
