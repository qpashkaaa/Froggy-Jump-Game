using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ��� ������ �� ������ ��������� ����.
/// </summary>
public class EndGameController : MonoBehaviour
{
    /// <summary>
    /// �������� ������� ���������� ��������.
    /// </summary>
    public TextMeshProUGUI ScoreText;

    /// <summary>
    /// �����, ���������� ��� ������������� �������.
    /// </summary>
    private void Start()
    {
        ScoreText.text = PlayerController.Score.ToString();
    }

    /// <summary>
    /// ����� ����������� ����.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// ����� ����������� � ���� ����.
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
