using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public LevelManager levelManagerScript;
    public GameOver GameoverScript;
    private void FixedUpdate()
    {
        levelManagerScript.TotalCoin = PlayerPrefs.GetInt("TotalCoin");
        levelManagerScript.HighScore = PlayerPrefs.GetFloat("HighScore");
        levelManagerScript.TotalKeys = PlayerPrefs.GetFloat("TotalKeys");
    }
    public void ResetAllButton()
    {
        PlayerPrefs.DeleteAll();
    }
}
