using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour 
{ 
  public LeftRightControl swipeControls;
  public Transform Player;

  private Vector3 desiredPosition;
    
    
    
    
    
    
   
    private void Start()
    {
        desiredPosition = Player.position;
    }   

    private void Update()
    {
        // eger kontrolde maximum hareketi asmadıysak 
        
       
        if (swipeControls.MaxMove <= 1 && swipeControls.MaxMove >= -1) {


            //kontrolden gelen hareketleri yap
            if (swipeControls.SwipeLeft)
                desiredPosition += Vector3.left * 2f;
            if (swipeControls.SwipeRight)
                desiredPosition += Vector3.right * 2f;
        }


        //kontrol na-kotasını kontrolden gelen yerlere hareket ettir

       transform.position = Vector3.MoveTowards
            (transform.position, desiredPosition, 7f * Time.deltaTime);

     

        

    }

}