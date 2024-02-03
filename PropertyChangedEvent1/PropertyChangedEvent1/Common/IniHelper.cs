using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using PropertyChangedEvent1.Common.Interface;

namespace PropertyChangedEvent1.Common
{
    public class IniHelper : IIOHelper
    {
        private const string HeaderPattern = @"\[(.*?)\]";
        private const string ContentPattern = @"(.+?)=(.+)";

        private readonly Dictionary<string, Dictionary<string, object>> Sections;

        public IniHelper() 
        {
            Sections = new Dictionary<string, Dictionary<string, object>>();
        }

        public void Load(string filePath)
        {
            Sections.Clear();
            string header = string.Empty;
            string key = string.Empty;
            string value = string.Empty;
            bool isMatch = false;

            IEnumerable<string> readLines =  File.ReadLines(filePath);
            foreach (string line in readLines)
            {
                string trimLine = line.Trim();
                (isMatch, header) = HeaderPatterns(trimLine);
                if (isMatch)
                {
                    Sections[header] = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                }
                else
                {
                    (isMatch, key, value) = ContentPatterns(trimLine);
                    if (isMatch)
                    {
                        Sections[header][key] = value;
                    }
                }
            }
        }

        public object Get(string header, string key)
        {
            if(Sections.TryGetValue(header, out var section))
            {
                if (section.TryGetValue(key, out var value))
                {
                    return value;
                }
            }
            return null;
        }

        private (bool, string) HeaderPatterns(string line)
        {
            Match match = Regex.Match(line, HeaderPattern);

            bool outMatch = match.Success;
            string outGroupsValue = string.Empty;

            if (outMatch)
            {
                outGroupsValue = match.Groups[1].Value;
            }
            return (outMatch, outGroupsValue);
        }

        private (bool, string, string) ContentPatterns(string line)
        {
            Match match = Regex.Match(line, ContentPattern);

            bool outMatch = match.Success;
            string outKey = string.Empty;
            string outValue = null;
            if (outMatch)
            {
                outKey = match.Groups[1].Value;
                outValue = match.Groups[2].Value;
            }
            return (outMatch, outKey, outValue);
        }

    }
}
