using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public int threshold = 30;
    public int maxAngle = 85;
    public float speed;
    public bool freezeY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.eulerAngles.x >= threshold && transform.eulerAngles.x <= maxAngle)
        {
            Vector3 direction = transform.TransformDirection(Vector3.forward);
            player.Translate(direction * speed);
        }

        if(freezeY)
        {
            player.position = new Vector3(player.position.x, 1.7f, player.position.z);
        }
    }
}