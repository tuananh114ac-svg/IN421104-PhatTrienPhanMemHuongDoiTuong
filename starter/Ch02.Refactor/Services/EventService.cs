using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Patterns;
namespace EduHub.Ch02.Services;


    public class EventService
    {
        private readonly IClubRepository _repository;
        private readonly List<IEventObserver> _observers = new();

        public EventService(IClubRepository repository)
        {
            _repository = repository;
        }

        public void Subscribe(IEventObserver observer) => _observers.Add(observer);

        public Event CreateEvent(Guid clubId, string title, DateTime date)
        {
            var club = _repository.GetClub(clubId) ?? throw new InvalidOperationException("Club not found");
            var ev = new Event { Id = Guid.NewGuid(), ClubId = clubId, Title = title, Date = date };

            // Notify tất cả observers đã đăng ký
            foreach (var observer in _observers)
            {
                observer.OnEventCreated(ev, club);
            }

            return ev;
        }
    }