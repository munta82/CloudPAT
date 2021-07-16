using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Core
{
    public static class CommonExtensions
    {
        public static List<T> CreateListFromTable<T>(DataTable tbl) where T : new()
        {
            // define return list
            List<T> lst = new List<T>();

            // go through each row
            foreach (DataRow r in tbl.Rows)
            {
                // add to the list
                lst.Add(CreateItemFromRow<T>(r));
            }

            // return the list
            return lst;
        }
        // function that creates an object from the given data row
        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            // create a new object
            T item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }
        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {
                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);

                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, row[c], null);
                }
            }
        }

        public static SelectList ToSelectList(DataTable table, string valueField, string textField, string selectText = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                if (selectText == row[textField].ToString())
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[textField].ToString(),
                        Value = row[valueField].ToString(),
                        Selected = true
                    });
                }
                else
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[textField].ToString(),
                        Value = row[valueField].ToString()
                    });
                }
            }
            if (selectText != "")
                return new SelectList(list, "Value", "Text", selectText);
            else
                return new SelectList(list, "Value", "Text");
        }



    }
}
