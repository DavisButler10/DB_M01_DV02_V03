using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartArena()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
}
