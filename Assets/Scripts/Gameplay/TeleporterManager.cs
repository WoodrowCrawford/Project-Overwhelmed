using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    public GameObject teleporter1;
    public GameObject teleporter2;

    public GameObject teleporter3;
    public GameObject teleporter4;


    void OnEnable()
    {
        DarkThoughtsBehavior.OnDarkThoughtTeleporterHit += TeleportDarkThought;
    }

    void OnDisable()
    {
        DarkThoughtsBehavior.OnDarkThoughtTeleporterHit -= TeleportDarkThought;
    }


    public void TeleportDarkThought(GameObject darkThought, GameObject newTeleporter)
    {
        if (!darkThought || !newTeleporter) return;

        if(newTeleporter == teleporter1)
        {
            Debug.Log("Dark thought teleported by Teleporter 1!");
            darkThought.transform.position = GetRandomPointInTeleporter(teleporter2);
        }
        else if (newTeleporter == teleporter2)
        {
            Debug.Log("Dark thought teleported by Teleporter 2!");
            darkThought.transform.position = GetRandomPointInTeleporter(teleporter1);
        }
        else if (newTeleporter == teleporter3)
        {
            Debug.Log("Dark thought teleported by Teleporter 3!");
            darkThought.transform.position = GetRandomPointInTeleporter(teleporter4);
        }
        else if (newTeleporter == teleporter4)
        {
            Debug.Log("Dark thought teleported by Teleporter 4!");
            darkThought.transform.position = GetRandomPointInTeleporter(teleporter3);
        }

        ApplyPostTeleportPush(darkThought);
    }

    private void ApplyPostTeleportPush(GameObject darkThought)
    {
        var behavior = darkThought.GetComponent<DarkThoughtsBehavior>();
        if (behavior != null)
        {
            behavior.ResetVelocity();
            return;
        }

        var rb = darkThought.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Fallback: give it a small upward-biased push to avoid falling
            Vector2 dir = (Vector2.up + Random.insideUnitCircle * 0.3f).normalized;
            float speed = 2f;
            rb.linearVelocity = dir * speed;
        }
    }

    private Vector3 GetRandomPointInTeleporter(GameObject teleporter)
    {
        if (!teleporter) return Vector3.zero;

        Collider2D col = teleporter.GetComponent<Collider2D>();
        if (col != null)
        {
            Bounds b = col.bounds;
            float x = Random.Range(b.min.x, b.max.x);
            float y = Random.Range(b.min.y, b.max.y);
            return new Vector3(x, y, teleporter.transform.position.z);
        }

        // Fallback: small random offset around teleporter position
        Vector2 offset = Random.insideUnitCircle * 0.5f;
        return teleporter.transform.position + (Vector3)offset;
    }
   
}
