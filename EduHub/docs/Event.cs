using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.docs
{
    public class Event
    {
        public Guid Id { get; private set; }
        public Guid ClubId { get; private set; }
        public string Title { get; private set; }
        public int Capacity { get; private set; }
        public int ConfirmedCount { get; private set; }
        public bool IsFinished { get; private set; }

        private Event() { }

        public static Event Create(Guid clubId, string title, int capacity)
        {
            return new Event
            {
                Id = Guid.NewGuid(),
                ClubId = clubId,
                Title = title,
                Capacity = capacity,
                ConfirmedCount = 0,
                IsFinished = false
            };
        }

        public void UpdateInfo(string title, int capacity)
        {
            Title = title;
            Capacity = capacity;
        }
    }
}