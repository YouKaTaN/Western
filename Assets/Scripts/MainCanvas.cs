using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(RestartGame);
        FinishTrigger.PlayerFinished += ShowWinPanel;
        Player.PlayerDetected += ShowLosePanel;
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveAllListeners();
        FinishTrigger.PlayerFinished -= ShowWinPanel;
        Player.PlayerDetected -= ShowLosePanel;
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    private void ShowLosePanel()
    {
        StartCoroutine(DelayIE(2));
    }

    private IEnumerator DelayIE(int delay)
    {
        yield return new WaitForSeconds(delay);
        losePanel.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
