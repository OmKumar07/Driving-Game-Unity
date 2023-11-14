using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Transform Player;
    public float Mainscore;
    void Start()
    {
       
    }

    // Update is called once per frame
   public void Update()
    {
        if (Player.position.z >= 0 & PlayerPrefs.GetInt("SelectedCar") != 6)
        {
            float score = Player.position.z/2;
            ScoreText.text = score.ToString("000");
            Mainscore = score;
        }
        if(Player.position.z >=0 & PlayerPrefs.GetInt("SelectedCar") == 6)
        {
            float score = Player.position.z;
            ScoreText.text = score.ToString("000");
            Mainscore = score;
        }
         
    }
}
