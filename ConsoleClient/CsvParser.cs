using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleClient
{
    public class CsvParser
    {
        public IEnumerable<Person> Parse(string[] lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            // https://regex101.com/r/W5nCsP/1
            var regex = new Regex(@"^\d+,\w*,\d+$");
            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                if (!regex.IsMatch(line))
                {
                    throw new FormatException($"Invalid Format - Line {index + 1}: {line}");
                }
            }

            return lines.Select(l => l.Split(','))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2])
                });
        }
    }
}