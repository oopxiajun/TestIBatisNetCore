﻿using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Persistence
{
    public abstract class BaseDao : IDao
    {
        private static volatile ISqlMapper sqlMapper = null;

        //
        // 摘要:
        //     执行插入语句。
        //
        // 参数:
        //   statementName:
        //     要执行的SQL语句名。
        //
        //   parameterObject:
        //     SQL语句中需要使用的参数值。
        //
        // 返回结果:
        //     新增行生成的主键。
        protected virtual object Insert(string statementName, object parameterObject)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.Insert(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }

        //
        // 摘要:
        //     执行更新语句。
        //
        // 参数:
        //   statementName:
        //     要执行的SQL语句名。
        //
        //   parameterObject:
        //     SQL语句中需要使用的参数值。
        //
        // 返回结果:
        //     影响的行数。
        protected virtual int Update(string statementName, object parameterObject)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.Update(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }

        //
        // 摘要:
        //     执行删除语句。
        //
        // 参数:
        //   statementName:
        //     要执行的SQL语句名。
        //
        //   parameterObject:
        //     SQL语句中需要使用的参数值。
        //
        // 返回结果:
        //     影响的行数。
        protected virtual int Delete(string statementName, object parameterObject)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.Delete(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }

        //
        // 摘要:
        //     查询返回list
        //
        // 参数:
        //   statementName:
        //
        //   parameterObject:
        protected virtual IList<T> QueryList<T>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.QueryForList<T>(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }

        //
        // 摘要:
        //     执行SQL，并返回指定索引的字典。
        //
        // 参数:
        //   statementName:
        //     SQL语句配置名称。
        //
        //   parameterObject:
        //     SQL语句参数。
        //
        //   keyProperty:
        //     用于索引的属性名。
        //
        // 类型参数:
        //   K:
        //     索引主键类型。
        //
        //   V:
        //     数据行类型。
        //
        // 返回结果:
        //     一个包含结果行的字典。
        protected virtual IDictionary<K, V> QueryDictionary<K, V>(string statementName, object parameterObject, string keyProperty)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.QueryForDictionary<K, V>(statementName, parameterObject, keyProperty);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }

        //
        // 摘要:
        //     获取DataMapper实例。
        //
        // 返回结果:
        //     DataMapper实例。
        protected virtual ISqlMapper GetSqlMapper()
        {
            if (sqlMapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (sqlMapper == null)
                    {
                        sqlMapper = Mapper.Instance();
                    }
                }
            }
            //ISqlMapper sqlMap = Mapper.Instance();// (Mapper.Instance().LocalSession as SqlMapSession ?? throw new Exception("获取数据访问会话失败！")).SqlMapper;//(DaoManager.GetInstance(this).LocalDaoSession as SqlMapDaoSession) 
            // sqlMap.SessionStore = new HybridWebThreadSessionStore(sqlMap.Id);
            return sqlMapper;
        }

        //
        // 摘要:
        //     执行SQL语句，并返回一个结果对象。
        //
        // 参数:
        //   statementName:
        //     要执行的SQL语句名。
        //
        //   parameterObject:
        //     SQL语句中需要使用的参数值。
        //
        // 返回结果:
        //     执行结果中的一个对象。
        protected virtual object QueryObject(string statementName, object parameterObject)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.QueryForObject(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }

        //
        // 摘要:
        //     执行SQL语句，并返回一个结果对象。
        //
        // 参数:
        //   statementName:
        //     要执行的SQL语句名。
        //
        //   parameterObject:
        //     SQL语句中需要使用的参数值。
        //
        // 类型参数:
        //   T:
        //     结果对象的类型。
        //
        // 返回结果:
        //     执行结果中的一个对象。
        protected virtual T QueryObject<T>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMapper = GetSqlMapper();
            try
            {
                return sqlMapper.QueryForObject<T>(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"语句：{statementName} 执行失败，失败原因：{ex.Message}", ex);
            }
        }
    }
}
