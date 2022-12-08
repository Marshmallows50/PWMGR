namespace PWMGR;

public static class Generator
{
    public static int Length { get; set; }

    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Numbers = "01234567890123456789";
    private const string Symbols = "!@#$%&*?!@#$%&*?!@#$%&*?";
    public static bool IsUpperChecked { get; set; }
    public static bool IsLowerChecked { get; set; }
    public static bool IsNumberChecked { get; set; }
    public static bool IsSymbolChecked { get; set; }
    
    public static string CreatePassword()
    {
        string container = "";
        

        if (IsUpperChecked)
            container += Upper;
        


        if (IsLowerChecked)
            container += Lower;
        

        if (IsNumberChecked)
            container += Numbers;
        

        if (IsSymbolChecked)
            container += Symbols;
        
        
        if (!IsUpperChecked && !IsLowerChecked && !IsNumberChecked && !IsSymbolChecked)
            container += Lower;
        
        
        Random rand = new Random();
        char[] chars = new char[Length];
        for (int i = 0; i < Length; i++)
        {
            chars[i] = container[rand.Next(0, container.Length)];
        }
        
        IsUpperChecked = false;
        IsLowerChecked = false;
        IsNumberChecked = false;
        IsSymbolChecked = false;
        Length = 0;
        
        return new string(chars);
        
    }
    
}


