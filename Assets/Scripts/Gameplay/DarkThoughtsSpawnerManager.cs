using Unity.VisualScripting;
using UnityEngine;

public class DarkThoughtsSpawnerManager : MonoBehaviour
{
   [SerializeField] private GameObject[] darkThoughts;

    void OnEnable()
    {
        OrbSpawnerBehavior.OnDestroyDarkThought += DestroyDarkThought;
    }

    void OnDisable()
    {
        OrbSpawnerBehavior.OnDestroyDarkThought -= DestroyDarkThought;
    }


    public void Start()
    {
        //Find all the game objects with the tag "DarkThought" and add them to the list of spawn points
        darkThoughts = GameObject.FindGameObjectsWithTag("DarkThought");
    }


    public void DestroyDarkThought()
    {
        //destroy a random dark thought from the list of dark thoughts
        if (darkThoughts.Length > 0)
        {
            int randomIndex = Random.Range(0, darkThoughts.Length);
            GameObject darkThoughtToDestroy = darkThoughts[randomIndex];
            Destroy(darkThoughtToDestroy);
            //remove the destroyed dark thought from the list
            darkThoughts[randomIndex] = darkThoughts[darkThoughts.Length - 1];
            System.Array.Resize(ref darkThoughts, darkThoughts.Length - 1);
        }
    }
}
