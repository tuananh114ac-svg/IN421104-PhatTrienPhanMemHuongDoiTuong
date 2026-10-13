using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.docs
{
    public class Club
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Member> Members { get; private set; }

        private Club()
        {
            Members = new List<Member>();
        }

        public static Club Create(string name, string description, List<string> existingNames)
        {
            return new Club
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
        }

        public void RemoveMember(Member member)
        {
            if (Members.Contains(member))
            {
                Members.Remove(member);
            }
        }
    }
}