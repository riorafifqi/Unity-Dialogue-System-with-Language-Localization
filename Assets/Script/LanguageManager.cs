using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language { English = 0, Indonesia = 1 };

public class LanguageManager : MonoBehaviour
{
    public Language usedLanguage = Language.English;

    public Language GetLanguage()
    {
        return usedLanguage;
    }

    public void SetLanguage(int value)
    {
        switch ((Language)value)
        {
            case (Language.English):
                usedLanguage = Language.English;
                break;
            case (Language.Indonesia):
                usedLanguage = Language.Indonesia;
                break;
        }
    }
}
