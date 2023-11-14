using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawn : MonoBehaviour
{
    public Transform Player;
    public GameObject Coin;
    public float SpawnTime;
    public float XDist = 0;
    public float YDist = 0;
    public float ZDist = 20;
    public int TotalCoin;
    private void FixedUpdate()
    {
        ZDist += Random.Range(1, 20);
        ZDist = Mathf.Clamp(ZDist,ZDist, Player.position.z + 150);
        SpawnTime = Random.Range(2,5);
        XDist = Random.Range(1, 3);
        TotalCoin = transform.childCount;
        StartCoroutine(DestroyCoin());
    }
    public void Start()
    {
        StartCoroutine(SpawnObsticle());
    }

    public void Spawn()
    {
        if (transform.childCount <= 200)
        {
            Vector3 SpawnDist = new Vector3(Player.position.x + XDist, Player.position.y + YDist, Player.position.z + ZDist);
            Instantiate(Coin, SpawnDist, Coin.transform.rotation, transform);
            StartCoroutine(SpawnObsticle());
        }
        
    }
    IEnumerator SpawnObsticle()
    {
        yield return new WaitForSeconds(SpawnTime);
        Spawn();
    }
    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(20);
        if (transform.childCount >= 50)
        {
            yield return new WaitForSeconds(20);
            if (transform.childCount >= 50)
            {
                yield return new WaitForSeconds(2);
                Destroy(transform.GetChild(0).gameObject);
                Debug.Log("Deleted");
            }
            
            
        }
        
    }
    
}
