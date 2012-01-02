using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Enum;
using DropDownListItem = System.Web.UI.WebControls.ListItem;

namespace ClimbFind.Web.UI.Controls.DropDownLists
{
    public class OutdoorClimbingTypeDDL : AbstractDDL
    {
        public CragType InitialValue { get; set; }

        public CragType SelectedType
        {
            get { return (CragType)int.Parse(SelectedItem.Value); }
        }

        protected override void OnInit(EventArgs e)
        {
            if (InitialValue == default(CragType)) { Bind(); }
            else { Bind(InitialValue); }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            Items.Clear();

            List<string> orderedTypes = (from c in System.Enum.GetNames(typeof(CragType)) orderby c select c).ToList();

            foreach (string n in orderedTypes)
            {
                int countryID = ((int)((CragType)System.Enum.Parse(typeof(CragType), n, true)));
                DropDownListItem item = new DropDownListItem(n.ToString(), countryID.ToString());
                Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationality"></param>
        public void Bind(CragType type)
        {
            Items.Clear();

            List<string> orderedTypes = (from c in System.Enum.GetNames(typeof(CragType)) orderby c select c).ToList();

            foreach (string n in orderedTypes)
            {
                int countryID = ((int)((CragType)System.Enum.Parse(typeof(CragType), n, true)));
                DropDownListItem item = new DropDownListItem(n.ToString(), countryID.ToString());
                if ((int)type == countryID) { item.Selected = true; }
                Items.Add(item);
            }
        }
    }
}
