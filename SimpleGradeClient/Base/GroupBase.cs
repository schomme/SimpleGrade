using JsonSubTypes;
using Newtonsoft.Json;
using SimpleGradeClient.Model;
using System;
using System.Collections.Generic;

namespace SimpleGradeClient.Base
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(RootGroup))]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(SchoolClass))]
    [JsonSubtypes.KnownSubType(typeof(GroupBase), nameof(Subject))]
    public abstract class GroupBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSelected { get; set; } = false;
        public List<GroupBase> Children { get; set; } = new List<GroupBase>();
        public List<Person> Member { get; set; } = new List<Person>();
        public string IconPath { get; set; } = Icons.Path.Default;

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Name, Description, IsSelected);
        }
    }
}
