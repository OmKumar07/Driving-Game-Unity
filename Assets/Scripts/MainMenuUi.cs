using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuUi : MonoBehaviour
{
    public Text TotalCoin;
    public Text TotalKeys;
    public Text GraphicsText;
    public GameObject MusicOnButton;
    public GameObject MusicOffButton;
    public Slider SensitivitySlider;

    public GameObject SettingMEnu;
    public GameObject HighScoreMenu;
    public Text RecordHolderName;
    public Text HighScore;
    public bool MainMenu;

    public GameObject WelcomeMenu;
    public InputField Name;
    public InputField Code;
    public GameObject CodeAplied;
    public GameObject InvalidCode;
    public Text PlayerName;

    public GameObject SteeringMenu;
    public Button FullScreenButton;
    public Button ButtonControlsButton;
    public Text FullScreenButtonText;
    public Text ButtonControlsButtonText;

    public GameObject LoadingScreen;


    IEnumerator Loading()
    {
        yield return new WaitForSeconds(4);
        LoadingScreen.SetActive(false);
        
    }
    IEnumerator CarselectMenu()
    {
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);


    }
    IEnumerator StartGameMenu()
    {
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);


    }
    private void Awake()
    {
        
        if (MainMenu == true)
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                MusicOnButton.SetActive(true);
                MusicOffButton.SetActive(false);
            }
            else
            {
                MusicOffButton.SetActive(true);
                MusicOnButton.SetActive(false);
            }
                
        }
    }
    private void Start()
    {
        
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
        if (PlayerPrefs.GetInt("FirstTime") != 0&MainMenu == true)
        {
            WelcomeMenu.SetActive(false);

            SensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");

        }
        if(MainMenu == true)
        {
            StartCoroutine(Loading());
            if (PlayerPrefs.GetInt("Control") == 1)
            {
                buttonsControl();
            }
            if (PlayerPrefs.GetInt("Control") == 0)
            {
                FullScreenControl();
            }
            PlayerName.text = PlayerPrefs.GetString("PlayerName");
            SSTools.ShowMessage("DEVELOPED BY OM KUMAR", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }
    public void musicOnButton()
    {
        
        PlayerPrefs.SetInt("Music", 1);
        print("a");
        MusicOffButton.SetActive(true);
        MusicOnButton.SetActive(false);
        
        
    }
    public void musicOffButton()
    {
        PlayerPrefs.SetInt("Music", 0);
        MusicOnButton.SetActive(true);
        MusicOffButton.SetActive(false);
       
        
            print("b");
        
    }
    private void FixedUpdate()
    {
        
        TotalCoin.text = PlayerPrefs.GetInt("TotalCoin").ToString("0");
        TotalKeys.text = PlayerPrefs.GetFloat("TotalKeys").ToString("0");
        PlayerPrefs.SetInt("Quality", QualitySettings.GetQualityLevel());
        if(MainMenu == true)
        {

            if (PlayerPrefs.GetInt("FirstTime") == 0)
            {
                FullScreenControl();
                WelcomeMenu.SetActive(true);
                PlayerPrefs.SetFloat("Sensitivity", 0.5f);
            }
            PlayerPrefs.SetFloat("Sensitivity", SensitivitySlider.value);
            HighScore.text = PlayerPrefs.GetFloat("HighScore").ToString("00");
            RecordHolderName.text = PlayerPrefs.GetString("HighScorePerson");
            
        }
        
        

    }
    public void SteeringControls()
    {
        SteeringMenu.SetActive(true);
        SettingMEnu.SetActive(false);
    }
    public void buttonsControl()
    {
        ButtonControlsButton.image.color = Color.yellow;
        PlayerPrefs.SetInt("Control", 1);
        FullScreenButton.image.color = Color.white;
        ButtonControlsButtonText.text = "SELECTED";
        FullScreenButtonText.text = "SELECT";
    }
    public void FullScreenControl()
    {
        FullScreenButton.image.color = Color.yellow;
        ButtonControlsButton.image.color = Color.white;
        PlayerPrefs.SetInt("Control", 0);
        FullScreenButtonText.text = "SELECTED";
        ButtonControlsButtonText.text = "SELECT";
    }
    public void SteeringControlsClose()
    {
        SteeringMenu.SetActive(false);
        SettingMEnu.SetActive(true);
    }
    public void WelcomeOkButton()
    {
        WelcomeMenu.SetActive(false);
        
        if (Name.text == "")
        {
            print("EnterYourName");
            Handheld.Vibrate();
        }
        else
        {
            if (Code.text == "OM07")
            {
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") + 2500);
                PlayerPrefs.SetFloat("TotalKeys", PlayerPrefs.GetFloat("TotalKeys") + 25);
                CodeAplied.SetActive(true);
                PlayerPrefs.SetString("PlayerName", Name.text);
                PlayerPrefs.SetInt("FirstTime", 1);
            }
            else
            {
                InvalidCode.SetActive(true);
                Handheld.Vibrate();
            }
                
                
            
            
        }
            

        
    }
    public void GreatButton()
    {
        CodeAplied.SetActive(false);
    }
    public void invalidcodeClose()
    {
        InvalidCode.SetActive(false);
        WelcomeMenu.SetActive(true);
    }
    public void HighScoreButton()
    {
        HighScoreMenu.SetActive(true);
    }
    public void HighScoreButtonClose()
    {
        HighScoreMenu.SetActive(false);
    }
    public void StartGAmeMAinMenu()
    {
        StartCoroutine(CarselectMenu());
    }
    public void StartGame()
    {

        StartCoroutine(StartGameMenu());
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeGraphics()
    {
        if(PlayerPrefs.GetInt("Quality") == 0)
        {
            QualitySettings.SetQualityLevel(1);
            GraphicsText.text = "MED";
            GraphicsText.color = Color.white;
            print(QualitySettings.GetQualityLevel());
        }
        if (PlayerPrefs.GetInt("Quality") == 1)
        {
            QualitySettings.SetQualityLevel(2);
            GraphicsText.text = "HIGH";
            GraphicsText.color = Color.yellow;
            print(QualitySettings.GetQualityLevel());
        }
        if (PlayerPrefs.GetInt("Quality") == 2)
        {
            QualitySettings.SetQualityLevel(0);
            GraphicsText.text = "LOW";
            GraphicsText.color = Color.white;
            print(QualitySettings.GetQualityLevel());
        }
    }
    public void SettingButton()
    {
        SettingMEnu.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingMEnu.SetActive(false);
    }
}
