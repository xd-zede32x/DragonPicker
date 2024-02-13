using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _panelPause;

    private bool _paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_paused)
                IsOpenPanelPause(0f, true);

            else
                IsOpenPanelPause(1f, false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void IsOpenPanelPause(float time, bool isActive)
    {
        Time.timeScale = time;
        _paused = isActive;
        _panelPause.SetActive(isActive);
    }
}