namespace PWGenerator;

public class Generator
{
    public int Length { get; set; }

    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Numbers = "0123456789";
    private const string Symbols = "!@#$%&*?";
    public static bool isUpperChecked = true;
    public static bool isLowerChecked = true;
    public static bool isNumberChecked = true;
    public static bool isSymbolChecked = true;

    public Generator()
    {
        Length = Length;
    }

    public string CreatePassword()
    {
        
    }
    public string CreateUnlimitedPassword(int length)
    {
        string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
        Random rand = new Random();
        
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[rand.Next(0, validChars.Length)];
        }

        return new string(chars);
    }
    
    public string CreatePasswordNoUppercase(int length)
    {
        string validChars = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
        Random rand = new Random();
        
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[rand.Next(0, validChars.Length)];
        }

        return new string(chars);
    }
    
    public string CreatePasswordNoLowercase(int length)
    {
        string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*?_-";
        Random rand = new Random();
        
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[rand.Next(0, validChars.Length)];
        }

        return new string(chars);
    }
    
    public string CreatePasswordNoNumbers(int length)
    {
        string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$%^&*?_-";
        Random rand = new Random();
        
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[rand.Next(0, validChars.Length)];
        }

        return new string(chars);
    }
    public string CreatePasswordNoSymbols(int length)
    {
        string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random rand = new Random();
        
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[rand.Next(0, validChars.Length)];
        }

        return new string(chars);
    }
    
}

