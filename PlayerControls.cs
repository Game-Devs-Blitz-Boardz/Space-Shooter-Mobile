using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{

    Camera mainCam;
    Vector3 offset;

    float maxLeft;
    float maxRight;
    float maxUp;
    float maxDown;

    void Start()
    {
        mainCam = Camera.main;

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
    }

    void Update()
    {
        if (Touch.fingers[0].isActive ) {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began) {
                offset = touchPos - transform.position;
            } else if(Touch.activeTouches[0].phase == TouchPhase.Moved || Touch.activeTouches[0].phase == TouchPhase.Stationary) {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);    
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                                             Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);
        }
    }

    void OnEnable() {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable() {
        EnhancedTouchSupport.Disable();
    }
}
