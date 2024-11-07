using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Контроллер для работы с меню.
/// </summary>
public class MenuController : MonoBehaviour
{
    /// <summary>
    /// Метод запуска игры.
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// Метод выхода из игры.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
