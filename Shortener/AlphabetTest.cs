using System.Text;

namespace URLShort.Shortener
{
    public class AlphabetTest
    {
        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static readonly int Base = Alphabet.Length;
        public static string base62Encode(string longUrl)
        {
            int longUrlCounter = longUrl.Length;
            var base62_string = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var hashString = "";
            while (longUrlCounter > 0) 
            {
                hashString += base62_string[longUrlCounter % 62];
                longUrlCounter /= 62;
            }
            return hashString;
        }
      //  public static int Decode(string s)
        //{
            
        //}
    }
}
