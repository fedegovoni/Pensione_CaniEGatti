using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pensione_CaniEGatti.Gestione
{
    class SortWrapper
    {
        internal ListViewItem sortItem;
        internal int sortColumn;


        // A SortWrapper requires the item and the index of the clicked column.
        public SortWrapper(ListViewItem Item, int iColumn)
        {
            sortItem = Item;
            sortColumn = iColumn;
        }

        // Text property for getting the text of an item.
        public string Text
        {
            get
            {
                return sortItem.SubItems[sortColumn].Text;
            }
        }

        // Implementation of the IComparer
        // interface for sorting ArrayList items.
        public class SortComparer : IComparer
        {
             private bool ascending;

            // Constructor requires the sort order;
            // true if ascending, otherwise descending.
            public SortComparer(bool asc)
            {
                this.ascending = asc;
            }

            // Implemnentation of the IComparer:Compare
            // method for comparing two objects.
            public int Compare(object x, object y)
            {

                SortWrapper xItem = (SortWrapper)x;
                SortWrapper yItem = (SortWrapper)y;

                string xText = xItem.sortItem.SubItems[xItem.sortColumn].Text;
                string yText = yItem.sortItem.SubItems[yItem.sortColumn].Text;

                try
                {
                    DateTime dx = DateTime.Parse(xText);
                    DateTime dy = DateTime.Parse(yText);
                    return dx.CompareTo(dy) * (this.ascending ? 1 : -1);
                }
                catch (FormatException)
                { 
                    return xText.CompareTo(yText) * (this.ascending ? 1 : -1);
                }
            }
        }
    }
}
