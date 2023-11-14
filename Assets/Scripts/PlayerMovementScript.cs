using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovementScript : MonoBehaviour
{
    public float Sensivity;
    public float Acceleration;
    public Rigidbody rb;
    public float TopSpeed;
    public Camera cam;
    public Vector3 breakPower;
    public float topSpeed2;
    public GameOver game;
    [Space]
    public bool MainMenu = false;

    //Touch Controls
    private bool LeftButton;
    private bool RightButton;

    public LevelManager Levelmanager;
    
    void Start()
    {
        Sensivity = PlayerPrefs.GetFloat("Sensitivity");
        if (MainMenu == true)
        {
            transform.GetChild(UnityEngine.Random.Range(0,7)).gameObject.SetActive(true);
        }
        if(MainMenu == false)
        {
            transform.GetChild(PlayerPrefs.GetInt("SelectedCar")).gameObject.SetActive(true);
        }
    }


    private void FixedUpdate()
    {
        TopSpeed += 0.01f * Time.deltaTime*Acceleration;
        cam.fieldOfView = 50 + rb.velocity.z/2+Time.deltaTime*10;
        
        if(MainMenu == true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(transform.position.y >= 1f & MainMenu == false)
        {
            Levelmanager.Respawn();
        }
        



    }
    IEnumerator Break()
    {
        
            
            rb.velocity -= breakPower * Time.deltaTime * 10;
            yield return new WaitForSeconds(1.2f);
        LeftButton = false;
        RightButton = false;

    }
    void Update()
    {

        topSpeed2 = TopSpeed;
        topSpeed2 = Mathf.Clamp(topSpeed2, topSpeed2, 10);
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(Vector3.up * PlayerPrefs.GetFloat("Sensitivity")  * topSpeed2*Time.deltaTime*100);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(-Vector3.up * PlayerPrefs.GetFloat("Sensitivity") * topSpeed2 * Time.deltaTime*100);
            
        }

        if (RightButton == true)
        {
            rb.AddRelativeTorque(Vector3.up * PlayerPrefs.GetFloat("Sensitivity") * topSpeed2 * Time.deltaTime * 100);
        }

        if (LeftButton == true)
        {
            rb.AddRelativeTorque(-Vector3.up * PlayerPrefs.GetFloat("Sensitivity") * topSpeed2 * Time.deltaTime * 100);

        }
        if (Input.GetKey(KeyCode.Space)&rb.velocity.z>=2)
        {
            StartCoroutine(Break());
        }
        else
        {
            rb.AddForce(0, 0, Vector3.forward.z * Acceleration * 10);
        }
        if (RightButton == true&LeftButton==true)
        {
            StartCoroutine(Break());
        }
        else
        {
            rb.AddForce(0, 0, Vector3.forward.z * Acceleration * 10*Time.deltaTime*100);
        }

        //rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z * Acceleration * 10));


        rb.velocity = Vector3.ClampMagnitude(rb.velocity, TopSpeed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 15);

        rb.AddForce(Vector3.down * 5);
    }
    
    public void Left()
    {
        LeftButton = true;
    }
    public void Right()
    {
        RightButton = true;
    }
    public void LeftUp()
    {
        LeftButton = false;
    }
    public void RightUp()
    {
        RightButton = false;
    }
    public void BreakButtonDown()
    {
        RightButton = true;
        LeftButton = true;
    }
    public void BreakButtonUp()
    {
        LeftButton = false;
        RightButton = false;
    }
}
