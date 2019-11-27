using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rkna_Project
{
    class FromListToDataTable
    {

        static DataTable ConvertListToDataTable(List<string[]> list)
        {
            DataTable table = new DataTable();

            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

    }
}
