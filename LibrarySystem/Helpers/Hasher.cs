namespace LibrarySystem.Helpers
{
    public class Hasher
    {
        private const int Degree = 12;
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, Degree);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
