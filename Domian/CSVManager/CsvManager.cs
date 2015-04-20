using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Domian.CSVManager.Abstract;
using Domian.CSVManager.Model;

namespace Domian.CSVManager
{
    public class CsvManager<T> : ICsvManager<T> where T : new()
    {
        #region Constructor

        public CsvManager(string filePath, bool skipTheFirstColumn, char seperator)
        {
            CsvFieldsToMap = new List<CsvFieldTarget>();
            FilePath = filePath;
            SkipTheFirstColumn = skipTheFirstColumn;
            DefaultSeparator = seperator;
        }

        public CsvManager(string filePath, bool skipTheFirstColumn) : this(filePath, skipTheFirstColumn, ',')
        {
        }

        #endregion

        #region Properties

        public char DefaultSeparator { get; set; }

        public List<CsvFieldTarget> CsvFieldsToMap { get; set; }

        public string FilePath { get; private set; }

        public ICsvReader Reader { get; set; }

        public bool SkipTheFirstColumn { get; private set; }

        #endregion

        #region Methods

        public void SetField(Expression<Func<T, string>> expression, int position)
        {
            GetAndSetFieldTarget(expression, position);
        }

        public void SetField(Expression<Func<T, ValueType>> expression, int position)
        {
            GetAndSetFieldTarget(expression, position);
        }

        public void SetField(Expression<Func<T, DateTime>> expression, int position)
        {
            GetAndSetFieldTarget(expression, position);
        }

        public List<T> GetObjectList()
        {
            Reader = new CsvReader(FilePath, CsvFieldsToMap, SkipTheFirstColumn, DefaultSeparator);
            var csvRows = Reader.ReadCsvRows();
            var result = new List<T>(csvRows.Count);
            result.AddRange(from row in csvRows let destinationObject = new T() select SetPropertyViaReflection(destinationObject, row));
            return result;

        }

        private T SetPropertyViaReflection(T destinationObject, CsvRow row)
        {
            var type = destinationObject.GetType();
            foreach (var fieldResult in row.CsvFieldsResult)
            {
                var propertyInfo = type.GetProperty(fieldResult.FieldName);
                var propertyType = propertyInfo.PropertyType;
                var convertedValue = Convert.ChangeType(fieldResult.FieldName, propertyType);
                propertyInfo.SetValue(destinationObject,convertedValue,null);
            }
            return destinationObject;
        }

        private void GetAndSetFieldTarget(Expression expression, int position)
        {
            var property = GetMemberInfo(expression);
            CsvFieldsToMap.Add(new CsvFieldTarget()
            {
                FieldName = property.Name,
                Position = position
            });
        }

        /// <summary>
        /// Build a MemberInfo of Reflection to read the metadata in the Lambda Expression Tree Informaiton
        /// 
        /// When the CSV file is read into the Lambda Expression Tree, We can read information from the NodeType from the body of expression tree
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Member</returns>
        private static MemberInfo GetMemberInfo(Expression expression)
        {
            var lambda = expression as LambdaExpression;
            if (lambda == null)
            {
                throw new InvalidCastException("Invalid Lambda Expression");
            }

            MemberExpression memberExpression = null;
            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpression = ((UnaryExpression) lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpression = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException("Invalid Expression");
            }
            return memberExpression.Member;
        }

        #endregion
    }
}