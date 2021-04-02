using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=0;
    public Transform ControlPoint;
    public Animator PlayerAnimator;
    public GameObject AfterFinishUi;
    
    public int ColorCode;  // renk kodu 0= mavi ,renk kodu 1= kirmizi, renk kodu 2= yesil

   // oyunun baslangicinda bitisden sonraki dovus ekranlarini kapat
    void Start()
    {
        AfterFinishUi.SetActive(false);
        ColorCode = 0;
    }
    // oyuncunun carpmalari

    private void OnTriggerEnter(Collider other)
    {
        // oyuncu mavi dusmana carptiginde 
        if (other.gameObject.tag == "Blue")
        {
            // renk kodu 0 ise ve oyuncunun buyuklugu cok belirli bir miktarin ustunde ise oyuncuyu buyut renk kodu 0 degil ise belirli miktara kadar kucult
            if (ColorCode == 0)
            {
                Debug.Log("Mavi dusmana carpti");
                if (transform.localScale.x <= 0.12f)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f, transform.localScale.z + 0.005f);
                }
            }
            
            if (ColorCode == 1 || ColorCode == 2)
            {
                Debug.Log("Mavi dusmana carpti");
                if (transform.localScale.x >= 0.05f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);
                }
            }
        }
        // oyuncu kirmizi dusmana carptiginde
        if (other.gameObject.tag == "Red")
        {
            // renk kodu 1 ise ve oyuncunun buyuklugu cok belirli bir miktarin ustunde ise oyuncuyu buyut renk kodu 1 degil ise belirli miktara kadar kucult
            if (ColorCode == 1)
            {
                Debug.Log("Mavi dusmana carpti");
                if (transform.localScale.x <= 0.12f)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f, transform.localScale.z + 0.005f);
                }
            }
            if (ColorCode == 0 || ColorCode == 2)
            {
                Debug.Log("Mavi dusmana carpti");
                if (transform.localScale.x >= 0.05f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);
                }
            }
        }
        // oyuncu yesil dusmana carptiginde
        if (other.gameObject.tag == "Green")
        {
            // renk kodu 2 ise ve oyuncunun buyuklugu cok belirli bir miktarin ustunde ise oyuncuyu buyut renk kodu 2 degil ise belirli miktara kadar kucult
            if (ColorCode == 2)
            {
                Debug.Log("Mavi dusmana carpti");
                if (transform.localScale.x <= 0.12f)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f, transform.localScale.z + 0.005f);
                }
            }
            if (ColorCode == 0 || ColorCode == 1)
            {
                Debug.Log("Mavi dusmana carpti");
                if (transform.localScale.x >= 0.05f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);
                }
            }
        }
        // oyuncu yesil portala carptiginda oyuncunun yesil olma animasyonunu calistir renk kodunu 2 yap
        if (other.gameObject.tag == "GreenPortal")
        {
            ColorCode = 2;
            PlayerAnimator.SetTrigger("GreenRun");
        }
        // oyuncu mavi portala carptiginda oyuncunun mavi olma animasyonunu calistir renk kodunu 0 yap
        if (other.gameObject.tag == "BluePortal")
        {
            PlayerAnimator.SetTrigger("BlueRun");
            ColorCode = 0;
        }
        // oyuncu Kirmizi portala carptiginda oyuncunun yesil olma animasyonunu calistir renk kodunu 2 yap
        if (other.gameObject.tag == "RedPortal")
        {
            PlayerAnimator.SetTrigger("RedRun");
            ColorCode = 1;
        }  
        // oyuncu bitis noktasina carptiginda bitisten sonraki dovus ekranini , animasyonunu calistir ve hizini durdur
        if (other.gameObject.tag == "Finish")
        {
            AfterFinishUi.SetActive(true);
            PlayerAnimator.SetTrigger("FinishGame");
            speed = 0;
        }


    }
    // oyuncu yumruk atma tusuna bastiginda yumruk at animasyonunu calistir
    public void FightButton()
    {
        PlayerAnimator.SetTrigger("Fight");
    }
    //oyuncu hiz degerinde gore hareket etsin ve kontrol noktasýný x vektorunde takip etsin
    void Update()
    {
       transform.Translate(0, 0, speed*Time.deltaTime);
        transform.position = new Vector3(ControlPoint.position.x, transform.position.y, transform.position.z);
    }
}
