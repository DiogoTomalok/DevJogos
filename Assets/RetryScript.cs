using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
