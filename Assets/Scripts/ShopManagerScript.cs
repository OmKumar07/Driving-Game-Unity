using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public GameObject PriceButton;
    public GameObject Locked;
    public GameObject Unlocked;
    public GameObject LockedUi;
    public GameObject NotEnoughCoin;

    public Text PriceTExt;
    public CarSwitch CarChangeScript;

    public int[] CarPrice;


    public bool Car1Purchased;
    public bool Car2Purchased;
    private bool Car3Purchased;
    private bool Car4Purchased;
    private bool Car5Purchased;
    private bool Car6Purchased;
    private bool Car7Purchased;

    public int CarsOwned;
    public GameObject DoubleScore;
    public GameObject DoubleCoin;
    public GameObject DoubleKeys;
    void Start()
    {
        
        CarsOwned = PlayerPrefs.GetInt("Cars");
        PlayerPrefs.SetInt("SelectedCar", 0);
        
    }

    public void PurchaseButton()
    {
        if(CarChangeScript.selectedCar == 0 & Car1Purchased == false & PlayerPrefs.GetInt("Cars") == 0)
        {
            if(PlayerPrefs.GetInt("TotalCoin") >= CarPrice[0])
            {
                PlayerPrefs.SetInt("Cars", 1);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[0]);
                print("Car1Purchased");
            }
            else
            {
                NotEnoughCoin.SetActive(true);

            }

        }
        
        if (CarChangeScript.selectedCar == 1 & Car2Purchased == false & PlayerPrefs.GetInt("Cars") == 1)
        {
            if(PlayerPrefs.GetInt("TotalCoin") >= CarPrice[1])
            {
                PlayerPrefs.SetInt("Cars", 2);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[1]);
                print("Car2Purchased");
            }
            else
            {
                NotEnoughCoin.SetActive(true);

            }

        }
       
        if (CarChangeScript.selectedCar == 2 & Car3Purchased == false & PlayerPrefs.GetInt("Cars") == 2)
        {
            if(PlayerPrefs.GetInt("TotalCoin") >= CarPrice[2])
            {
                PlayerPrefs.SetInt("Cars", 3);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[2]);
                print("Car3Purchased");
            }
            else
            {
                NotEnoughCoin.SetActive(true);

            }

        }
        
        if (CarChangeScript.selectedCar == 3 & Car4Purchased == false & PlayerPrefs.GetInt("Cars") == 3)
        {
            if (PlayerPrefs.GetInt("TotalCoin") >= CarPrice[3])
            {
                PlayerPrefs.SetInt("Cars", 4);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[3]);
                print("Car4Purchased");
            }else
                NotEnoughCoin.SetActive(true);


        }

        if (CarChangeScript.selectedCar == 4 & Car5Purchased == false & PlayerPrefs.GetInt("Cars") == 4)
        {
            if(PlayerPrefs.GetInt("TotalCoin") >= CarPrice[4])
            {
                PlayerPrefs.SetInt("Cars", 5);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[4]);
                print("Car5Purchased");
            }
            else
            {
                NotEnoughCoin.SetActive(true);

            }

        }
       
        if (CarChangeScript.selectedCar == 5 & Car6Purchased == false & PlayerPrefs.GetInt("Cars") == 5)
        {
            if(PlayerPrefs.GetInt("TotalCoin") >= CarPrice[5])
            {
                PlayerPrefs.SetInt("Cars", 6);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[5]);
                print("Car6Purchased");
            }
            else
            {
                NotEnoughCoin.SetActive(true);

            }

        }
        
        if (CarChangeScript.selectedCar == 6 & Car7Purchased == false & PlayerPrefs.GetInt("Cars") == 6)
        {
            if(PlayerPrefs.GetInt("TotalCoin") >= CarPrice[6])
            {
                PlayerPrefs.SetInt("Cars", 7);
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - CarPrice[6]);
                print("Car7Purchased");
            }
            else
            {
                NotEnoughCoin.SetActive(true);

            }

        }
        

    }
    public void LockedButton()
    {
        LockedUi.SetActive(true);
        
    }
    public void Ok()
    {
        LockedUi.SetActive(false);
    }
    public void OkNoCoin()
    {
        NotEnoughCoin.SetActive(false);
    }
    void FixedUpdate()
    {
        if(CarChangeScript.selectedCar == 0&Car1Purchased == false)
        {
            PriceTExt.text = CarPrice[0].ToString("0");
            
        }
        if (CarChangeScript.selectedCar == 1&Car2Purchased == false)
        {
            PriceTExt.text = CarPrice[1].ToString("0");
        }
        if (CarChangeScript.selectedCar == 2 & Car3Purchased == false)
        {
            PriceTExt.text = CarPrice[2].ToString("0");
        }
        if (CarChangeScript.selectedCar == 3 & Car4Purchased == false)
        {
            PriceTExt.text = CarPrice[3].ToString("0");
        }
        if (CarChangeScript.selectedCar == 4 & Car5Purchased == false)
        {
            PriceTExt.text = CarPrice[4].ToString("0");
        }
        if (CarChangeScript.selectedCar == 5 & Car6Purchased == false)
        {
            PriceTExt.text = CarPrice[5].ToString("0");
            
        }
        if (CarChangeScript.selectedCar == 6 & Car7Purchased == false)
        {
            PriceTExt.text = CarPrice[6].ToString("0");
            
        }
        if (CarChangeScript.selectedCar != 6)
        {
            DoubleScore.SetActive(false);
        }
        else
        {
            DoubleScore.SetActive(true);
        }
        if (CarChangeScript.selectedCar != 4)
        {
            DoubleCoin.SetActive(false);
        }
        else
        {
            DoubleCoin.SetActive(true);
        }
        if (CarChangeScript.selectedCar != 5)
        {
            DoubleKeys.SetActive(false);
        }
        else
        {
            DoubleKeys.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Cars") == 0)
        {
            if(CarChangeScript.selectedCar == 0)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }
                

        }
        if (PlayerPrefs.GetInt("Cars") == 1)
        {
            if (CarChangeScript.selectedCar == 1)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }


        }
        if (PlayerPrefs.GetInt("Cars") == 2)
        {
            if (CarChangeScript.selectedCar == 2)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }


        }
        if (PlayerPrefs.GetInt("Cars") == 3)
        {
            if (CarChangeScript.selectedCar == 3)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }


        }
        if (PlayerPrefs.GetInt("Cars") == 4)
        {
            if (CarChangeScript.selectedCar == 4)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }


        }
        if (PlayerPrefs.GetInt("Cars") == 5)
        {
            if (CarChangeScript.selectedCar == 5)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }


        }
        if (PlayerPrefs.GetInt("Cars") == 6)
        {
            if (CarChangeScript.selectedCar == 6)
            {
                Unlocked.SetActive(true);
                Locked.SetActive(false);
            }
            else
            {
                Unlocked.SetActive(false);
                Locked.SetActive(true);
            }


        }




        if (PlayerPrefs.GetInt("Cars") >= 1)
        {
            Car1Purchased = true;
        }
        if (PlayerPrefs.GetInt("Cars") >= 2)
        {
            Car2Purchased = true;
        }
        if (PlayerPrefs.GetInt("Cars") >= 3)
        {
            Car3Purchased = true;
        }
        if (PlayerPrefs.GetInt("Cars") >= 4)
        {
            Car4Purchased = true;
        }
        if (PlayerPrefs.GetInt("Cars") >= 5)
        {
            Car5Purchased = true;
        }
        if (PlayerPrefs.GetInt("Cars") >= 6)
        {
            Car6Purchased = true;
        }
        if (PlayerPrefs.GetInt("Cars") >= 7)
        {
            Car7Purchased = true;
        }



        if (Car1Purchased==true&CarChangeScript.selectedCar == 0)
        {
            PriceButton.SetActive(false);
        }
        if (Car1Purchased == false & CarChangeScript.selectedCar == 0)
        {
            PriceButton.SetActive(true);
        }

        if (Car2Purchased == true & CarChangeScript.selectedCar == 1)
        {
            PriceButton.SetActive(false);
        }
        if (Car2Purchased == false & CarChangeScript.selectedCar == 1)
        {
            PriceButton.SetActive(true);
        }

        if (Car3Purchased == true & CarChangeScript.selectedCar == 2)
        {
            PriceButton.SetActive(false);
        }
        if (Car3Purchased == false & CarChangeScript.selectedCar == 2)
        {
            PriceButton.SetActive(true);
        }

        if (Car4Purchased == true & CarChangeScript.selectedCar == 3)
        {
            PriceButton.SetActive(false);
        }
        if (Car4Purchased == false & CarChangeScript.selectedCar == 3)
        {
            PriceButton.SetActive(true);
        }

        if (Car5Purchased == true & CarChangeScript.selectedCar == 4)
        {
            PriceButton.SetActive(false);
        }
        if (Car5Purchased == false & CarChangeScript.selectedCar == 4)
        {
            PriceButton.SetActive(true);
        }

        if (Car6Purchased == true & CarChangeScript.selectedCar == 5)
        {
            PriceButton.SetActive(false);
        }
        if (Car6Purchased == false & CarChangeScript.selectedCar == 5)
        {
            PriceButton.SetActive(true);
        }

        if (Car7Purchased == true & CarChangeScript.selectedCar == 6)
        {
            PriceButton.SetActive(false);
        }
        if (Car7Purchased == false & CarChangeScript.selectedCar == 6)
        {
            PriceButton.SetActive(true);
        }

        PlayerPrefs.SetInt("SelectedCar", CarChangeScript.selectedCar);

    }
}
