using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
namespace MmorpgEngine
{
    class maptile
    {
        public Texture2D sprites;
        private string name;
        public maptile(Texture2D csprites, string name)
        {
            this.sprites = csprites;
            this.name = name;
        }

        public Texture2D get_texture()
        {
            return sprites;
        }

        public string get_name()
        {
            return name;
        }
    }
}
