using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    public Text distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceValue = flag.transform.position.x - car.transform.position.x;
        distance.text = "Distance between Car and Flag: " + distanceValue.ToString("F2") + "m";

        if (distanceValue < 0f)
        {
            distance.text = "You reached the flag!";
        }
    }
}
