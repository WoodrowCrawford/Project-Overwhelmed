using UnityEngine;

public class HUDBehavior : MonoBehaviour
{
    [SerializeField] private GameObject HUDCanvas;
    [SerializeField] private GameObject meterUI;
    [SerializeField] private GameObject meterFillUI;


    void OnEnable()
    {
        OrbBehavior.OnOrbCollected += () => UpdateMeter(0.1f);
    }

    void OnDisable()
    {
        
    }

    public void UpdateMeter(float fillAmount)
    {
        //update the fill amount of the meter
        meterFillUI.GetComponent<UnityEngine.UI.Image>().fillAmount += fillAmount;
    }
}
