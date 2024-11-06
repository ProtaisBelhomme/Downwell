using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exemple_InputPhone : MonoBehaviour
{
    public UnityEvent onTap;
    public UnityEvent secondaryTap;

    public UnityEvent<Vector2> onMove;
    public UnityEvent<Vector2Int> onSwipe;

    public float tapMaxTime = 0.5f;
    public float swipeThreshold = 50;

    private float tapTime = 0;
    private Vector2 touchStartPos;

    void Update()
    {
        if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tapTime = Time.time;
                    touchStartPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    onMove?.Invoke(touch.deltaPosition);

                    var delta = touch.position - touchStartPos;
                    if (delta.magnitude < swipeThreshold) break;

                    if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                        onSwipe?.Invoke(new Vector2Int((int)Mathf.Sign(delta.x), 0));
                    else
                        onSwipe?.Invoke(new Vector2Int(0, (int)Mathf.Sign(delta.y)));
                    break;
                case TouchPhase.Ended:
                    if (Time.time - tapTime < tapMaxTime)
                    {
                        onTap?.Invoke();
                    }
                    break;
            }

            if(Input.touchCount >= 2)
            {
                if(Input.GetTouch(1).phase == TouchPhase.Began)
                    secondaryTap?.Invoke();
            }
        }
    }
}
