using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MmorpgEngine
{
    public partial class CtrlEditList : UserControl
    {
        Delegate _EventEdit;
        Delegate _EventAdd;
        public CtrlEditList()
        {
            InitializeComponent();
        }

        private void CtrlEditList_Load(object sender, EventArgs e)
        {

        }

        public void SendEvent(Delegate E_edit, Delegate E_Add)
        {
            E_edit = _EventEdit;
            E_Add = _EventAdd;
        }

        public void LoadItems(Dictionary<Int32, String> items)
        {

            _listEdit.DataSource = new BindingSource(items, null); 
            _listEdit.DisplayMember = "Value"; 
            _listEdit.ValueMember = "Key";

        }


        public void LoadItems(List<String> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                _listEdit.Items.Insert(i, items[i]);

            }
        }




        public Button btnEdit
        {
            get
            {
                return _btnEdit;
            }

            set
            {
                _btnEdit = value;
            }
        }

        public Button btnAdd
        {
            get
            {
                return _btnAdd;
            }

            set
            {
                _btnAdd = value;
            }
        }


        public ListBox listEdit
        {
            get
            {
                return _listEdit;
            }

            set
            {
                _listEdit = value;
            }
        }
    }
}
