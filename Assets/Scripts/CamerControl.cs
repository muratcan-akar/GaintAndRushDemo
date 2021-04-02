using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    public Transform PlayerTransform;
  //Oyuncuyu Z ekseninde belirli bir mesafe ile takip et
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, PlayerTransform.position.z-7);  
    }
}
