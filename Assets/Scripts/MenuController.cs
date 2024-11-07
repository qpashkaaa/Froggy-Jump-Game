using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ��� ������ � ����.
/// </summary>
public class MenuController : MonoBehaviour
{
    /// <summary>
    /// ����� ������� ����.
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// ����� ������ �� ����.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
