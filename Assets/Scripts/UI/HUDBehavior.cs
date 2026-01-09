using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDBehavior : MonoBehaviour
{
    [SerializeField] private GameObject HUDCanvas;
    [SerializeField] private GameObject meterUI;
    [SerializeField] private GameObject meterFillUI;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button tryAgainButton;

    public static bool isGameOver = false;

    private const float OrbFillIncrement = 0.083f;


    void OnEnable()
    {
        OrbBehavior.OnOrbCollected += HandleOrbCollected;
        tryAgainButton.onClick.AddListener(() => SceneManager.LoadScene("MainGameScene"));
        DarkThoughtsBehavior.OnDarkThoughtHitPlayer += ShowGameOverScreen;
    }

    void OnDisable()
    {
        OrbBehavior.OnOrbCollected -= HandleOrbCollected;
        tryAgainButton.onClick.RemoveAllListeners();
        DarkThoughtsBehavior.OnDarkThoughtHitPlayer -= ShowGameOverScreen;
    }

    void Awake()
    {
        gameOverScreen.SetActive(false);
        isGameOver = false;
        meterFillUI.GetComponent<Image>().fillAmount = 0f;
        
    }

    private void HandleOrbCollected()
    {
        UpdateMeter(OrbFillIncrement);
    }

    public void UpdateMeter(float fillAmount)
    {
        //update the fill amount of the meter
        meterFillUI.GetComponent<UnityEngine.UI.Image>().fillAmount += fillAmount;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }
}