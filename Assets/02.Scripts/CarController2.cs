using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public float carSpeed = 0f;

    Vector2 startPosition;
    bool isDragging = false;  // 드래그 진행 중인지 확인하는 플래그
    bool hasDraggedOnce = false;  // 한 번이라도 드래그가 발생했는지 확인하는 플래그

    void Start()
    {

    }

    void Update()
    {
        // Unity 마우스 입력 함수 참고 정보
        // GetMouseButton(0): 마우스 버튼을 누르고 있는 동안 true 반환 (연속 입력 감지)
        // GetMouseButtonDown(0): 마우스 버튼을 누른 순간 한 번만 true 반환 (단발 입력 감지)
        // GetMouseButtonUp(0): 마우스 버튼을 떼는 순간 한 번만 true 반환 (단발 입력 감지)


        // 한 번도 드래그하지 않았고, 드래그가 진행 중이 아니고, 자동차가 완전히 멈춰있을 때만 새로운 드래그 시작 가능
        if (Input.GetMouseButtonDown(0) && !hasDraggedOnce && !isDragging)
        {
            startPosition = Input.mousePosition;
            isDragging = true;  // 드래그 시작
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 endPosition = Input.mousePosition;

            float dragGap = endPosition.x - startPosition.x;

            carSpeed = (dragGap * 0.005f) * 0.23f;
            isDragging = false;  // 드래그 종료
            hasDraggedOnce = true;  // 드래그가 한 번 발생했음을 표시 (더 이상 드래그 불가)
        }


        transform.Translate(carSpeed, 0, 0);

        if (carSpeed <= 0.005f)
        {
            carSpeed = 0f;
        }
        else
        {
            carSpeed *= 0.98f;
        }
    }
}

