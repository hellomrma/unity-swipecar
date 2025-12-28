using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    public Text distance;

    public GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
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

        if (car.GetComponent<CarController2>().isCanStart == true && car.GetComponent<CarController2>().carSpeed == 0)
        {
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        car.transform.position = new Vector3(-6.74f, car.transform.position.y, car.transform.position.z);
        car.GetComponent<CarController2>().carSpeed = 0f;
        car.GetComponent<CarController2>().isCanStart = false;
        car.GetComponent<CarController2>().isDragging = false;
        restartButton.SetActive(false);

        // SceneManager.LoadScene(0); // Alternatively, reload the entire scene
    }
}
