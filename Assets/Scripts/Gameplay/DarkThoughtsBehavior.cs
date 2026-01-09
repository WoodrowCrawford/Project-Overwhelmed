using UnityEngine;
public class DarkThoughtsBehavior : MonoBehaviour
{
    public delegate void DarkThoughtEventHandler();
    public static event DarkThoughtEventHandler OnDarkThoughtHitPlayer;

    public delegate void DarkThoughtTeleporterEventHandler(GameObject darkThought, GameObject teleporter);

    public static event DarkThoughtTeleporterEventHandler OnDarkThoughtTeleporterHit;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float driftSpeed = 2f;           // base forward speed
    [SerializeField] private float wobbleAmplitude = 0.5f;    // lateral sway strength
    [SerializeField] private float wobbleFrequency = 1.5f;    // sway frequency (Hz)
    [SerializeField] private float rotationSpeed = 120f;      // degrees per second
    [SerializeField] private float teleportCooldown = 0.1f;   // simple debounce to avoid ping-pong

    private Vector2 baseDirection;
    private float startTime;
    private float nextTeleportTime;

    private const float MinVelocitySqr = 0.0001f;



    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time < nextTeleportTime) return;

        if(collision.CompareTag("Player"))
        {
            //fire an event that the game is over and the player has lost
            OnDarkThoughtHitPlayer?.Invoke();
        }

        else if (collision.CompareTag("Teleporter1"))
        {
            nextTeleportTime = Time.time + teleportCooldown;
            OnDarkThoughtTeleporterHit?.Invoke(gameObject, collision.gameObject );
        }

        else if (collision.CompareTag("Teleporter2"))
        {
            nextTeleportTime = Time.time + teleportCooldown;
            OnDarkThoughtTeleporterHit?.Invoke(gameObject, collision.gameObject );
        }

        else if (collision.CompareTag("Teleporter3"))
        {
            nextTeleportTime = Time.time + teleportCooldown;
            OnDarkThoughtTeleporterHit?.Invoke(gameObject, collision.gameObject);
        }

        else if (collision.CompareTag("Teleporter4"))
        {
            nextTeleportTime = Time.time + teleportCooldown;
            OnDarkThoughtTeleporterHit?.Invoke(gameObject, collision.gameObject);
        }
    }

    public void ResetVelocity()
    {
        // Reapply constant drift after teleport
        rb.linearVelocity = baseDirection * driftSpeed;
        rb.angularVelocity = rotationSpeed;
    }


    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;

        // Pick a random forward direction and set initial velocity for a "meteor drift"
        baseDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.linearVelocity = baseDirection * driftSpeed;

        // Add spin
        rb.angularVelocity = rotationSpeed;
    }

    void FixedUpdate()
    {
        // Lateral wobble perpendicular to base direction for a drifting effect
        Vector2 perp = new Vector2(-baseDirection.y, baseDirection.x);
        float t = Time.time - startTime;
        float wobble = Mathf.Sin(t * (Mathf.PI * 2f) * wobbleFrequency) * wobbleAmplitude;
        rb.AddForce(perp * wobble, ForceMode2D.Force);

        // Keep speed constant so it doesn't ramp up across teleports
        Vector2 v = rb.linearVelocity;
        if (v.sqrMagnitude > MinVelocitySqr)
        {
            rb.linearVelocity = v.normalized * driftSpeed;
        }
        else
        {
            rb.linearVelocity = baseDirection * driftSpeed;
        }
    }
}
