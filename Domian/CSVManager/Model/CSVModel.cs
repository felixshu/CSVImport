using System.Collections.Generic;

namespace Domian.CSVManager.Model
{

    public class CsvRow
    {
        public CsvRow(int numberOfColumns)
        {
            CsvFieldsResult = new List<CsvFieldResult>(numberOfColumns);
        }

        public CsvRow()
        {
            CsvFieldsResult = new List<CsvFieldResult>();
        }

        public List<CsvFieldResult> CsvFieldsResult { get; set; }
    }

    public class CsvFieldTarget
    {
        public string FieldName { get; set; }
        public int Position { get; set; }
    }

    public class CsvFieldResult : CsvFieldTarget
    {
        public object FieldValue { get; set; }
    }

}