namespace PWMGR;

public static class Generator
{
    public static int Length { get; set; }

    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Numbers = "0123456789";
    private const string Symbols = "!@#$%&*?";
    public static bool isUpperChecked;
    public static bool isLowerChecked;
    public static bool isNumberChecked;
    public static bool isSymbolChecked;
    
    public static string CreatePassword()
    {
        string container = "";
        

        if (isUpperChecked)
            container += Upper;
        


        if (isLowerChecked)
            container += Lower;
        

        if (isNumberChecked)
            container += Numbers;
        

        if (isSymbolChecked)
            container += Symbols;
        
        
        if (!isUpperChecked && !isLowerChecked && !isNumberChecked && !isSymbolChecked)
            container += Lower;
        
        
        Random rand = new Random();
        char[] chars = new char[Length];
        for (int i = 0; i < Length; i++)
        {
            chars[i] = container[rand.Next(0, container.Length)];
        }
        
        isUpperChecked = false;
        isLowerChecked = false;
        isNumberChecked = false;
        isSymbolChecked = false;
        Length = 0;
        
        return new string(chars);
        
    }
    
}


