using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform target;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {


            other.transform.position = target.position;
        }
    }
}
