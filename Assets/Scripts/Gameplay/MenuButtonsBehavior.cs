using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MenuButtonsBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI Elements")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject howToPlayButton;
    [SerializeField] private GameObject affirmationsButton;

    [Header("Play button sprites")]
    [SerializeField] private Sprite playNormalSprite;
    [SerializeField] private Sprite playHoverSprite;

    [Header("How To Play button sprites")]
    [SerializeField] private Sprite howToPlayNormalSprite;
    [SerializeField] private Sprite howToPlayHoverSprite;

    [Header("Affirmations button sprites")]
    [SerializeField] private Sprite affirmationsNormalSprite;
    [SerializeField] private Sprite affirmationsHoverSprite;


    void Awake()
    {
        playButton.GetComponent<Image>().sprite = playNormalSprite;
        howToPlayButton.GetComponent<Image>().sprite = howToPlayNormalSprite;
        affirmationsButton.GetComponent<Image>().sprite = affirmationsNormalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerEnter == playButton)
        {
            playButton.GetComponent<Image>().sprite = playHoverSprite;
        }
        else if (eventData.pointerEnter == howToPlayButton)
        {
            Debug.Log("Hovering over How To Play button");
        }
        else if (eventData.pointerEnter == affirmationsButton)
        {
            Debug.Log("Hovering over Affirmations button");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter == playButton)
        {
            Debug.Log("Stopped hovering over Play button");
        }
        else if (eventData.pointerEnter == howToPlayButton)
        {
            Debug.Log("Stopped hovering over How To Play button");
        }
        else if (eventData.pointerEnter == affirmationsButton)
        {
            Debug.Log("Stopped hovering over Affirmations button");
        }
    }
}
