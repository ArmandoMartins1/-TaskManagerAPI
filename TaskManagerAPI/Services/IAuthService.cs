using Microsoft.AspNetCore.Identity;

public interface IAuthService
{
    Task<IdentityResult> Register(UserDTO userDTO);
    Task<string> Login(UserDTO userDTO);
}
