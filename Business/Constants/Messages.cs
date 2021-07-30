using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";

        public static string CarUpdated { get; internal set; }
        public static string CarDeleted { get; internal set; }
        public static string BrandUpdated { get; internal set; }
        public static string BrandDeleted { get; internal set; }
        public static string BrandAdded { get; internal set; }
        public static string ColorUpdated { get; internal set; }
        public static string ColorDeleted { get; internal set; }
        public static string ColorAdded { get; internal set; }
        public static string ColorsListed { get; internal set; }
    }
}
