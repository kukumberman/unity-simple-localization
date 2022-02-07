using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LocalizedLabel : MonoBehaviour
{
    [SerializeField] protected string m_Key = "";

    protected LocalizationManager m_Localization = null;

    protected virtual void Awake()
    {
        m_Localization = FindObjectOfType<LocalizationManager>();
    }

    protected virtual void OnEnable()
    {
        m_Localization.OnLanguageChanged += OnLanguageChanged;
    }

    protected virtual void OnDisable()
    {
        m_Localization.OnLanguageChanged -= OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        UpdateLabel();
    }

    protected abstract void UpdateLabel();
}
