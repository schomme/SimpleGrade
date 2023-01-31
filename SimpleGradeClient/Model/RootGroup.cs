using Newtonsoft.Json;
using SimpleGradeClient.Base;

namespace SimpleGradeClient.Model
{
    public class RootGroup : GroupBase
    {
        private static RootGroup _group;

        private RootGroup()
        {
            Name = "root";
            Description = "root group to store all sub groups";
        }

        public static RootGroup Get()
        {
            if (_group is null) _group = new RootGroup();
            return _group;
        }

        public static RootGroup FromJson(string json)
        {
            if (string.IsNullOrEmpty(json)) return _group;
            GroupBase.All.Clear();
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented, ObjectCreationHandling = ObjectCreationHandling.Auto };
            var o = JsonConvert.DeserializeObject<RootGroup>(json, settings) ?? Get();
            _group = o;
            return _group;
        }
    }
}
