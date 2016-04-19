using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WAFF.DataAccess.Extensions
{
    internal static class DbContextExtensions
    {
        private static readonly MethodInfo TranslateMethod;
        private static readonly MethodInfo ListResultMethod;
        private static Dictionary<Type, List<PropertyInfo>> ResultSetPropertyCache;
        private static Dictionary<Type, MethodInfo> TranslateMethodCache;
        private static Dictionary<Type, MethodInfo> ListResultMethodCache;

        static DbContextExtensions()
        {
            ResultSetPropertyCache = new Dictionary<Type, List<PropertyInfo>>();
            TranslateMethodCache = new Dictionary<Type, MethodInfo>();
            ListResultMethodCache = new Dictionary<Type, MethodInfo>();

            TranslateMethod = typeof(ObjectContext).GetMethod("Translate", new[] { typeof(DbDataReader) });
        }

        public static ObjectResult<TElement> Translate<TElement>(this DbContext dbContext, DbDataReader reader)
        {
            return ((IObjectContextAdapter)dbContext).ObjectContext.Translate<TElement>(reader);
        }

        public static ObjectResult<TEntity> Translate<TEntity>(this DbContext dbContext, DbDataReader reader, string entitySetName, MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)dbContext).ObjectContext.Translate<TEntity>(reader, entitySetName, mergeOption);
        }

        public static async Task<TResult> ExecuteStoredProcedureScalarAsync<TResult>(this DbContext dbContext, string procedureName, params SqlParameter[] parameters)
        {
            var connection = dbContext.Database.Connection;

            var initialConnectionState = connection.State;

            if (initialConnectionState != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;
                cmd.Parameters.AddRange(parameters);

                if (dbContext.Database.CurrentTransaction != null)
                {
                    cmd.Transaction = dbContext.Database.CurrentTransaction.UnderlyingTransaction;
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    return dbContext.Translate<TResult>(reader).FirstOrDefault();
                }
            }
            finally
            {
                if (initialConnectionState == ConnectionState.Closed && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static IList<TResult> ExecuteStoredProcedure<TResult>(this DbContext dbContext, string procedureName, params SqlParameter[] parameters)
        {
            var connection = dbContext.Database.Connection;

            var initialConnectionState = connection.State;

            if (initialConnectionState != ConnectionState.Open)
            {
                connection.Open();
            }

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;
                cmd.Parameters.AddRange(parameters);

                if (dbContext.Database.CurrentTransaction != null)
                {
                    cmd.Transaction = dbContext.Database.CurrentTransaction.UnderlyingTransaction;
                }

#if DEBUG
                var sw = Stopwatch.StartNew();
#endif

                List<TResult> results = null;

                using (var reader = cmd.ExecuteReader())
                {
                    results = dbContext.Translate<TResult>(reader).ToList();
                }

#if DEBUG
                sw.Stop();
                var msg = string.Format("Executed stored procedure '{0}' with SqlDataReader in {1} milliseconds.", procedureName, sw.ElapsedMilliseconds);

                if (dbContext.Database.Log != null)
                {
                    dbContext.Database.Log(msg);
                }
#endif

                return results;
            }
            finally
            {
                if (initialConnectionState == ConnectionState.Closed && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static Task<IList<TResult>> ExecuteStoredProcedureAsync<TResult>(this DbContext dbContext, string procedureName, IEnumerable<SqlParameter> parameters)
        {
            return ExecuteStoredProcedureAsync<TResult>(dbContext, procedureName, parameters.ToArray());
        }

        public static async Task<IList<TResult>> ExecuteStoredProcedureAsync<TResult>(this DbContext dbContext, string procedureName, params SqlParameter[] parameters)
        {
            var connection = dbContext.Database.Connection;

            var initialConnectionState = connection.State;

            if (initialConnectionState != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;
                cmd.Parameters.AddRange(parameters);

                if (dbContext.Database.CurrentTransaction != null)
                {
                    cmd.Transaction = dbContext.Database.CurrentTransaction.UnderlyingTransaction;
                }

#if DEBUG
                var sw = Stopwatch.StartNew();
#endif

                List<TResult> results = null;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    results = dbContext.Translate<TResult>(reader).ToList();
                }

#if DEBUG
                sw.Stop();
                var msg = string.Format("Executed stored procedure '{0}' with SqlDataReader in {1} milliseconds.", procedureName, sw.ElapsedMilliseconds);

                if (dbContext.Database.Log != null)
                {
                    dbContext.Database.Log(msg);
                }
#endif

                return results;
            }
            finally
            {
                if (initialConnectionState == ConnectionState.Closed && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        //public static Task<TResult> ExecuteStoredProcedureWithMultipleResultsAsync<TResult>(this DbContext dbContext, string procedureName, IEnumerable<SqlParameter> parameters)
        //    where TResult : IHaveMultipleResultSets, new()
        //{
        //    var parameterArray = parameters as SqlParameter[] ?? parameters.ToArray();

        //    return ExecuteStoredProcedureWithMultipleResultsAsync<TResult>(dbContext, procedureName, parameterArray);
        //}

        //public static async Task<TResult> ExecuteStoredProcedureWithMultipleResultsAsync<TResult>(this DbContext dbContext, string procedureName, params SqlParameter[] parameters)
        //    where TResult : IHaveMultipleResultSets, new()
        //{
        //    var type = typeof(TResult);

        //    type.CacheResultSetPropertiesIfNeeded();

        //    var props = ResultSetPropertyCache[type];

        //    var connection = dbContext.Database.Connection;

        //    var initialConnectionState = connection.State;

        //    try
        //    {
        //        if (initialConnectionState != ConnectionState.Open)
        //        {
        //            await connection.OpenAsync();
        //        }

        //        var cmd = connection.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = procedureName;
        //        cmd.Parameters.AddRange(parameters);

        //        if (dbContext.Database.CurrentTransaction != null)
        //        {
        //            cmd.Transaction = dbContext.Database.CurrentTransaction.UnderlyingTransaction;
        //        }

        //        using (var reader = await cmd.ExecuteReaderAsync())
        //        {
        //            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

        //            var result = new TResult();

        //            var remaining = props.Count;

        //            foreach (var prop in props)
        //            {
        //                var t = prop.PropertyType;
        //                var isList = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>);

        //                object propResult = null;

        //                if (isList)
        //                {
        //                    var innerType = t.GetGenericArguments()[0];
        //                    innerType.CacheListResultMethodIfNeeded();
        //                    var method = ListResultMethodCache[innerType];
        //                    propResult = method.Invoke(null, new object[] { reader, objectContext });
        //                }
        //                else
        //                {
        //                    t.CacheTranslateMethodIfNeeded();
        //                    var translate = TranslateMethodCache[t];
        //                    propResult = (translate.Invoke(objectContext, new[] { reader }) as IEnumerable<object>).SingleOrDefault();
        //                }

        //                prop.SetValue(result, propResult);

        //                if (--remaining > 0)
        //                    await reader.NextResultAsync();
        //            }

        //            return result;
        //        }
        //    }
        //    finally
        //    {
        //        if (initialConnectionState == ConnectionState.Closed && connection.State != ConnectionState.Closed)
        //        {
        //            connection.Close();
        //        }
        //    }
        //}

        //private static void CacheResultSetPropertiesIfNeeded(this Type type)
        //{
        //    if (ResultSetPropertyCache.ContainsKey(type))
        //        return;

        //    var props = (from p in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
        //                 where Attribute.IsDefined(p, typeof(ResultSetAttribute))
        //                 let attr = p.GetCustomAttribute<ResultSetAttribute>()
        //                 orderby attr.Order
        //                 select p).ToList();

        //    ResultSetPropertyCache[type] = props;
        //}

        //private static void CacheTranslateMethodIfNeeded(this Type type)
        //{
        //    if (TranslateMethodCache.ContainsKey(type))
        //        return;

        //    var genericMethod = TranslateMethod.MakeGenericMethod(new[] { type });

        //    TranslateMethodCache[type] = genericMethod;
        //}

        //private static void CacheListResultMethodIfNeeded(this Type type)
        //{
        //    if (ListResultMethodCache.ContainsKey(type))
        //        return;

        //    var genericMethod = ListResultMethod.MakeGenericMethod(new[] { type });

        //    ListResultMethodCache[type] = genericMethod;
        //}

        //private static IList<TResult> GetListResultFromObjectContext<TResult>(DbDataReader reader, ObjectContext context)
        //{
        //    var type = typeof(TResult);

        //    CacheTranslateMethodIfNeeded(type);
        //    var translate = TranslateMethodCache[type];

        //    var resultSet = translate.Invoke(context, new[] { reader }) as IEnumerable<TResult>;

        //    return resultSet.ToList();
        //}
    }
}
