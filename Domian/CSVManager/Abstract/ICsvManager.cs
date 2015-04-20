using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domian.CSVManager.Model;

namespace Domian.CSVManager.Abstract
{
    public interface ICsvManager<T> where T: new()
    {
        char DefaultSeparator { get; set; }
        List<CsvFieldTarget> CsvFieldsToMap { get; set; }
        string FilePath { get; }
        ICsvReader Reader { get; set; }
        bool SkipTheFirstColumn { get;  }

        void SetField(Expression<Func<T, string>> expression, int position);


        void SetField(Expression<Func<T, ValueType>> expression, int position);

        void SetField(Expression<Func<T, DateTime>> expression, int position);
        List<T> GetObjectList();
    }
}