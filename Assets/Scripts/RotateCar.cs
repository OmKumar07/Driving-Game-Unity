using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCar : MonoBehaviour
{
    [Range(0, 5)]
    public float Speed;
    private void OnEnable()
    {
        
        transform.localPosition = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(-5, 5, 5);
    }
    void Update()
    {
        Rigidbody a = transform.GetComponent<Rigidbody>();
        a.AddForce(0, -1, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 40f, 0f),Speed*Time.deltaTime);
    }
}
