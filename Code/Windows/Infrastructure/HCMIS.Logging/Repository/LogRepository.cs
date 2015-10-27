using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Logging.Models;

namespace HCMIS.Logging.Repository
{
    public class LogRepository:GenericRepository<LoggingContext,Log>
    {
        /// <summary>
        /// Gets a list of all Logs of type TType
        /// </summary>
        /// <typeparam name="TType">Type of log</typeparam>
        /// <returns>A list of all logs of a given type</returns>
        public IQueryable<TType> FindByType<TType>() where TType : Log
        {
            var query = Context.Logs.OfType<TType>();
            return query;
        }

        /// <summary>
        /// Gets a list of a specific type of Log that satisfy the supplied lambda expression
        /// </summary>
        /// <typeparam name="TType">ActivityLog, ErrorLog, ProfileLog, SessionLog</typeparam>
        /// <param name="predicate">Lambda expression</param>
        /// <returns></returns>
        public IQueryable<TType> FindByType<TType>(System.Linq.Expressions.Expression<Func<TType, bool>> predicate) where TType : Log
        {
            var query = Context.Logs.OfType<TType>().Where(predicate);
            return query;
        }
    }
}
