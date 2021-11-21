using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP.Persistence;
using System.Reflection;

namespace BP.Business
{

    //
    // 摘要:
    //     业务层基类。
    public abstract class BusinessRule
    {
        //
        // 摘要:
        //     DAO管理器同步对象。
        private static readonly object DaoManagerLock = new object();

        //
        // 摘要:
        //     DAO管理器。
        private static ISqlMapper _daoManager;

        //
        // 摘要:
        //     操作上下文。
        private readonly BusinessRuleContext _context;


        private static IDictionary<Type, IDao> _daoInterface = null;
        //
        // 摘要:
        //     获取DAO管理器。
        protected static ISqlMapper DaoManager
        {
            get
            {
                //IL_007e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0088: Expected O, but got Unknown
                if (_daoManager == null)
                {
                    lock (DaoManagerLock)
                    {
                        if (_daoManager == null)
                        {
                            _daoManager = Mapper.Instance();//
                            LaodDao();
                        }
                    }
                }

                return _daoManager;
            }
        }

        private static void LaodDao()
        {
            if (_daoInterface == null)
            {

                //查找 Interfaces 下的所有IDao 的Interface
                //找到 IDao 对应的 实现
                //添实现加到 字典
                _daoInterface = new Dictionary<Type, IDao>();

                var aType = typeof(IDao);
                var assembly = Assembly.GetEntryAssembly();
                var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assemblyName in assemblies.Where(s => s.FullName.IndexOf(".Persistence") > -1))
                {
                    foreach (var ti in assemblyName.DefinedTypes)
                    {
                        if (ti.GetInterfaces().Contains(typeof(IDao)) && ti.BaseType == typeof(BaseDao))
                        {
                            var dao = (IDao)assemblyName.CreateInstance(ti.FullName);//创建实体
                            var iDao = ti.GetInterfaces().Where(s => s.FullName.IndexOf(".Persistence.Interfaces.") >= 0).ToList().FirstOrDefault();//获得实体对应的接口
                            _daoInterface.Add(iDao, dao);//加入字典
                        }
                    }
                }

            }
        }

        //
        // 摘要:
        //     获取当前操作上下文。
        protected virtual BusinessRuleContext Context => _context;

        //
        // 摘要:
        //     使用指定设置来初始化 IsFrame.BP.Business.BusinessRule 类实例。
        //
        // 参数:
        //   context:
        //     操作上下文。不可为空。
        protected BusinessRule(BusinessRuleContext context)
        {
            // Guard.ArgumentNotNull((object)context, "context", (string)null);
            _context = context;
        }

        //
        // 摘要:
        //     重置DAO管理器。
        //
        // 参数:
        //   obj:
        private static void ResetDaoManager(object obj)
        {
            lock (DaoManagerLock)
            {
                _daoManager = null;
            }
        }

        //
        // 摘要:
        //     获得指定类型的DAO对象。
        //
        // 参数:
        //   daoInterface:
        //     DAO接口类型。
        //
        // 返回结果:
        //     指定类型的DAO对象。
        protected static IDao GetDao(Type daoInterface)
        {
            LaodDao();
            // return DaoManager.GetDao(daoInterface);
            return _daoInterface[daoInterface];
        }

        //
        // 摘要:
        //     获得指定类型的DAO对象。
        //
        // 类型参数:
        //   T:
        //     DAO接口类型。
        //
        // 返回结果:
        //     指定类型的DAO对象。
        protected static T GetDao<T>()
        {

            LaodDao();
            //return (T)DaoManager.GetDao(typeof(T));
            return (T)_daoInterface[typeof(T)];
        }

        //
        // 摘要:
        //     打开一个连接。
        //
        // 返回结果:
        //     打开的连接。
        protected virtual ISqlMapSession OpenConnection()
        {
            return DaoManager.OpenConnection();
        }

        //
        // 摘要:
        //     关闭打开的连接。
        protected virtual void CloseConnection()
        {
            DaoManager.CloseConnection();
        }

        //
        // 摘要:
        //     开始一个事务。
        //
        // 返回结果:
        //     开启的事务。
        protected virtual ISqlMapSession BeginTransaction()
        {
            return DaoManager.BeginTransaction();
        }

        //
        // 摘要:
        //     开始一个事务。
        //
        // 参数:
        //   isolationLevel:
        //     事务的隔离级别。
        //
        // 返回结果:
        //     开启的事务。
        protected virtual ISqlMapSession BeginTransaction(IsolationLevel isolationLevel)
        {
            return DaoManager.BeginTransaction(isolationLevel);
        }

        //
        // 摘要:
        //     提交一个事务。
        //
        // 言论：
        //     提交事务成功后将自动关闭连接。
        protected virtual void CommitTransaction()
        {
            DaoManager.CommitTransaction();
        }

        //
        // 摘要:
        //     回滚一个事务。
        //
        // 言论：
        //     回滚事务成功后将自动关闭连接。
        protected virtual void RollBackTransaction()
        {
            DaoManager.RollBackTransaction();
        }
    }
}
