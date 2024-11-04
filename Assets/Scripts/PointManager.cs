using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;
    // Start is called before the first frame update
    void Start()
    {
        
        UpdatePointUI();
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
    }
}
