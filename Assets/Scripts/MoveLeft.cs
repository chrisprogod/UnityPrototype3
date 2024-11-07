using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float baseSpeed = 15; // Base speed for obstacles
    private float currentSpeed;
    private PlayerController playerControllerScript;
    private PointManager pointManager;
    private float leftBound = -4;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            AdjustSpeed();
            transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            pointManager.GetPoints();
        }
    }

    void AdjustSpeed()
    {
        currentSpeed = baseSpeed + (pointManager.points / 10) * 4;
    }
}