using System.Collections.Generic;
using System.Linq;

namespace APIDashboard.Helpers
{
    public class PaginatedResponse<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
        public PaginatedResponse(IEnumerable<T> data, int i, int len)
        {
            Total = data.Count();
            Data = data.Skip((i - 1) * len).Take(len).ToList();
        }
    }
}