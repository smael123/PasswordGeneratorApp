namespace PasswordGeneratorApp
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int length, bool includeSpecialCharacters, bool includeNumbers);
    }
}