using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : MonoBehaviour
{
    public Animator EnemyAnimator;
    public Scrollbar EnemyHealthBar;
    public Scrollbar PlayerHealthBar;
    public Transform PlayerTransform;
    public float Damage;
    public GameManager _GamaManager;
   
  //Buyuk dusmana Oyuncunun Yumrugu geldigi zaman Dusmanin can�n� oyuncunun buyuklugu kadar azalt ve 0.5 san�ye sonra kars�l�k ver.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand")
        {
            Invoke("FightToPlayer",0.5f);
            EnemyHealthBar.size = EnemyHealthBar.size - Damage;
        }
       
    }
    //kars�lk verme animasyonunu cal�st�r oyuncunun can�n� biraz azalt;
    public void FightToPlayer()
    {
        EnemyAnimator.SetTrigger("Fight");
        PlayerHealthBar.size = PlayerHealthBar.size - 0.1f;
    }


  
    void Update()
    {
        // oyucunun vurus gucu onun buyuklugune esitle
       Damage = PlayerTransform.localScale.x;
        // eger oyuncunun can� 0 oldu ise oyun yoneticisinde game over ekranini acmayi calistir
        if (PlayerHealthBar.size <= 0)
        {

            _GamaManager.OpenGameOverUi();
            Debug.Log("gama over");

        }
        // eger dusmanin cani 0 ise oyun yoneticisinde kazanma ekranini acmayi calistir
        if (EnemyHealthBar.size <= 0)
        {
            _GamaManager.OpenWinnerUi();
            Debug.Log("winner");
        }
    }
}
