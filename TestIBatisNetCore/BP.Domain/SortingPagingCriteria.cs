using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Domain
{
    public class SortingPagingCriteria
    {
        //
        // 摘要:
        //     获取或设置开始行位置。从1开始。
        public int StartRowNumber
        {
            get;
            set;
        }

        //
        // 摘要:
        //     获取或设置结束行位置。从1开始。
        public int EndRowNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置排序字句。字句格式：字段名 [asc|desc],字段名 [asc|desc],……
        /// </summary>
        public string OrderByClause
        { get; set; }

        /// <summary>
        /// 每页数据数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 这是个匹配接口。
        /// </summary>
        /// <param name="pageIndex">从0开始的页索引。</param>
        /// <param name="pageSize">每页记录数。</param>
        /// <param name="sortField">排序字段。默认为 null。</param>
        /// <param name="sortOrder">排序方式。asc:升序排序，desc:降序排序。默认为 asc。</param>
        public void InitFrom(int pageIndex, int pageSize, string sortField = null, string sortOrder = null)
        {
            // >=
            this.StartRowNumber = (pageIndex - 1) * pageSize;
            this.PageSize = pageSize;
            if (!string.IsNullOrWhiteSpace(sortField))
            {
                this.OrderByClause = sortField + " " + sortOrder;
            }
        }


    }
}
