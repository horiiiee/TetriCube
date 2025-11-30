using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{
    [SerializeField] public GameObject PausePanel;
    [SerializeField] public GameObject OptionsPanel;
    [SerializeField] private AudioSource audioSource;
    private bool pause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (pause == false)
        {
            Time.timeScale = 0f;
            pause = true;
            PausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pause = false;
            PausePanel.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("вышли из игры");
    }
    public static void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ToggleSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }

    public void DecreaseVolume(float amount)
    {
        audioSource.volume -= amount;

        if (audioSource.volume < 0f)
        {
            audioSource.volume = 0f;
        }
    }

    public void AddVolume(float amount)
    {
        audioSource.volume += amount;

        if (audioSource.volume > 1f)
        {
            audioSource.volume = 1f;
        }
    }

    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);   
    }
    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
    }
}
