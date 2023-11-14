using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitch : MonoBehaviour
{
    public int selectedCar = 0;
    private int selected;
    // Start is called before the first frame update
    void Start()

    {
        Selectweapon();
        
        
    }

    public void nextCar()
    {
        if (selectedCar >= transform.childCount - 1)
            selectedCar = 0;
        else
            selectedCar++;
        if (selected != selectedCar)
        {
            StartCoroutine(Selectweapon());


        }

    }
    public void PRevCar()
    {
        if (selectedCar <= 0)
            selectedCar = transform.childCount - 1;
        else
            selectedCar--;
        if (selected != selectedCar)
        {
            StartCoroutine(Selectweapon());


        }
    }
    void Update()

    {


       

        int Previousselectedweapon = selectedCar;
        selected = Previousselectedweapon;
        

        if (Previousselectedweapon != selectedCar)
        {
            StartCoroutine(Selectweapon());


        }
    }

    IEnumerator Selectweapon()
    {
        yield return new WaitForSeconds(0f);
        int i = 0;


        foreach (Transform weapon in transform)
        {
            if (i == selectedCar)
                weapon.gameObject.SetActive(true);

            else
            {
                weapon.gameObject.SetActive(false);
            }
                

            i++;
        }
    }
}
