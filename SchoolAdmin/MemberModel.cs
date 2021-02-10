using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolAdmin
{
    public enum Province
    {
        Alberta, British_Columbia, Manitoba, New_Brunswick,
        Newfoundland_Labrador, Northwest_Territories, Nova_Scotia, Nunavut
    }

    public enum School { Little_Rouge, Sam_Chapman, Bill_Hogart }

    interface IDisplay
    {
        public void ShowInfo();
    }

    public class MemberModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Province Province { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public int Salary { get; set; }
        public School School { get; set; }
    }
}
