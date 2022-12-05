namespace PWGenerator;

public static class Generator
{
    public static int Length { get; set; }

    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Numbers = "0123456789";
    private const string Symbols = "!@#$%&*?";
    public static bool isUpperChecked = true;
    public static bool isLowerChecked = true;
    public static bool isNumberChecked = true;
    public static bool isSymbolChecked = true;
    
    public static string CreatePassword()
    {
        string container = "";
        

        if (isUpperChecked)
        {
            container += Upper;
        }


        if (isLowerChecked)
        {
            container += Lower;
            
        }

        if (isNumberChecked)
        {
            container += Numbers;
            
        }

        if (isSymbolChecked)
        {
            container += Symbols;
            
        }
        
        if (isUpperChecked == false && isLowerChecked == false && isNumberChecked == false && isSymbolChecked == false)
        {
            container += Lower;
        }

        Console.WriteLine("Enter a number for password length: ");
        int passwordLength = Convert.ToInt32(Console.ReadLine());
        Random rand = new Random();
        char[] chars = new char[passwordLength];
        for (int i = 0; i < passwordLength; i++)
        {
            chars[i] = container[rand.Next(0, container.Length)];
        }
        
        return new string(chars);
        
    }
    
}


