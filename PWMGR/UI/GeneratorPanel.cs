using TUIFrameWork;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;

public class GeneratorPanel : Panel
{
    public GeneratorPanel() : base(4)
    {
        SetDimensions(100, 90);
        hAlignment = HAlignment.Center;
        vAlignment = VAlignment.Center;

        #region generatePwMenu
        Menu generatePwMenu = new Menu(true, 4, LayoutDirection.Row);
        generatePwMenu.hAlignment = HAlignment.Center;
        TextField generatedPwField = new TextField(30);
        TextField generatedPwLength = new TextField(2, "--");
        MenuItem genBtn = new MenuItem("Generate");
        
        generatePwMenu.Add(generatedPwField);
        generatePwMenu.Add(generatedPwLength);
        generatePwMenu.Add(genBtn);
        generatePwMenu.ProcessDimensions();
        #endregion

        #region checkboxOptions
        Menu checkboxOptions = new Menu(true, 2, LayoutDirection.Row);
        checkboxOptions.hAlignment = HAlignment.Center;
        CheckBox upperCase = new CheckBox("A-Z");
        CheckBox lowerCase = new CheckBox("a-z");
        CheckBox numbers = new CheckBox("0-9");
        CheckBox symbols = new CheckBox("!@#$%&*");
        
        checkboxOptions.Add(upperCase);
        checkboxOptions.Add(lowerCase);
        checkboxOptions.Add(numbers);
        checkboxOptions.Add(symbols);
        checkboxOptions.ProcessDimensions();
        #endregion

        #region genBtn Action
        genBtn.action = delegate
        {
            if (upperCase.Toggled)
                Generator.isUpperChecked = true;
            if (lowerCase.Toggled)
                Generator.isLowerChecked = true;
            if (numbers.Toggled)
                Generator.isNumberChecked = true;
            if (symbols.Toggled)
                Generator.isSymbolChecked = true;
        
            int.TryParse(generatedPwLength.text, out int number);
            Generator.Length = number;
            generatedPwField.SetText(Generator.CreatePassword());
        };
        #endregion
        
        Add(generatePwMenu);
        Add(checkboxOptions);
        ProcessDimensions();
    }
}