using UnityEngine;

public class CarController3 : MonoBehaviour
{
    public float carSpeed = 0f;

    Vector2 startPosition;
    bool isDragging = false;  // 드래그 진행 중인지 확인하는 플래그
    bool hasDraggedOnce = false;  // 한 번이라도 드래그가 발생했는지 확인하는 플래그


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

        // 변경: 음수 속도도 허용하도록 절대값 기반으로 정지 판정
        // Mathf.Abs(carSpeed)를 사용하는 이유:
        // - carSpeed가 음수(뒤로 이동)일 경우에도 절대값(|carSpeed|)으로 정지 임계값을 검사하여
        //   부호를 유지한 채(음수는 뒤로 이동) 감속하도록 하기 위함입니다.
        // - 이전 검사(carSpeed <= 0.005f)는 음수값을 즉시 정지로 간주하므로 뒤로 가는 동작이 불가능했습니다.
        // - 이 조건은 속도의 "크기"(절대값)가 충분히 작아지면 정지시키고, 그렇지 않으면 기존 부호를 유지하며 감속시킵니다.
        if (Mathf.Abs(carSpeed) <= 0.005f)
        {
            carSpeed = 0f;
        }
        else
        {
            carSpeed *= 0.98f;
        }
    }
}

