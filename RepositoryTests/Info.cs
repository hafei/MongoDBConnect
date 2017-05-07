using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RepositoryTests
{
    public class Info
    {
        [BsonId]
        public object _id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string courseName { get; set; }
        public int score { get; set; }
        public DateTime createTime { get; set; }
    }
}
