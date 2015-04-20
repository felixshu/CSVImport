using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Domian.CSVManager.Abstract;
using Domian.CSVManager.Model;

namespace Domian.CSVManager
{
    public class CsvReader : ICsvReader
    {
        #region Constructor

        public CsvReader(string filePath,List<CsvFieldTarget> csvFieldTargets,  bool skipTheFirstColumn, char seperator)
        {
            CsvFieldTargets = csvFieldTargets;
            SkipTheFirstColumn = skipTheFirstColumn;
            Seperator = seperator;
            FilePath = filePath;
        }

        #endregion
        #region Methods
        public List<CsvRow> ReadCsvRows()
        {
            CsvRows = SkipTheFirstColumn ? GetRowsIterator().Skip(1).ToList() : GetRowsIterator().ToList();
            return CsvRows;
        }

        public IEnumerable<CsvRow> GetRowsIterator()
        {
            using (var readFile = new StreamReader(FilePath))
            {
                string line;

                while ((line = readFile.ReadLine())!= null)
                {
                    var row = line.Split(Seperator);
                    var result = CreateNewRow(row);
                    yield return result;
                }
            }
        }

        public CsvRow CreateNewRow(string[] row)
        {
            var result = new CsvRow(CsvFieldTargets.Count);
            foreach (var target in CsvFieldTargets)
            {
                var field = new CsvFieldResult()
                {
                    FieldName = target.FieldName,
                    Position = target.Position,
                    FieldValue = row[target.Position]
                };
                result.CsvFieldsResult.Add(field);
            }
            return result;
        }
        #endregion

        #region Properties

        public List<CsvFieldTarget> CsvFieldTargets { get; private set; }

        public List<CsvRow> CsvRows { get; private set; }

        public char Seperator { get; private set; }

        public bool SkipTheFirstColumn { get; private set; }

        public string FilePath { get; private set; }

        #endregion
    }
}