using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Business
{

    //
    // 摘要:
    //     代表业务层操作上下文。
    public class BusinessRuleContext
    {
        //
        // 摘要:
        //     当前操作的用户。
        private readonly string _operatingUser;

        //
        // 摘要:
        //     获取当前操作的用户。
        public virtual string OperatingUser => _operatingUser;

        //
        // 摘要:
        //     获取当前的操作时间。
        public virtual DateTime OperatingTime => DateTime.Now;

        //
        // 摘要:
        //     使用指定设置来初始化 IsFrame.BP.Business.BusinessRuleContext 类实例。
        //
        // 参数:
        //   operatingUser:
        //     当前操作的用户。
        public BusinessRuleContext(string operatingUser)
        {
          //  Guard.ArgumentNotNull(operatingUser, "operatingUser", (string)null);
            _operatingUser = operatingUser;
        }
    }
}
