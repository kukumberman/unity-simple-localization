using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = UnityEngine.UI.Text;

public class LocalizedLabelText : LocalizedLabel
{
    [SerializeField] protected Text m_Label = null;

    protected override void UpdateLabel()
    {
        m_Localization.GetValue(m_Key, out string text);

        m_Label.text = text;
    }
}
