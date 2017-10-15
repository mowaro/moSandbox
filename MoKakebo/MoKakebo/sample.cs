using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoKakebo.Const;
using MoKakebo.Dao;
using MoKakebo.Framework.Model.Interface;
using MoKakebo.Model;

namespace MoKakebo {
    public partial class sample : Form {
        public sample() {
            InitializeComponent();
        }

        private void sample_Load(object sender, EventArgs e) {
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e) {
            this.textBox1.Text = Const.Config.SQLITE_PATH;

            SubaccountCollection collection = Factory.getSubaccountDao().selectAll();
            collection.sort(new SubaccountCollection.LatestUsedDateDescSorter());
            loadLstBase(this.listView1, collection);
        }

        private void loadLstBase<T>(ListView target, IList<T> dataSource) where T : Subaccount{
            target.Columns.Clear();
            target.Columns.Add("ID");
            target.Columns.Add("Name");
            target.Columns.Add("LatestUsed");
            target.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            target.Items.Clear();
            foreach(Subaccount item in dataSource) {
                ListViewItem lvi = target.Items.Add(new ListViewItem() { Text = item.Id.ToString(), Tag = item });
                ListViewItem.ListViewSubItemCollection values = new ListViewItem.ListViewSubItemCollection(lvi);
                values.Add(item.Name);
                values.Add(item.LatestUsed.ToShortDateString());
                if(target.SelectedIndices.Count == 0) { lvi.Selected = true; }
            }

            target.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


    }
}
