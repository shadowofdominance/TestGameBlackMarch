using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tileInfoText;

    public void UpdateUI(string info)
    {
        tileInfoText.text = info;
    }
}
