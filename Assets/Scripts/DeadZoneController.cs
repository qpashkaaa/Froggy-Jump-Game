using UnityEngine;

/// <summary>
/// Контроллер для работы с DeadZone.
/// </summary>
public class DeadZoneController : MonoBehaviour
{
    /// <summary>
    /// Метод, вызываемый при контакте с триггером.
    /// </summary>
    /// <param name="collision"><see cref="Collider2D"/>.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            float x = Random.Range(-5f, 5f);
            PlatformGeneratorController.LastPlatformY += Random.Range(1f, 4.5f);

            collision.transform.position = new Vector3(x, PlatformGeneratorController.LastPlatformY, 0);

            PlayerController.Score += 1;
        }
    }
}
