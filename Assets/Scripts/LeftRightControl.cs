using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightControl : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    public Vector3 Playerr;
    public int MaxMove=0;
    

    
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    //Her yana kaydıgında maksimum hareketi 1 ve -1 arasinda tut
    private void Update()
    {
        if (MaxMove >= 1)
        {
           
            MaxMove = 1;
        }
        else if (MaxMove <= -1)
        {
            
            MaxMove = -1;
        }
      
            
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        // Mesafeyi hesapla
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

       
        if (swipeDelta.magnitude > 125)
        {
           
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
              // eger x vekteorunde sifirdan kucuk bir hareket yapti ise maximum hareketi bir arttır sola hareketi calistir
                    if (x < 0)
                    {
                        swipeLeft = true;
                         MaxMove++;
                     
                    
                    }
                // eger x vekteorunde sifirdanbuyuk bir hareket yapti ise maximum hareketi bir arttır saga hareketi calistir
                else
                {
                    swipeRight = true;
                    MaxMove--;

                }
            }
            
            Reset();
        }
    }

    void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
