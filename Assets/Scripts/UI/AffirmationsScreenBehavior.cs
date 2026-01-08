using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AffirmationsScreenBehavior : MonoBehaviour
{
   [Header("UI Elements")]
   [SerializeField] private Button leftButton;
   [SerializeField] private Button rightButton;

   [Header("Affirmations Data")]
    [SerializeField] private TMP_Text currentAffirmation;

    [SerializeField] private string[] affirmationsArray = new string[] { "My breath is my anchor. It brings me back to calm.", "I choose peace over worry!", "Every step, no matter how small, is progress.", "Everything is figureoutable.", "I release what I cannot control and focus on what I can.", "This feeling will not last forever.", "I am enough, just as I am.", "I don't do overwhelm." };

    [SerializeField] private string affirmation1 = "My breath is my anchor. It brings me back to calm.";
    [SerializeField] private string affirmation2 = "I choose peace over worry!";
    [SerializeField] private string affirmation3 = "Every step, no matter how small, is progress.";

    [SerializeField] private string affirmation4 = "Everything is figureoutable.";
    [SerializeField] private string affirmation5 = "I release what I cannot control and focus on what I can.";
    [SerializeField] private string affirmation6 = "This feeling will not last forever.";
    [SerializeField] private string affirmation7 = "I am enough, just as I am.";
    [SerializeField] private string affirmation8 = "I don't do overwhelm.";


    void Awake()
    {
        leftButton.onClick.AddListener(OnLeftButtonClick);
        rightButton.onClick.AddListener(OnRightButtonClick);
    }

    void Start()
    {
        currentAffirmation.text = affirmationsArray[0];
    }
    

    void OnDestroy()
    {
        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();
    }


    private void OnLeftButtonClick()
    {
       //first iterate through the list
        for (int i = 0; i < affirmationsArray.Length; i++)
        {
           
            //if the current affirmation is the first one in the list, set it to the last
            if(currentAffirmation.text == affirmationsArray[0])
            {
                currentAffirmation.text = affirmationsArray[affirmationsArray.Length - 1];
                break;
            }

            else if(currentAffirmation.text == affirmationsArray[i])
            {
                currentAffirmation.text = affirmationsArray[i - 1];
                break;
            }
        }

         //then display the current affirmation
         //then set the current affirmation to the previous one in the list
         //if the current affirmation is the first one in the list, set it to the last


    }

    private void OnRightButtonClick()
    {
        //first iterate through the list
        for (int i = 0; i < affirmationsArray.Length; i++)
        {
            //if the current affirmation is the last one in the list, set it to the first
            if(currentAffirmation.text == affirmationsArray[affirmationsArray.Length - 1])
            {
                currentAffirmation.text = affirmationsArray[0];
                break;
            }

            else if(currentAffirmation.text == affirmationsArray[i])
            {
                currentAffirmation.text = affirmationsArray[i + 1];
                break;
            }
        }

         
    }

    
}
