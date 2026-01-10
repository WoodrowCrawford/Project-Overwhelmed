using Unity.VisualScripting;
using UnityEngine;

public class OrbSpawnerBehavior : MonoBehaviour
{

    public delegate void OrbCounterEventHandler();
    public static event OrbCounterEventHandler OnDestroyDarkThought;
    public static event OrbCounterEventHandler OnCollectedAllOrbs;

    //first get a list of all the orbs
    [SerializeField] private Transform[] orbSpawnPoints;

    //a reference to the orb prefab
    [SerializeField] private GameObject orb;

    [SerializeField] private int orbCounter;

    [SerializeField] private bool collected2orbs = false;
    [SerializeField] private bool collected4orbs = false;
    [SerializeField] private bool collected6orbs = false;
    [SerializeField] private bool collected8orbs = false;
    [SerializeField] private bool collected10orbs = false;
    [SerializeField] private bool collected12orbs = false;


    void OnEnable()
    {
        OrbBehavior.OnOrbCollected += HandleOrbCollected;
    }

    void OnDisable()
    {
        OrbBehavior.OnOrbCollected -= HandleOrbCollected;
    }

    private void HandleOrbCollected()
    {
        orbCounter++;
    }

    void Start()
    {
        //on start find all the spawn points that is a child of this object and set it
        foreach (Transform child in transform)
        {
            if (child.CompareTag("OrbSpawnPoint"))
            {
                orbSpawnPoints = GetComponentsInChildren<Transform>();
                break;
            }
        }


        SpawnOrb();
    }


    void Update()
    {
        if(orbCounter == 2 && !collected2orbs)
        {
           OnDestroyDarkThought?.Invoke();
           collected2orbs = true;
        }

        else if(orbCounter == 4 && !collected4orbs)
        {
            OnDestroyDarkThought?.Invoke();
            collected4orbs = true;
        }   

        else if(orbCounter == 6 && !collected6orbs)
        {
            OnDestroyDarkThought?.Invoke();
            collected6orbs = true;
        }

         else if(orbCounter == 8 && !collected8orbs)
        {
            OnDestroyDarkThought?.Invoke();
            collected8orbs = true;
        }

        else if(orbCounter == 10 && !collected10orbs)
         {
               OnDestroyDarkThought?.Invoke();
               collected10orbs = true;
         }

         else if(orbCounter == 12 && !collected12orbs)
         {
                OnDestroyDarkThought?.Invoke();
                collected12orbs = true;
                OnCollectedAllOrbs?.Invoke();
         }


    }


    public void SpawnOrb()
    {
        //spawn an orb at a random spawn point
        int randomIndex = Random.Range(0, orbSpawnPoints.Length);
        Instantiate(orb, orbSpawnPoints[randomIndex].position, Quaternion.identity);

        float randomTime = Random.Range(6f, 12f);
        Invoke("SpawnOrb", randomTime);
    }


    public void Test()
    {
        Debug.Log("Test");
    }
}
