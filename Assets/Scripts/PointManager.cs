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
  
    // Start is called before the first frame update
    void Start()
    {
        UpdatePointUI();
        FinalScoreText.gameObject.SetActive(false);
    }

   public void GetPoints()
    {
        points++;
        UpdatePointUI();
    }

    // Update is called once per frame
    void UpdatePointUI()
    {
        pointsText.text = "" + points;
        FinalScoreText.text = "Final score: " + points + " points";
    }

    public void ShowFinalText()
    {
        FinalScoreText.gameObject.SetActive(true);
    }
}
