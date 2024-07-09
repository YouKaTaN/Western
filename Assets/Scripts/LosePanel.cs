using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Button TryAgainButton;

    private void OnEnable()
    {
        TryAgainButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        TryAgainButton.onClick.RemoveAllListeners();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
