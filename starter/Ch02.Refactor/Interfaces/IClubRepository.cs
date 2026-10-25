using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interfaces;

public interface IClubRepository
{
    void AddClub(Club club);
    Club GetClub(Guid id);
    List<Club> GetAllClubs();

    void AddMember(Member member);
    int GetMemberCount(Guid clubId);
    List<Member> GetMembersByClub(Guid clubId);
} 