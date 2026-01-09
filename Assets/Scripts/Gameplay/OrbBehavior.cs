using UnityEngine;
using UnityEngine.Events;

public class OrbBehavior : MonoBehaviour
{

    public delegate void OrbEventHandler();

    public static event OrbEventHandler OnOrbCollected;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //destroy the orb
            Debug.Log("Orb collected!");
            OnOrbCollected?.Invoke();

            Destroy(this.gameObject);
        }
    }
}
