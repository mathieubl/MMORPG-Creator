using System.Collections.Generic;

namespace MmorpgEngine.Engine
{
    public class EngineItem
    {
        private List<Item> _Items = new List<Item>();

        public List<Item> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                _Items = value;
            }
        }

    }
}
