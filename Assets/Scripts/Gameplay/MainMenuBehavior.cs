using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject howToPlayScreen;
    [SerializeField] private GameObject affirmationsScreen;


    void OnEnable()
    {
        MainMenuIconBehavior.OnPlaySelected += StartGame;
        MainMenuIconBehavior.OnHowToPlaySelected += ShowHowToPlayScreen;
        MainMenuIconBehavior.OnAffirmationsSelected += ShowAffirmationsScreen;
    }

    void OnDisable()
    {
        MainMenuIconBehavior.OnPlaySelected -= StartGame;
        MainMenuIconBehavior.OnHowToPlaySelected -= ShowHowToPlayScreen;
        MainMenuIconBehavior.OnAffirmationsSelected -= ShowAffirmationsScreen;
    }



    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void ShowHowToPlayScreen()
    {
        if (howToPlayScreen != null)
        {
            howToPlayScreen.SetActive(true);
           
        }
    }

    public void ShowAffirmationsScreen()
    {
        if (affirmationsScreen != null)
        {
            affirmationsScreen.SetActive(true);
        }
    }
}
