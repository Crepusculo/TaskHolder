using System.Collections.Generic;
using System.Linq;

namespace App1.Utils
{
    public class TypeHelper
    {
        public string[] TypeList = { "General", "Book Reading", "Program","Article","Progress","Sub tasks"};

        public List<StrWrap> GetList()
        {
            return this.TypeList.Select(str => new StrWrap(str)).ToList();
        }
    }
}
