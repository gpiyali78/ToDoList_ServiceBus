﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_ServiceBus
{
    public class TaskList
    {
        [BsonId]
        public ObjectId TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TaskStartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TaskEndDate { get; set; }
        public string TaskStatus { get; set; }
        public int TotalEffortRequired { get; set; }
    }
}
