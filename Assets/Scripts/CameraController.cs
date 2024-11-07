using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ���������� ��� ������ � �������.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// ���������� � ������� ���������.
    /// </summary>
    public Transform PlayerTransform;

    /// <summary>
    /// ����� ����������, ���������� ������ ����.
    /// </summary>
    void Update()
    {
        if (PlayerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, PlayerTransform.position.y, transform.position.z);
        }
    }
}
