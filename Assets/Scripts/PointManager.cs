using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI speedIncreasedText; 

    void Start()
    {
        UpdatePointUI();
        FinalScoreText.gameObject.SetActive(false);
        speedIncreasedText.gameObject.SetActive(false); 
    }

    public void GetPoints()
    {
        points++;
        UpdatePointUI();

        if (points % 10 == 0)
        {
            ShowSpeedIncreasedMessage();
        }
    }

    void UpdatePointUI()
    {
        pointsText.text = "" + points;
        FinalScoreText.text = "Final score: " + points + " points";
    }

    public void ShowFinalText()
    {
        FinalScoreText.gameObject.SetActive(true);
    }

 
    void ShowSpeedIncreasedMessage()
    {
        speedIncreasedText.gameObject.SetActive(true); 
        StartCoroutine(HideSpeedIncreasedMessage());  
    }

    IEnumerator HideSpeedIncreasedMessage()
    {
        yield return new WaitForSeconds(1.5f);
        speedIncreasedText.gameObject.SetActive(false); 
    }
}