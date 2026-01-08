using UnityEngine;

public class OrbSpawnerBehavior : MonoBehaviour
{
    //first get a list of all the orbs
    [SerializeField] private Transform[] orbSpawnPoints;

    //a reference to the orb prefab
    [SerializeField] private GameObject orb;


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


    public void SpawnOrb()
    {

       
        //spawn an orb at a random spawn point
        int randomIndex = Random.Range(0, orbSpawnPoints.Length);
        Instantiate(orb, orbSpawnPoints[randomIndex].position, Quaternion.identity);

        float randomTime = Random.Range(6f, 12f);
        Invoke("SpawnOrb", randomTime);
    }
}
