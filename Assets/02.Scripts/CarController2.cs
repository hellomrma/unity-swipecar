using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public float carSpeed = 0f;

    Vector2 startPosition;
    public bool isDragging = false;  // 드래그 진행 중인지 확인하는 플래그
    public bool isCanStart = false;

    // 새로 추가: Restart 버튼 상태를 확인하기 위한 참조(인스펙터에 할당)
    public GameObject restartButton;

    void Update()
    {
        // Unity 마우스 입력 함수 참고 정보
        // GetMouseButton(0): 마우스 버튼을 누르고 있는 동안 true 반환 (연속 입력 감지)
        // GetMouseButtonDown(0): 마우스 버튼을 누른 순간 한 번만 true 반환 (단발 입력 감지)
        // GetMouseButtonUp(0): 마우스 버튼을 떼는 순간 한 번만 true 반환 (단발 입력 감지)


        // 드래그 시작 허용 조건: 드래그 중이 아니고 차량이 거의 정지 상태이며 restart 버튼이 활성화되어 있지 않을 때만 허용
        bool restartActive = restartButton != null && restartButton.activeSelf;
        if (Input.GetMouseButtonDown(0) && !isDragging && Mathf.Abs(carSpeed) <= 0.005f && !restartActive)
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
            isCanStart = true;
            GetComponent<AudioSource>().Play();
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