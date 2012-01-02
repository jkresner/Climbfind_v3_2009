using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Enum;
using DropDownListItem = System.Web.UI.WebControls.ListItem;
using ClimbFind.Content;

namespace ClimbFind.Web.UI.Controls.DropDownLists
{
    public class NationalityDDL : AbstractDDL
    {
        public Nation InitialValue { get; set; }

        public Nation SelectedNation
        {
            get { return (Nation)int.Parse(SelectedItem.Value); }
        }

        private bool _AllowUK = true;
        public bool AllowUK { get { return _AllowUK; } set { _AllowUK = value; } }

        protected override void OnInit(EventArgs e)
        {
            if (InitialValue == default(Nation)) { Bind(); }
            else { Bind(InitialValue); }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            Items.Clear();

            List<string> orderedCountries = (from c in System.Enum.GetNames(typeof(Nation)) orderby c select c).ToList();

            foreach (string n in orderedCountries)
            {
                byte countryID = ((byte)((Nation)System.Enum.Parse(typeof(Nation), n, true)));

                if (AllowUK)
                {
                    DropDownListItem item = new DropDownListItem(FlagList.GetCountryName((Nation)countryID), countryID.ToString());
                    Items.Add(item);
                }
                else if (countryID != (short)Nation.UnitedKingdom)
                {
                    DropDownListItem item = new DropDownListItem(FlagList.GetCountryName((Nation)countryID), countryID.ToString());
                    Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationality"></param>
        public void Bind(Nation nationality)
        {
            Items.Clear();

            List<string> orderedCountries = (from c in System.Enum.GetNames(typeof(Nation)) orderby c select c).ToList();

            foreach (string n in orderedCountries)
            {
                byte countryID = ((byte)((Nation)System.Enum.Parse(typeof(Nation), n, true)));
                DropDownListItem item = new DropDownListItem(n.ToString(), countryID.ToString());
                if ((byte)nationality == countryID) { item.Selected = true; }
                Items.Add(item);
            }
        }
    }
}
