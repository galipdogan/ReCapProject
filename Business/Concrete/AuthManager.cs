using Business.Abstract;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Results;
using Entities.Dtos;
using System;
using Business.Constants;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken, UserMessages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(UserMessages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, UserMessages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto useForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(useForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                EMail = useForRegisterDto.Email,
                FirstName = useForRegisterDto.FirstName,
                LastName = useForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, UserMessages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(UserMessages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
