using System.ComponentModel.DataAnnotations;

public class Users
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Salt { get; set; }
    public string Name { get; set; }
    public string SecondName { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public ulong SocialClubId { get; set; }
    public ulong? UserDetailsId { get; set; }

    public UserCustomization UserCustomization { get; set; }
}