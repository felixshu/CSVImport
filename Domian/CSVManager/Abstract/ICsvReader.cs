using System;
using System.Collections.Generic;
using Domian.CSVManager.Model;

namespace Domian.CSVManager.Abstract
{
    public interface ICsvReader
    {
        List<CsvFieldTarget> CsvFieldTargets { get;  }
        List<CsvRow> CsvRows { get;  }
        Char Seperator { get;  }
        bool SkipTheFirstColumn { get; }
        string FilePath { get; }

        List<CsvRow> ReadCsvRows();
        IEnumerable<CsvRow> GetRowsIterator();
        CsvRow CreateNewRow(string[] row);
    }
}