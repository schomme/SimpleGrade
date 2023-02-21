using SimpleGradeClient.Base;

namespace SimpleGradeClient.Model
{
    class DefaultGroup : GroupBase
    {
        public DefaultGroup()
        {
            this.IconPath = Icons.Path.Default;
            this.Name = "Default";
            this.Description = "Defaultdescription";
        }
    }
}
