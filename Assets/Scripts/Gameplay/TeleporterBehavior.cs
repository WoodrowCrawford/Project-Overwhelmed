using UnityEngine;

public class TeleporterBehavior : MonoBehaviour
{
    [SerializeField] private GameObject teleporter1;
    [SerializeField] private GameObject teleporter2;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DarkThought"))
        {
            Debug.Log("Dark Thought teleported!");
        }
    }
}
