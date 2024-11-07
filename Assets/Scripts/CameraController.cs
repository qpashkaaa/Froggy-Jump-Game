using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Контроллер для работы с камерой.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Информация о позиции персонажа.
    /// </summary>
    public Transform PlayerTransform;

    /// <summary>
    /// Метод обновления, вызываемый каждый кадр.
    /// </summary>
    void Update()
    {
        if (PlayerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, PlayerTransform.position.y, transform.position.z);
        }
    }
}
