using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLabel : LocalizedLabelTMPro
{
    [SerializeField] private ClickHandler m_ClickHandler = null;

    protected override void OnEnable()
    {
        base.OnEnable();

        m_ClickHandler.OnClick += OnClick;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        m_ClickHandler.OnClick -= OnClick;
    }

    protected override void UpdateLabel()
    {
        // base is being overwritten

        m_Localization.TryFormatValue(m_Key, out string text, m_ClickHandler.TimesClicked);

        m_Label.text = text;
    }

    private void OnClick(ClickHandler sender)
    {
        UpdateLabel();
    }
}
