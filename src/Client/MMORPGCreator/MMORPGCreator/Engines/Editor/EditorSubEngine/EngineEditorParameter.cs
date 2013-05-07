using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgEngine.Engines
{
    public class EngineEditorParameter
    {
        //ÉDITION
        private Byte _SelectedObjectID = 1;
        private Byte _SelectedTilesetID = 0;
        private Boolean _IsLayerTopSelected = false;
        private Boolean _IsEditorActif = false;
        private Boolean _IsAutomaticSelection = false;
        private Boolean _IsMagnetism = false;


        #region  get/set
        public byte SelectedObjectID
        {
            get
            {
                return _SelectedObjectID;
            }

            set
            {
                _SelectedObjectID = value;
            }
        }

        public Byte SelectedTilesetID
        {
            get
            {
                return _SelectedTilesetID;
            }

            set
            {
                _SelectedTilesetID = value;
            }
        }

        public Boolean IsLayerTopSelected
        {
            get
            {
                return _IsLayerTopSelected;
            }

            set
            {
                _IsLayerTopSelected = value;
            }
        }

        public Boolean IsEditorActif
        {
            get
            {
                return _IsEditorActif;
            }

            set
            {
                _IsEditorActif = value;
            }
        }

        public Boolean IsAutomaticSelection
        {
            get
            {
                return _IsAutomaticSelection;
            }

            set
            {
                _IsAutomaticSelection = value;
            }
        }

        public Boolean IsMagnetism
        {
            get
            {
                return _IsMagnetism;
            }

            set
            {
                _IsMagnetism = value;
            }
        }


        #endregion
    }
}
