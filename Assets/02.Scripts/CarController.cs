using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float carSpeed = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        // Unity 마우스 입력 함수 참고 정보
        // GetMouseButton(0): 마우스 버튼을 누르고 있는 동안 true 반환 (연속 입력 감지)
        // GetMouseButtonDown(0): 마우스 버튼을 누른 순간 한 번만 true 반환 (단발 입력 감지)
        // GetMouseButtonUp(0): 마우스 버튼을 떼는 순간 한 번만 true 반환 (단발 입력 감지)


        if (Input.GetMouseButtonDown(0))
        {
            carSpeed = 0.23f;
        }


        transform.Translate(carSpeed, 0, 0);

        carSpeed *= 0.98f;

        Debug.Log("Car Speed: " + carSpeed);


        if (carSpeed <= 0.005f)
        {
            carSpeed = 0f;
        }
    }
}
