using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class HUDBehavior : MonoBehaviour
{
    [SerializeField] private GameObject HUDCanvas;
    [SerializeField] private GameObject meterUI;
    [SerializeField] private GameObject meterFillUI;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button restartButton;

    public static bool isGameOver = false;

    private const float OrbFillIncrement = 0.083f;


    void OnEnable()
    {
        OrbBehavior.OnOrbCollected += HandleOrbCollected;
        tryAgainButton.onClick.AddListener(() => SceneManager.LoadScene("MainGameScene"));
        restartButton.onClick.AddListener(() => SceneManager.LoadScene("MainGameScene"));
        DarkThoughtsBehavior.OnDarkThoughtHitPlayer += ShowGameOverScreen;
        OrbSpawnerBehavior.OnCollectedAllOrbs += ShowWinScreen;
    }

   
    void OnDisable()
    {
        OrbBehavior.OnOrbCollected -= HandleOrbCollected;
        tryAgainButton.onClick.RemoveAllListeners();
        restartButton.onClick.RemoveAllListeners();
        DarkThoughtsBehavior.OnDarkThoughtHitPlayer -= ShowGameOverScreen;
        OrbSpawnerBehavior.OnCollectedAllOrbs -= ShowWinScreen;

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

     private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

}