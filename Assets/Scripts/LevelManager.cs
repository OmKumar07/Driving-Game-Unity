using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //For Score
    public float Score;
    public Score score;


    [Space]
    //For Coins
    public int CoinCollected;
    //[HideInInspector]
    public float KeysCollected;
    public float TotalKeys;
    //[HideInInspector]
    public int TotalCoin;
    public Text CoinCount;
    [HideInInspector]
    public float BonusCoin;
    [Space]
    public Text TotalCoinText;
    public Text TotalKeysText;
  
    
    
    [Space]
    //For Ui
    public GameObject PauseMenu;
    public GameObject ReviveMenu;
    public GameObject GameoverMenu;
    private bool Ispaused = false;
    public GameOver gameOver;
    [HideInInspector]
    public bool Norevive = false;

    [Space]
    [Header("Player")]
    public Transform player;

    //For Revive
    [Space]
    public Text ReviveCostText;
    [HideInInspector]
    public float reviveCost = 1;

    //For HighScore
    [Space]
    //[HideInInspector]
    public float HighScore;
    public Text HighScoreText;
    public Slider HighScoreSlider;
    public Text YouScoreText;


    public GameObject EnterNameMenu;
    public Text HighScorerName;
    public InputField Inputfield;
    private bool REstart;
    private float high;


    public GameObject FullScreenControls;
    public GameObject ButtonControls;


    public GameObject LoadingMenu;
    public AudioSource MusicPlaying;

    private void Awake()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(1.5f);
        LoadingMenu.SetActive(false);
    }
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        high = PlayerPrefs.GetFloat("HighScore");
        if(PlayerPrefs.GetInt("Control") == 0)
        {
            FullScreenControls.SetActive(true);
            ButtonControls.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Control") == 1)
        {
            ButtonControls.SetActive(true);
            FullScreenControls.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            MusicPlaying.mute = true;
        }else
            MusicPlaying.mute = false;
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void EnterNAmeDone()
    {
        if (Inputfield.text != "")
        {
            PlayerPrefs.SetString("HighScorePerson", Inputfield.text);
            EnterNameMenu.SetActive(false);
            if (REstart == true)
            {
                SceneManager.LoadScene(2);
            }
            if (REstart == false)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
            Handheld.Vibrate();



    }
    public void RestartLevel()
    {
        REstart = true;
        Resume();
        PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin")+CoinCollected);
        PlayerPrefs.SetFloat("TotalKeys", PlayerPrefs.GetFloat("TotalKeys")+KeysCollected);
        if (score.Mainscore >= high)
        {
            print("a");
            EnterNameMenu.SetActive(true);
            HighScorerName.text = PlayerPrefs.GetString("HighScorePerson");
        }
        else
        {
            SceneManager.LoadScene(2);
        }
            
    }
    public void MainMEnuButton()
    {
        Time.timeScale = 1;
        REstart = false;
        PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") + CoinCollected);
        PlayerPrefs.SetFloat("TotalKeys", PlayerPrefs.GetFloat("TotalKeys") + KeysCollected);
        if (score.Mainscore >= high)
        {
            
            EnterNameMenu.SetActive(true);
            HighScorerName.text = PlayerPrefs.GetString("HighScorePerson");
        }
        else
        {
            SceneManager.LoadScene(0);
        }
            
    }
    public void NoRevive()
    {
        Norevive = true;
        gameOver.reviveMenu = false;
        ReviveMenu.SetActive(false);

    }
    public void Respawn()
    {
        if (PlayerPrefs.GetFloat("TotalKeys") >= reviveCost)
        {
            gameOver.Gameover = false;
            player.position = new Vector3(33.5f, player.position.y, player.position.z - 15);
            player.rotation = Quaternion.Euler(0f, 0f, 0f);
            ReviveMenu.SetActive(false);
            PlayerPrefs.SetFloat("TotalKeys", PlayerPrefs.GetFloat("TotalKeys") - reviveCost);
            reviveCost *= 2;
        }
        else
            Debug.Log("Not enough coin");
        
    }

    private void FixedUpdate()
    {
        HighScoreSlider.maxValue = PlayerPrefs.GetFloat("HighScore");
        HighScoreSlider.minValue = 0f;
        HighScoreSlider.value = score.Mainscore;
    }
    void Update()
    {
        reviveCost = Mathf.Clamp(reviveCost, 0, 64);
        if (score.Mainscore >= 150&CoinCollected>=10)
        {
            BonusCoin = CoinCollected / score.Mainscore * 100;
            BonusCoin = Mathf.Clamp(BonusCoin, 0, CoinCollected);
        }
        
        //coincount = Mathf.Lerp(coincount, CoinCollected, gameOver.LerpTime);
        CoinCount.text = CoinCollected.ToString("00");
        Score = score.Mainscore;
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
            Ispaused = true;
        }

        ReviveCostText.text = reviveCost.ToString("0");
        if(PlayerPrefs.GetInt("SelectedCar") == 5)
        {
            KeysCollected = score.Mainscore / 175;
        }
        else
        {
            KeysCollected = score.Mainscore / 350;
        }
        
        KeysCollected = Mathf.Clamp(KeysCollected, 0, Mathf.Infinity);

        if (score.Mainscore >= high)
        {
            PlayerPrefs.SetFloat("HighScore", score.Mainscore);
            YouScoreText.text = ("NEW RECORD");
            
        }
        else
            YouScoreText.text = ("YOUR SCORE");

        HighScoreText.text = HighScore.ToString("00");

        TotalCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString("00");
        TotalKeysText.text = PlayerPrefs.GetFloat("TotalKeys").ToString("00");
    }
}
