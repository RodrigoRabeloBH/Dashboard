using System;
using System.Collections.Generic;
using System.Linq;

namespace APIDashboard.Helpers
{
    public static class Helper
    {
        private static Random _rand = new Random();

        private static readonly List<string> bizPrefix = new List<string>
        {
            "ABC",
            "XYZ",
            "MainSt",
            "Sales",
            "Enterprise",
            "Ready",
            "Quick",
            "Peak",
            "Magic",
            "Family",
            "Confort"
        };
        private static readonly List<string> bizSuffix = new List<string>
        {
            "Corporation",
            "Co",
            "Logistics",
            "Transit",
            "Bakery",
            "Goods",
            "Foods",
            "Cleaners",
            "Hotel",
            "Planners",
            "Automotive",
            "Books"
        };
        private static readonly List<string> usStates = new List<string>
        {
            "AK","AL","AZ","AR","CA","CO","CT","DE","FL","GA",
            "HI","DI","IL","IN","IA","KS","KY","LA","ME","MD",
            "MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ",
            "NM","NY","NC","ND","OH","OK","OR","PA","RI","SC",
            "SD","TN","TX","UT","VT","VA","WA","WV","WI","WY"
        };
        private static string GetRandom(List<string> items)
        {
            return items[_rand.Next(items.Count)];
        }
        internal static string MakeUniqueCustomerName(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSuffix.Count;

            if (names.Count >= maxNames)
            {
                throw new System.InvalidOperationException("Maximum number of unique names exceeded.");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName = prefix + suffix;

            if (names.Contains(bizName)) MakeUniqueCustomerName(names);

            return bizName;
        }
        internal static string MakeCustomerEmail(string name)
        {
            return $"contact@{name.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(usStates);
        }

        internal static decimal GetRandomOrderTotal()
        {
            return _rand.Next(1000, 50000);
        }
        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime date)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - date;

            if (timePassed < minLeadTime) return null;

            return date.AddDays(_rand.Next(7, 14));
        }
    }
}