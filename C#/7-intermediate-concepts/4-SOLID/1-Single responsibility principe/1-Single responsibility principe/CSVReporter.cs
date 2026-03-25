using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Single_responsibility_principe
{
    internal class CSVReporter
    {
        public void GenerateCSV<T>(IEnumerable<T> list)
        {
            var properties = typeof(T).GetProperties();

            using (var writer = new StreamWriter($"Report-{typeof(T).Name}s.csv"))
            {
                var header = string.Join("-", properties.Select(q => q.Name));
                writer.WriteLine(header);

                foreach(var item in list)
                {
                    var line = string.Join("-", properties.Select(q => q.GetValue(item)));
                    writer.WriteLine(line);
                }
            }
        }
    }
}
