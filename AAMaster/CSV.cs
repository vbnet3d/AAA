using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

/// <summary>
/// Provides an RFC-4180 compatible CSV import and export function to and from a DataTable
/// and lists of POCOs per specifications found at https://tools.ietf.org/rfc/rfc4180.txt
/// </summary>
public static class CSV
{
    /// <summary>
    /// Export a generic list of objects to CSV
    /// </summary>
    /// <typeparam name="T">Type of object being exported</typeparam>
    /// <param name="pocos">List of objects of type T</param>
    /// <param name="filename">Name of text file to save.</param>
    /// <param name="delimiter">[OPTIONAL]: The character that separates fields (usually comma or tab in U.S.)</param>
    /// <param name="firstlineheader">[OPTIONAL]: Is the first line of the CSV file a header?</param>
    /// <param name="quotechar">[OPTIONAL]: Which character marks the beginning and end of text blocks?</param>
    public static void Export<T>(IEnumerable<T> list, string filename, char delimiter, bool firstlineheader, char quotechar, bool QuoteAllFields)
    {
        using (DataTable dt = new DataTable())
        {

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in properties)
            {
                dt.Columns.Add(prop.Name);
            }

            foreach (T item in list)
            {
                List<object> values = new List<object>();

                foreach (PropertyInfo prop in properties)
                {
                    values.Add(prop.GetValue(item, null));
                }

                dt.Rows.Add(values.ToArray());
            }

            Export(dt, filename, delimiter, firstlineheader, quotechar, QuoteAllFields);
        }
    }

    public static void Export<T>(IEnumerable<T> list, string filename)
    {
        Export(list, filename, ',', true, '"', false);
    }

    /// <summary>
    /// Import a list of objects from a CSV file
    /// </summary>
    /// <typeparam name="T">Type of object being imported</typeparam>
    /// <param name="filename">Name of text file to save.</param>
    /// <param name="delimiter">[OPTIONAL]: The character that separates fields (usually comma or tab in U.S.)</param>
    /// <param name="firstlineheader">[OPTIONAL]: Is the first line of the CSV file a header?</param>
    /// <param name="quotechar">[OPTIONAL]: Which character marks the beginning and end of text blocks?</param>
    /// <returns>List of objects</T></I></returns>
    public static List<T> Import<T>(string filename, char delimiter, bool firstlineheader, char quotechar) where T : new()
    {
        // Load the CSV using the main import() function. 
        // Why duplicate the same code in multiple locations
        // when we can just copy the data in-memory?
        DataTable dt = Import(filename, delimiter, firstlineheader, quotechar);
        List<T> pocos = new List<T>();

        foreach (DataRow r in dt.Rows)
        {
            T item = new T();

            foreach (DataColumn c in dt.Columns)
            {
                PropertyInfo pi = item.GetType().GetProperty(c.ColumnName);
                if (pi != null && r[c.ColumnName].ToString() != "")
                {
                    pi.SetValue(item, r[c.ColumnName], BindingFlags.Default, null, null, null);
                }
            }

            pocos.Add(item);
        }

        return pocos;
    }

    public static List<T> Import<T>(string filename) where T : new()
    {
        return Import<T>(filename, ',', true, '"');
    }

 

    public static void Export(DataTable dt, string filename)
    {
        Export(dt, filename, ',', true, '"', false);
    }


    /// <summary>
    /// Exports a Comma Delimited Text (CSV) File.
    /// </summary>
    /// <param name="dt">Data to export.</param>
    /// <param name="filename">Name of text file to save.</param>
    /// <param name="delimiter">[OPTIONAL]: The character that separates fields (usually comma or tab in U.S.)</param>
    /// <param name="firstlineheader">[OPTIONAL]: Is the first line of the CSV file a header?</param>
    /// <param name="quotechar">[OPTIONAL]: Which character marks the beginning and end of text blocks?</param>
    public static void Export(DataTable dt, string filename, char delimiter, bool firstlineheader, char quotechar, bool QuoteAllFields)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            StringBuilder line = new StringBuilder();

            if (firstlineheader)
            {
                // Insert the file header using the DataTable's column names
                foreach (DataColumn c in dt.Columns)
                {
                    line.AppendFormat("{0}{1}", c.ColumnName, delimiter);
                }

                // Remove the final trailing comma.
                line.Remove(line.Length - 1, 1);

                sw.WriteLine(line.ToString());
            }

            foreach (DataRow r in dt.Rows)
            {
                line.Length = 0;

                foreach (object i in r.ItemArray)
                {
                    // We need to make each item into a valid CSV field string. 
                    // To do this, we first need to make a ToString() conversion:
                    string value = i.ToString();

                    string textDelimiter = string.Empty;
                    if (!QuoteAllFields)
                    {
                        // By default, we do NOT want a field enclosed in quotes, because
                        // it increases files sizes and may make numeric fields appear to
                        // be text. Instead, we check to see if we need to enclose the fields.
                        // If so, we set the text delimiter to the 'quotechar' value and double
                        // all double-quote characters per https://tools.ietf.org/html/rfc4180#page-2                               
                        if (value.Contains(delimiter) || value.Contains(Environment.NewLine))
                        {
                            textDelimiter = quotechar.ToString();
                            value = value.Replace("\"", "\"\"");
                        }
                    }
                    else
                    {
                        textDelimiter = quotechar.ToString();
                        value = value.Replace("\"", "\"\"");
                    }


                    // Sample line: 1,"This is a quoted field, because of the comma",this is not quoted
                    line.AppendFormat("{0}{1}{0}{2}", textDelimiter, value, delimiter);
                }

                line.Remove(line.Length - 1, 1);

                sw.WriteLine(line.ToString());
            }
        }
    }

    public static DataTable Import(string filename)
    {
        return Import(filename, ',', true, '"');
    }

    /// <summary>
    /// Imports a Comma Delimited Text (CSV) File into a DataTable object.
    /// </summary>
    /// <param name="filename">The CSV text file</param>
    /// <param name="delimiter">[OPTIONAL]: The character that separates fields (usually comma or tab in U.S.)</param>
    /// <param name="firstlineheader">[OPTIONAL]: Is the first line of the CSV file a header?</param>
    /// <param name="quotechar">[OPTIONAL]: Which character marks the beginning and end of text blocks?</param>
    /// <returns>A DataTable object</returns>
    public static DataTable Import(string filename, char delimiter, bool firstlineheader, char quotechar)
    {
        DataTable dt = new DataTable();

        using (StreamReader sr = new StreamReader(filename))
        {

            List<string> items = new List<string>();    // Represents a full row of data from the CSV file.
            StringBuilder item = new StringBuilder();   // Represents the current item that is being parsed.
            bool inQuote = false;                       // Are we inside or outside of a text block?
            int rowNum = 1;                             // Current actual row # in the CSV file.

            try
            {

                while (sr.Peek() != -1)
                {
                    string line = sr.ReadLine();

                    // Check to see if we hit the end of the line without finishing a record (i.e. Inside a text block)
                    if (!inQuote && items.Any())
                    {
                        // Transfer the current item to the list of items.
                        if (item[0] == '"' && item[item.Length - 1] == '"')
                        {
                            item.Remove(0, 1);
                            item.Remove(item.Length - 1, 1);
                        }
                        items.Add(item.ToString());
                        item.Length = 0;

                        // No - the record is complete. We should write data.
                        if (rowNum == 1 && firstlineheader)
                        {
                            foreach (string column in items)
                            {
                                dt.Columns.Add(column);
                            }
                        }
                        else
                        {
                            dt.Rows.Add(items.ToArray());
                        }


                        rowNum++;
                        items.Clear();
                        item.Length = 0;
                    }
                    else
                    {
                        // The text block continued on another line....
                        if (item.Length > 0)
                        {
                            item.AppendLine();
                        }
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        // Check to see if we are beginning or ending a text block.
                        if (line[i] == quotechar)
                        {
                            inQuote = !inQuote; // Reverses current true/false state.
                        }

                        // Check to see if we have hit a delimiter character. If so, see if we are within a text block.
                        if (line[i] == delimiter && !inQuote)
                        {
                            // Transfer the current item to the list of items.
                            if (!string.IsNullOrEmpty(item.ToString()) && item[0] == '"' && item[item.Length - 1] == '"')
                            {
                                item.Remove(0, 1);
                                item.Remove(item.Length - 1, 1);
                            }
                            items.Add(item.ToString().Replace("\"\"", "\""));
                            item.Length = 0;
                        }
                        else
                        {
                            // Normal character - add to the current item.
                            item.Append(line[i]);
                        }
                    }
                }

                // Check to see if we hit the end of the line without finishing a record (i.e. Inside a text block)
                if (!inQuote && items.Any())
                {
                    // Transfer the current item to the list of items.
                    if (item[0] == '"' && item[item.Length - 1] == '"')
                    {
                        item.Remove(0, 1);
                        item.Remove(item.Length - 1, 1);
                    }
                    items.Add(item.ToString());
                    item.Length = 0;

                    // No - the record is complete. We should write data.
                    if (rowNum == 1 && firstlineheader)
                    {
                        foreach (string column in items)
                        {
                            dt.Columns.Add(column);
                        }
                    }
                    else
                    {
                        dt.Rows.Add(items.ToArray());
                    }


                    rowNum++;
                    items.Clear();
                    item.Length = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} at line {1} in {2}", ex.Message, rowNum, filename), ex);
            }
        }

        return dt;
    }
}

