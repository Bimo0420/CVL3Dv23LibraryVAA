using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class UserInput
    {
        public static int GetIntInput(Editor editor, /*string def, */string prompt)
        {
            while (true) //для повторного запроса ввода от пользователя в случае некорректного ввода.
            {
                PromptResult result = editor.GetString(prompt);
                if (result.Status == PromptStatus.OK)
                {
                    if (int.TryParse(result.StringResult, out int value))
                    {
                        return value;
                    }
                    else
                    {
                        editor.WriteMessage("Некорректный ввод. Пожалуйста, введите целое число.\n");
                    }
                }
                else
                {
                    editor.WriteMessage("Число не было введено.\n");

                    //int defInt = int.Parse(def);
                    //return defInt;
                }
            }
        }

        public static double GetDoubleInput(Editor editor, /*string def, */string prompt)
        {
            while (true) //для повторного запроса ввода от пользователя в случае некорректного ввода.
            {
                PromptResult result = editor.GetString(prompt);
                if (result.Status == PromptStatus.OK)
                {
                    if (double.TryParse(result.StringResult, out double value))
                    {
                        return value;
                    }
                    else
                    {
                        editor.WriteMessage("Некорректный ввод. Пожалуйста, введите число.\n");
                    }
                }
                else
                {
                    editor.WriteMessage("Число не было введено.\n");

                    //double defInt = double.Parse(def);
                    //return defInt;
                }
            }
        }

        public static string GetStringInput(Editor editor, string def, string prompt)
        {
            while (true) //для повторного запроса ввода от пользователя в случае некорректного ввода.
            {
                PromptStringOptions options = new PromptStringOptions(prompt);
                PromptResult result = editor.GetString(options);

                if (result.Status == PromptStatus.OK)
                {
                    return result.StringResult;
                }
                else
                {
                    editor.WriteMessage("Число не было введено.\n");
                }
            }
        }


        public static string GetYesNoInput(Editor editor, string prompt, string[] choices)
        {
            while (true)
            {
                PromptKeywordOptions keywordOptions = new PromptKeywordOptions(prompt);

                foreach (string choice in choices)
                {
                    keywordOptions.Keywords.Add(choice);
                }

                PromptResult result = editor.GetKeywords(keywordOptions);
                if (result.Status == PromptStatus.OK)
                {
                    return result.StringResult;
                }
                else
                {
                    return null;
                }
            }
        }


        public static int GetIntInput(Editor editor, string prompt, string[] options)
        {
            while (true)
            {
                editor.WriteMessage(prompt + " ");
                foreach (string option in options)
                {
                    editor.WriteMessage(option + " ");
                }

                PromptResult result = editor.GetString("");
                if (result.Status == PromptStatus.OK)
                {
                    string userInput = result.StringResult;
                    int selectedIndex = Array.IndexOf(options, userInput);

                    if (selectedIndex >= 0)
                    {
                        return selectedIndex;
                    }
                }

                editor.WriteMessage("Некорректный ввод. Пожалуйста, выберите один из предложенных вариантов.\n");
            }
        }

    }
}
