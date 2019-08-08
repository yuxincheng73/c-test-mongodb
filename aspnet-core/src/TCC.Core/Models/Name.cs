using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Models
{
    public class Name
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string LanguageCode { get; set; }

        public override string ToString()
        {
            return $"{{\"content\":\"{Content}\",\"language_code\":\"{LanguageCode}\"}}";
        }
    }
}
