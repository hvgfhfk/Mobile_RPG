using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPad : MonoBehaviour
{
    // touchpad 오브젝트를 연결
    private RectTransform _touchPad;

    // 터치 입력 중에 방향 컨트롤러의 영역 안에 있는 입력을 구분하기 위한 아이디
    private int _touchId = -1;

    // 입력이 시작되는 좌표
    private Vector3 _startPos = Vector3.zero;

    // 방향 컨트롤러가 원으로 움직이는 반지름
    public float _dragRadius = 0.0f;

    // 플레이어의 움직임을 관리하는 playermovement 스크립트와 연결하며 방향키가 변경되면 캐릭터에게 신호를 보냄
    public PlayerMovement _player;

    // 버튼이 눌러졌는지 체크
    private bool _buttonPressed = false;

    private void Start()
    {
        // 터치패드의 RectTransform 오브젝트를 가져옴
        _touchPad = GetComponent<RectTransform>();

        // 터치패드의 좌표를 가져옴(움직임 = 기준값)
        _startPos = _touchPad.position;

        // 상하좌우로 움직이는 원의 반지름
        _dragRadius = 60f;
    }

    public void ButtonDown()
    {
        // 버튼이 눌러졌는지 확인
        _buttonPressed = true;
    }

    public void ButtonUp()
    {
        _buttonPressed = false;

        // 버튼이 떨어졌을 경우 터치 패드와 좌표를 원래 지점으로 이동
        HandleInput(_startPos);
    }

    private void FixedUpdate()
    {
        HandleTouchInput();

        // 모바일이 아닌 pc 유니티 에디터 상에서 터치 입력이 아닌 마우스로 입력받기
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
        HandleInput(Input.mousePosition);
#endif
    }

    void HandleTouchInput()
    {
        // 터치 아이디를 매기기 위한 번호
        int i = 0;

        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                // 터치 입력을 하나씩 조회
                i++;
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);

                if(touch.phase == TouchPhase.Began)
                // 터치 입력이 방금 시작되었거나 Began 이면
                {
                    if(touch.position.x <= (_startPos.x + _dragRadius))
                    {
                        // 터치 좌표가 현재 방향키 범위 내에 있다면
                        _touchId = i; 
                    }
                }

                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    // 터치 아이디로 지정된 경우
                    if(_touchId == i)
                    {
                        HandleInput(touchPos);
                    }
                }

                // 터치 입력이 끝났는데
                if(touch.phase == TouchPhase.Ended)
                {
                    // 입력받고자 했던 터치 아이디일 경우
                    if(_touchId == i)
                    {
                        // 터치아이디 해제
                        _touchId = -1;
                    }
                }
            }
        }
    }

    void HandleInput(Vector3 input)
    {
        if(_buttonPressed)
        { // 버튼이 눌러진 상황이면
            //방향 컨트롤러의 기준 좌표로부터 얼마나 떨어져있는지 확인
            Vector3 diffVector = (input - _startPos);

            // 입력 지점과 기준 좌표의 거리를 비교
            if(diffVector.sqrMagnitude > _dragRadius * _dragRadius)
            {
                // 방향 벡터의 거리를 1
                diffVector.Normalize();
                // 방향 컨트롤러는 최대치만큼만 움직이게 하기
                _touchPad.position = _startPos + diffVector * _dragRadius;
            }
            else // 입력 지점과 기준 좌표가 최대치보다 크지 않다면
            {
                // 현재 입력 좌표를 방향키로 이동
                _touchPad.position = input;
            }
        }
        else
        {
            // 버튼에서 손이 떼어지면 방향키를 원래 위치로 되돌리기
            _touchPad.position = _startPos;
        }

        // 방향키와 기준 지점의 차이 구하기
        Vector3 diff = _touchPad.position - _startPos;

        // 방향키의 방향을 유지한 채로 거리를 나누어 방향만 구하기
        Vector2 normDiff = new Vector3(diff.x / _dragRadius, diff.y / _dragRadius);

        if(_player != null)
        {
            // 플레이어가 연결되어 있으면, 플레이어에게 변경된 좌표를 전달해줌
            _player.onStickChanged(normDiff);
        }
    }
}