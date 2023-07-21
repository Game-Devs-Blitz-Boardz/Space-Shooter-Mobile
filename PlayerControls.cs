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

    void Start()
    {
        mainCam = Camera.main;
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
        }
    }

    void OnEnable() {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable() {
        EnhancedTouchSupport.Disable();
    }
}
