using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MmorpgCreatorMain;

namespace MmorpgCreatorMain
{
    public class Account
    {
        private Player _Character;

        private String _AccountName = String.Empty;


        #region Player

        public Player Character
        {
            get
            {
                return _Character;
            }

            set
            {
                _Character = value;
            }
        }

        public String  AccountName
        {
            get
            {
                return _AccountName;
            }

            set
            {
                _AccountName = value;
            }
        }


        #endregion


    }
}
