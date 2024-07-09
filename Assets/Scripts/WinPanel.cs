using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button OkButton;
    [SerializeField] private TextMeshProUGUI bestTime;

    private void OnEnable()
    {
        OkButton.onClick.AddListener(NextLevel);

        if (PlayerPrefs.HasKey(Timer.BEST_TIME))
        {
            bestTime.text = PlayerPrefs.GetFloat(Timer.BEST_TIME).ToString("F2") + " sec.";
        }
        else
        {
            bestTime.text = null;
        }
    }

    private void OnDisable()
    {
        OkButton.onClick.RemoveAllListeners();
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
