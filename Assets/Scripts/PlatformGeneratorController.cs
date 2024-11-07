using UnityEngine;

/// <summary>
/// ���������� ��� ������ � ��������� ��������.
/// </summary>
public class PlatformGeneratorController : MonoBehaviour
{
    /// <summary>
    /// ���������� Y ��������� ��������� ���������.
    /// </summary>
    public static float LastPlatformY = 0f;

    /// <summary>
    /// ������ ���������.
    /// </summary>
    public GameObject PlatformPrefab;

    /// <summary>
    /// �����, ���������� ��� �������������.
    /// </summary>
    private void Start()
    {
        Vector3 spawnerPosition = new Vector3()
        {
            y = -2f
        };

        for (int i = 0; i < 5; i++)
        {
            spawnerPosition.x = Random.Range(-5f, 5f);
            spawnerPosition.y += Random.Range(1f, 4.5f);

            Instantiate(PlatformPrefab, spawnerPosition, Quaternion.identity);

            LastPlatformY = spawnerPosition.y;
        }
    }
}
