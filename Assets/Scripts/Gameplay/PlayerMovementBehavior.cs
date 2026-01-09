using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    [Header("Player Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite sprintSprite;

    [Header("Movement Settings")]
    
    [SerializeField] private float moveSpeed = 5f;
    

    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Sprint.performed += IncreaseSpeed; // Example: Hold sprint to increase speed
        inputActions.Player.Sprint.canceled += SetToNormalSpeed; // Reset speed when sprint is released
        DarkThoughtsBehavior.OnDarkThoughtHitPlayer += DestroyPlayer;
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
        inputActions.Player.Sprint.performed -= IncreaseSpeed;
        inputActions.Player.Sprint.canceled -= SetToNormalSpeed;
        DarkThoughtsBehavior.OnDarkThoughtHitPlayer -= DestroyPlayer;
    }

    void Start()
    {
        //set the initial sprite to normal
        if (normalSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
    }

    public void Update()
    {
        // Read mouse position from the new Input System and debug it
        if (Mouse.current == null)
        {
            Debug.LogWarning("Input System mouse not available. Check Project Settings > Player > Active Input Handling.");
            return;
        }

        Vector2 screenPos = Mouse.current.position.ReadValue();
        Camera cam = Camera.main;

        if (cam != null)
        {
            float planeDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, planeDistance));
            worldPos.z = transform.position.z;
            
            // Drive movement toward mouse world position each frame
            MoveTowards(worldPos);
        }
        else
        {
            Debug.Log($"Mouse (screen): {screenPos} | (world): N/A - no Camera.main");
        }
    }

    public void MoveTowards()
    {
        // Deprecated path kept for API compatibility; uses current mouse position
        if (Mouse.current == null || Camera.main == null) return;
        Vector2 screenPos = Mouse.current.position.ReadValue();
        float planeDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 targetWorld = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, planeDistance));
        targetWorld.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetWorld, moveSpeed * Time.deltaTime);
        
    }

    // Overload accepting a world target for direct control
    public void MoveTowards(Vector3 targetWorld)
    {
        targetWorld.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetWorld, moveSpeed * Time.deltaTime);
    }


    public void IncreaseSpeed(InputAction.CallbackContext context)
    {
        moveSpeed = 10f; // Example sprint speed

        //change sprite to sprinting sprite if available
        if (sprintSprite != null)        
        {
            GetComponent<SpriteRenderer>().sprite = sprintSprite;
        }
    }

    public void SetToNormalSpeed(InputAction.CallbackContext context)
    {
        moveSpeed = 5f; // Reset to normal speed

        //change sprite back to normal if available
        if (normalSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
