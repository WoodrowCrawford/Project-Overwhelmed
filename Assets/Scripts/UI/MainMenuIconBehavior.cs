using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuIconBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public delegate void MenuIconAction();
    public static event MenuIconAction OnPlaySelected;
    public static event MenuIconAction OnHowToPlaySelected;
    public static event MenuIconAction OnAffirmationsSelected;

   [SerializeField] private Sprite normalSprite;
   [SerializeField] private Sprite hoverSprite;

    void Awake()
    {
        GetComponent<Image>().sprite = normalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = normalSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject.name == "PlayButton")
        {
            Debug.Log("Clicked on " + gameObject.name);
            // Add logic to navigate to the corresponding menu or perform an action
            OnPlaySelected?.Invoke();
            
        }

        else if (eventData.pointerEnter.gameObject.name == "HowToPlayButton")
        {
            Debug.Log("Clicked on " + gameObject.name);
            // Add logic to navigate to the corresponding menu or perform an action
            OnHowToPlaySelected?.Invoke();
        }
        else if (eventData.pointerEnter.gameObject.name == "AffirmationsButton")
        {
            Debug.Log("Clicked on " + gameObject.name);
            // Add logic to navigate to the corresponding menu or perform an action
            OnAffirmationsSelected?.Invoke();
        }
    }
}
