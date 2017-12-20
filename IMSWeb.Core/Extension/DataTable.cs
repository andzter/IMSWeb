using System.IO;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace System.Data
{
    public static class DataTableExtension
    {
        #region Public Static Methods

        public static string TransformXslt(this DataTable source, string xslt)
        {
            var records = new XElement("Records");

            // Scroll through rows
            foreach (DataRow row in source.Rows)
            {
                var record = new XElement("Record");

                // Scroll through columns
                foreach (DataColumn column in source.Columns)
                {
                    var value = row[column];

                    record.Add(new XElement("Item",
                        new XElement("Name", column.ColumnName),
                        new XElement("Value", value)
                    ));
                }

                records.Add(record);
            }

            var transform = new XslCompiledTransform();

            transform.Load(xslt);

            using (MemoryStream stream = new MemoryStream())
            {
                transform.Transform(records.CreateReader(), null, stream);

                stream.Seek(0, SeekOrigin.Begin);

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        public static string ToCSV(this DataTable source)
        {
            return "";
        }

        
       

        #endregion  // Public Static Methods
    }
}
