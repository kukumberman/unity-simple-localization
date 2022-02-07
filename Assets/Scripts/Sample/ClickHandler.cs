using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action<ClickHandler> OnClick = null;

    private int m_TimesClicked = 0;

    public int TimesClicked => m_TimesClicked;

    public void Click()
    {
        m_TimesClicked += 1;

        OnClick?.Invoke(this);
    }
}
