using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
public class LocalizeUI : MonoBehaviour
{
    [System.Serializable]
    public struct UIAttribute
    {
        public Language textLanguage;

        [TextArea]
        public string text;
    };

    private LanguageManager languageManager;
    public UIAttribute[] texts;
    private TMP_Text UIText;

    public void Awake()
    {
        languageManager = FindObjectOfType<LanguageManager>();
        UIText = GetComponent<TMP_Text>();
    }

    public void Update()
    {
        UIText.text = GetText(languageManager.usedLanguage);
    }

    public string GetText(Language language)
    {
        foreach (UIAttribute attribute in texts)
        {
            if (attribute.textLanguage == language)
            {
                return attribute.text;
            }
        }

        return null;
    }

    void CheckDuplicateLanguage()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            for (int j = 0; j < texts.Length - 1; j++)
            {
                if (texts[i].textLanguage == texts[j + 1].textLanguage)
                    UnityEngine.Debug.LogError("Duplicate Language");
            }
        }
    }
}
