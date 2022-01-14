using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Domain
{
    //
    // 摘要:
    //     分页查询结果。
    public sealed class Pagination<T>
    {
        //
        // 摘要:
        //     数据总行数。
        private int _rowTotal;

        //
        // 摘要:
        //     获取数据总行数。
        public int RowTotal
        {
            get
            {
                return _rowTotal;
            }
            set
            {
                _rowTotal = value;
            }
        }

        //
        // 摘要:
        //     获取或设置结果集。
        public IList<T> Results
        {
            get;
            set;
        }
    }
}
