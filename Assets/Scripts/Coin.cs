using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public LevelManager LevelManager;
    public Vector3 rotation;
    public bool Rotation = false;
    public PlayerMovementScript PlayerSpeed;
    public AudioSource CoinSound;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" & PlayerPrefs.GetInt("SelectedCar") != 4)
        {
            Destroy(transform.gameObject);
            CoinSound.Play();
            LevelManager.CoinCollected += 1;
            CoinSound.pitch += 0.02f;
            if (CoinSound.pitch > 1.5)
            {
                CoinSound.pitch = 1;
            }
        }
        if (other.gameObject.tag == "Player"&PlayerPrefs.GetInt("SelectedCar")==4)
        {
            CoinSound.Play();
            Destroy(transform.gameObject);
            LevelManager.CoinCollected += 2;
            CoinSound.pitch += 0.02f;
            if(CoinSound.pitch > 1.5)
            {
                CoinSound.pitch = 1;
            }
        }
        if (other.gameObject.tag == "Obsticle")
        {
            Destroy(transform.gameObject);
            Debug.Log("WrongSpawn");
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if(Rotation == true)
        {
            transform.Rotate(rotation*Time.deltaTime*PlayerSpeed.TopSpeed/Random.Range(4f,6f));
        }
        
    }
}
