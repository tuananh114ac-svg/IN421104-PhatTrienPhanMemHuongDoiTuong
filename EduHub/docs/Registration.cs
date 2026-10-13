using EduHub.docs;
using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.docs
{
    public class Registration
    {
        public Guid Id { get; private set; }
        public Guid MemberId { get; private set; }
        public Guid EventId { get; private set; }
        public RegistrationStatus Status { get; private set; }
        public bool HasCheckedIn { get; private set; }

        private Registration() { }

        public static Registration Create(Guid memberId, Guid eventId)
        {
            return new Registration
            {
                Id = Guid.NewGuid(),
                MemberId = memberId,
                EventId = eventId,
                Status = RegistrationStatus.Pending,
                HasCheckedIn = false
            };
        }

        public void Cancel()
        {
            Status = RegistrationStatus.Cancelled;
        }

        public void Approve(Event evt)
        {
            Status = RegistrationStatus.Confirmed;
        }
    }
}