using LetterManagement.Shared.Dtos;
using LetterManagement.Shared.Models;
using Microsoft.IdentityModel.JsonWebTokens;

namespace LetterManagement.Client.StateContainer;

public class TokenState
{
    public string? Token { get; set; }

    public DateTime ExpiredDate { get; set; }

    public Guid UserId { get; set; }

    public Roles Role { get; set; }

    public string? Email { get; set; }

    public TokenState SetTokenState(AppUserDto appUserDto)
    {
        var handler = new JsonWebTokenHandler();
        var token = handler.ReadJsonWebToken(appUserDto.Token);
        
         Token = appUserDto.Token;
         UserId = appUserDto.UserId;
         Role = appUserDto.Role;
         Email = appUserDto.Email;

         ExpiredDate = token.ValidTo;

        return this;
    }

    public void ClearState()
    {
        this.Token = null;
        this.Email = null;
    }
}