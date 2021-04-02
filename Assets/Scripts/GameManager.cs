using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator PlayerAnimator;
    public Player _Player;
    public GameObject StartButon,GameOverUi,WinnerUi;
    public bool FinishGame=false;
    //baslnagicta ui ekranlarini gosterme
    void Start()
    {
        WinnerUi.SetActive(false);
        GameOverUi.SetActive(false);
        StartButon.SetActive(true);
    }
    // start butona basildiginda oyuncunun kosma animasyonu calistir oyuncuya hiz ver start butonunu gosterme 
    public void StartButton()
    {
        
        _Player.speed = 10;
        PlayerAnimator.SetTrigger("BlueRun");
        StartButon.SetActive(false);
    }
    // Oyunu yeniden baslat
    public void RestratButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //eger oyun bitmedi ise kaybetme ekranini calistirve oyunu bitir
    public void OpenGameOverUi()
    {

        if (!FinishGame)
        {
            GameOverUi.SetActive(true);
            FinishGame = true;
        }
    }// eger oyun bitmedi ise kazanma ekranini calistir ve oyunu bitir
    public void OpenWinnerUi()
    {
        if (!FinishGame)
        {
            WinnerUi.SetActive(true);
            FinishGame = true;
        }
        
       
    }



}
