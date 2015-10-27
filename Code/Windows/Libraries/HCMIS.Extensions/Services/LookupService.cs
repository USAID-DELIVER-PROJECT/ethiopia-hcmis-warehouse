using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HCMIS.Extensions.Binding;
using HCMIS.Extensions.Enums;
using HCMIS.Extensions.Enums.Attributes;
using CodeColumnAttribute = HCMIS.Extensions.Enums.Attributes.CodeColumnAttribute;
using TableCodeAttribute = HCMIS.Extensions.Enums.Attributes.TableCodeAttribute;

namespace HCMIS.Extensions.Services
{
    public sealed class LookupService<TType> : ILookupService<TType>
        where TType : class
    {
        #region Fields
        private readonly IQueryable<TType> _dbSet;
        private readonly BindingManager _bindingManager;

        #endregion

        #region Constructors

        public LookupService(IQueryable<TType> dbSet, BindingManager bindingManager)
        {
            _dbSet = dbSet;
            _bindingManager = bindingManager;
        }

        #endregion

        #region ILookupService Implementation

        public TType Get(IConvertible value)
        {
            // Assert that 'value' is an enum type bound to TType
            if (value.GetType().FullName != _bindingManager.Get<TType>().FullName)
            {
                throw new Exception("Invalid parameter");
            }

            string columnCode = GetColumnCode(value.GetType());
            string tableCode = GetTableCode(value);
            return Query(columnCode, tableCode);
        }

        #endregion

        #region Private Helpers
        
        private TType Query(string columnCode, string tableCode)
        {
            //Since a lambda expression with reflection can't be pass as it is we need to use a expression tree
            //otherwise this generates an error
            //var entity = _dbSet.SingleOrDefault(m => m.GetType().GetProperty(columnCode).GetValue(m, null).Equals(tableCode));
            var param = Expression.Parameter(typeof(TType));
            // create expression for param => param.TEntityNameId == PrimaryKey
            var lambda = Expression.Lambda<Func<TType, bool>>(
                Expression.Equal(Expression.Property(param, columnCode),Expression.Constant(tableCode)),param);
            return _dbSet.SingleOrDefault(lambda);
        }

        private static string GetTableCode(IConvertible value)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(TableCodeAttribute),false);
            var description = ((TableCodeAttribute)attributes[0]).TableCode;
            return description;
        }

        private static string GetColumnCode(Type type)
        {
            var attribute = (CodeColumnAttribute)Attribute.GetCustomAttribute(type, typeof(CodeColumnAttribute));
            if (attribute != null)
                return attribute.CodeColumn;
            return (typeof (TType).Name + "Code");
        }

        #endregion


    }
}
