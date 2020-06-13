using System; 
using System.Collections.Generic; 
using System.Text;
using UnityEngine;

public class EvaluateString 
{
    public static double Evaluate(string expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        table.Columns.Add("expression", string.Empty.GetType(), expression);
        System.Data.DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }
} 
  