using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Контроллер для работы со сценой окончания игры.
/// </summary>
public class EndGameController : MonoBehaviour
{
    /// <summary>
    /// Итоговый счетчик пройденных платформ.
    /// </summary>
    public TextMeshProUGUI ScoreText;

    /// <summary>
    /// Метод, вызываемый при инициализации скрипта.
    /// </summary>
    private void Start()
    {
        ScoreText.text = PlayerController.Score.ToString();
    }

    /// <summary>
    /// Метод перезапуска игры.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// Метод возвращения в меню игры.
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
