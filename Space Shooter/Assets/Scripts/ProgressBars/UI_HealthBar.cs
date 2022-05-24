using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : UI_ProgressBar
{
    void Start()
    {
        ProgressBar = GetComponent<Image>();
        SetColor(new Color(0.83f,0f,0f));
        SetBarFillAmount(1f);
    }
}
