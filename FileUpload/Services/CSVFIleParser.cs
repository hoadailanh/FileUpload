using API.models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace API.services
{
    public class CSVFIleParser : IFileParser
    {
        private readonly string Delimiter = "|";

        private readonly string EncodingString = "ISO-8859-1";
        public object Parse(IFormFile file)
        {
            ResultModel result = new ResultModel();
            List<List<string>> rows = new List<List<string>>();
            List<string> headers = new List<string>();
            var stream = file.OpenReadStream();
            var reader = new StreamReader(stream, Encoding.GetEncoding(EncodingString));

            bool firstLine = true;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                    continue;
                //var values = line.Split(_options.CsvDelimiter.ToCharArray());
                var values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                List<string> row = new List<string>();

                for (int i = 0; i < values.Length; i++)
                {
                    //var value = values[i] != null ? values[i].Trim(' ', '\t', '\n', '\v', '\f', '\r', '"') : "";
                    if (firstLine)
                    {
                        headers.Add(values[i]);
                    }
                    else
                    {
                        row.Add(values[i]);    
                    }
                }
                
                if(firstLine)
                {
                    firstLine = false;
                }
                else
                {
                    rows.Add(row);
                }
            }
            result.Headers = headers;
            result.Rows = rows;

            return result;
        }

    }
}
