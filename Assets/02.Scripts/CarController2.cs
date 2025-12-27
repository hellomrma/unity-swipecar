using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public float carSpeed = 0f;

    Vector2 startPosition;
    bool isDragging = false;  // 드래그 진행 중인지 확인하는 플래그


    void Update()
    {
        // Unity 마우스 입력 함수 참고 정보
        // GetMouseButton(0): 마우스 버튼을 누르고 있는 동안 true 반환 (연속 입력 감지)
        // GetMouseButtonDown(0): 마우스 버튼을 누른 순간 한 번만 true 반환 (단발 입력 감지)
        // GetMouseButtonUp(0): 마우스 버튼을 떼는 순간 한 번만 true 반환 (단발 입력 감지)


        // 드래그가 진행 중이 아니면 언제든지 새로운 드래그 시작 가능
        if (Input.GetMouseButtonDown(0) && !isDragging)
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
        }


        transform.Translate(carSpeed, 0, 0);

        // 양/음수 분기하여 임계값과 감쇠 적용 (뒤로 가는 동작 포함)
        if (carSpeed > 0f)
        {
            if (carSpeed <= 0.005f)
            {
                carSpeed = 0f;
            }
            else
            {
                carSpeed *= 0.98f;
            }
        }
        else if (carSpeed < 0f)
        {
            if (carSpeed >= -0.005f)
            {
                carSpeed = 0f;
            }
            else
            {
                carSpeed *= 0.98f;
            }
        }
        // carSpeed == 0f 이면 아무 작업도 하지 않음
    }
}

