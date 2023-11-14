using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public PlayerMovementScript Player;


    [Space]
    public Score score;
    public Text GameOverScore;
    private float MainScore;
    [Range(0, 5)]
    public float LerpTime = 0f;


    [Space]
    public Text CoinText;
    public Text KeyText;
    public Text BonusCoinText;
    public float TotalCoin;
    public float BonusCoin;
    public float CollectedKeys;

    [Space]
    [HideInInspector]
    public bool reviveMenu;
    public GameObject reviveUI;
    public GameObject GameoverUI;
    [HideInInspector]
    public bool Gameover;


    [Space]
    public LevelManager levelManager;
    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(5);
        if(Player.rb.velocity.z <= 3)
        {
            yield return new WaitForSeconds(1.5f);
            if (Player.rb.velocity.z <= 1)
            {


                Gameover = true;
                StartCoroutine(gameOver());

            }
            else
                Gameover = false;
           
        }else
            Gameover = false;
    }

    
    void Update()
    {
        
        if (score.Mainscore >= 50&levelManager.Norevive == false)
        {
            reviveMenu = true;
        }
        if (Gameover == true&reviveMenu == true)
        {
            reviveUI.SetActive(true);
            

        }
        else
        {
            
            reviveUI.SetActive(false);
        }
            
        if (Gameover == true&reviveMenu == false)
        {
            reviveUI.SetActive(false);
            //Score
            MainScore = Mathf.Lerp(MainScore, score.Mainscore, LerpTime * Time.deltaTime);
            GameOverScore.text = MainScore.ToString("0");
            //Currency
            TotalCoin = Mathf.Lerp(TotalCoin, levelManager.CoinCollected, LerpTime * Time.deltaTime);
            CoinText.text = TotalCoin.ToString("0");
            BonusCoin = Mathf.Lerp(BonusCoin, levelManager.BonusCoin, LerpTime * Time.deltaTime);
            BonusCoinText.text = BonusCoin.ToString("0");
            CollectedKeys = Mathf.Lerp(CollectedKeys, levelManager.KeysCollected, LerpTime * Time.deltaTime);
            KeyText.text = CollectedKeys.ToString("0");
            GameoverUI.SetActive(true);
            
            
        }
        StartCoroutine(gameOver());
       
    }
    
}
