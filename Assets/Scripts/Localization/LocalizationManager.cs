using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class LocalizationManager : MonoBehaviour
{
    public event Action OnLanguageChanged = null;

    [SerializeField] private TextAsset m_TextAsset = null;

    private string m_PreferedLanguage = "";

    private string m_SystemLanguage = "";

    private Dictionary<string, Dictionary<string, string>> m_Localization = new Dictionary<string, Dictionary<string, string>>();

    private Dictionary<string, string> m_CurrentLocalization = new Dictionary<string, string>();

    private const string SAVE_KEY = "PREFERED_LANGUAGE";

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Sync();
    }

    private void Init()
    {
        string json = m_TextAsset.text;

        m_Localization = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

        m_SystemLanguage = Application.systemLanguage.ToString();

        Load();
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            m_PreferedLanguage = PlayerPrefs.GetString(SAVE_KEY);

            if (!m_Localization.ContainsKey(m_PreferedLanguage))
            {
                m_PreferedLanguage = SystemLanguage.English.ToString();
            }
        }
        else
        {
            if (m_Localization.ContainsKey(m_SystemLanguage))
            {
                m_PreferedLanguage = m_SystemLanguage;
            }
            else
            {
                m_PreferedLanguage = SystemLanguage.English.ToString();
            }
        }

        m_CurrentLocalization = m_Localization[m_PreferedLanguage];

        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetString(SAVE_KEY, m_PreferedLanguage);
    }

    private void Sync()
    {
        m_CurrentLocalization = m_Localization[m_PreferedLanguage];

        OnLanguageChanged?.Invoke();
    }

    public bool IsValid(string language)
    {
        return m_Localization.ContainsKey(language);
    }

    public void ChangeLanguage(string language)
    {
        if (!TryChangeLanguage(language))
        {
            Debug.LogWarning($"Language [{language}] doesn't exists!");
        }
    }

    public bool TryChangeLanguage(string language)
    {
        bool isValid = IsValid(language);

        if (isValid)
        {
            if (m_PreferedLanguage != language)
            {
                m_PreferedLanguage = language;
                Sync();
                Save();
            }
        }

        return isValid;
    }

    public bool GetValue(string key, out string value)
    {
        bool contains = m_CurrentLocalization.ContainsKey(key);

        value = contains ? m_CurrentLocalization[key] : $"#[{key}]";

        return contains;
    }

    public bool TryFormatValue(string key, out string result, params object[] args)
    {
        bool contains = GetValue(key, out string text);

        if (contains)
        {
            result = string.Format(text, args);
        }
        else
        {
            result = text;
        }

        return contains;
    }
}
