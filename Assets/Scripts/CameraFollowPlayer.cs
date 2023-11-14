using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform Player;
    public Vector3 Dist;
    public Vector3 Dist2;
    public float smoothing;
    public bool Follow1;
    public bool follow2;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Follow1 == true)
        {
            transform.position = Vector3.Lerp(transform.position, Player.position, smoothing) + Dist;
        }
        if(follow2 == true)
        {
            Vector3 DesiredPos = Player.position + Dist2;
            Vector3 smooth = Vector3.Lerp(transform.position, DesiredPos, smoothing);
            transform.position = smooth;
        }
        
        
        
        
    }
    private void Update()
    {
        transform.LookAt(Player);
    }
}
