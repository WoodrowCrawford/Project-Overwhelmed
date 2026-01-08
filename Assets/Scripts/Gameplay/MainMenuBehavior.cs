using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuBehavior : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerEnter.gameObject.name == "HowToPlayScreen")
        {
            howToPlayScreen.SetActive(false);
        }
        else if (eventData.pointerEnter.gameObject.name == "AffirmationsScreen")
        {
            affirmationsScreen.SetActive(false);
        }
    }
}
