using System.Security.Cryptography;
using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository;
public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfo
{
    private readonly DatabaseContext _databaseContext;

    public UserInfoRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    public UserInfo CreateUser(UserInfo userInfo)
    {
        userInfo.Password = SecretHasher.Hash(userInfo.Password);
        _databaseContext.Users.Add(userInfo);
        _databaseContext.SaveChanges();
        return userInfo;
    }

    /// <summary>
    /// Verify if the users password is correct that what is strored in the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool Verify(Guid id, string password)
    {
        var user = _databaseContext.Users.Find(id);
        if (user is null)
        {
            return false;
        }
        if (SecretHasher.Verify(password, user.Password))
        {
            return true;
        }
        return false;
    }

    public UserInfo GetUserByEmail(string email)
    {
        var user = _databaseContext.Users.First(x => x.Email == email);
        if (user is not null)
        {
            return user;
        }
        return null;
    }
}

public static class SecretHasher
{
    private const int _saltSize = 16;
    private const int _keySize = 32;
    private const int _interations = 100000;
    private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

    private const char segmentDelimiter = ':';

    public static string Hash(string pass)
    {
        var salt = RandomNumberGenerator.GetBytes(_saltSize);
        var key = Rfc2898DeriveBytes.Pbkdf2(
            pass,
            salt,
            _interations,
            _algorithm,
            _keySize
        );
        return string.Join(
            segmentDelimiter,
            Convert.ToHexString(key),
            Convert.ToHexString(salt),
            _interations,
            _algorithm
        );
    }

    public static bool Verify(string pass, string hash)
    {
        var segments = hash.Split(segmentDelimiter);
        var key = Convert.FromHexString(segments[0]);
        var salt = Convert.FromHexString(segments[1]);
        var iterations = int.Parse(segments[2]);
        var algorithm = new HashAlgorithmName(segments[3]);
        var inputSecretKey = Rfc2898DeriveBytes.Pbkdf2(
            pass,
            salt,
            iterations,
            algorithm,
            key.Length
        );
        return key.SequenceEqual(inputSecretKey);
    }
}
