using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public GameObject AchievementsPanel;
    public GameObject DailyPanel;

    public RectTransform thisButton;
    public Image AImage;
    public Image DImage;
    public Color myColorGrey;
    public Color myColorWhite;

    public void PressAchievementsButton()
    {
        thisButton.SetAsLastSibling();
        AchievementsPanel.SetActive(true);
        DailyPanel.SetActive(false);
        DImage.color = myColorGrey;
        AImage.color = myColorWhite;
    }

    public void PressDailyButton()
    {
        thisButton.SetAsLastSibling();
        AchievementsPanel.SetActive(false);
        DailyPanel.SetActive(true);
        AImage.color = myColorGrey;
        DImage.color = myColorWhite;
    }
}
