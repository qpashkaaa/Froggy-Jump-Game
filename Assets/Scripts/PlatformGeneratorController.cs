using UnityEngine;

/// <summary>
/// Контроллер для работы с созданием платформ.
/// </summary>
public class PlatformGeneratorController : MonoBehaviour
{
    /// <summary>
    /// Координата Y последней созданной платформы.
    /// </summary>
    public static float LastPlatformY = 0f;

    /// <summary>
    /// Шаблон платформы.
    /// </summary>
    public GameObject PlatformPrefab;

    /// <summary>
    /// Метод, вызываемый при инициализации.
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
