using System;
using EduHub.Ch02.Domain;
using Xunit;

namespace Ch02.Refactor.Tests;

public class DomainTests
{
    // Đã xoá test mẫu của ClubManager vì class đó không còn tồn tại.

    [Fact]
    public void Club_Create_WithValidName_ReturnsClub()
    {
        // Arrange
        string name = "CLB Lập Trình";
        string desc = "Mô tả CLB";

        // Act
        var club = Club.Create(name, desc);

        // Assert
        Assert.NotNull(club);
        Assert.Equal(name, club.Name);
    }

    [Fact]
    public void Club_Create_WithInvalidName_ThrowsArgumentException()
    {
        // Arrange
        string invalidName = new string('A', 101); // Dài 101 ký tự

        // Act
        var act = () => Club.Create(invalidName, "Mô tả");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_HasRoom_AtMaxMembers_ReturnsFalse()
    {
        // Arrange
        var club = new Club { Id = Guid.NewGuid(), Name = "Test", Description = "Test" };
        int currentMembers = 50; // Chạm mốc MaxMembers = 50

        // Act
        bool hasRoom = club.HasRoom(currentMembers);

        // Assert
        Assert.False(hasRoom);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = new Event { Id = Guid.NewGuid(), ClubId = Guid.NewGuid(), Title = "Event", Date = DateTime.Now };
        var memberId = Guid.NewGuid();

        // Act
        bool result = ev.Register(memberId);

        // Assert
        Assert.True(result);
        Assert.Contains(memberId, ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = new Event { Id = Guid.NewGuid(), ClubId = Guid.NewGuid(), Title = "Event", Date = DateTime.Now };
        var memberId = Guid.NewGuid();
        ev.Register(memberId); // Đăng ký lần 1

        // Act
        bool result = ev.Register(memberId); // Đăng ký lần 2

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = new Event { Id = Guid.NewGuid(), ClubId = Guid.NewGuid(), Title = "Event", Date = DateTime.Now };
        var memberId = Guid.NewGuid(); // Chưa Register

        // Act
        var act = () => ev.CheckIn(memberId);

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }
}