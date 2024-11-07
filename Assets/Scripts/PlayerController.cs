using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс контроллера персонажа.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Скорость движения персонажа.
    /// </summary>
    public float MoveSpeed;

    /// <summary>
    /// Сила прыжка персонажа.
    /// </summary>
    public float JumpForce;

    /// <summary>
    /// Множитель ускорения падения.
    /// </summary>
    public float FallMultiplier;

    /// <summary>
    /// Максимальная высота прыжка.
    /// </summary>
    public float MaxJumpHeight;

    /// <summary>
    /// Платформа, на которой стоит персонаж.
    /// </summary>
    public ContactFilter2D Platform;

    /// <summary>
    /// Аниматор для взаимодействия с анимациями.
    /// </summary>
    public Animator Animator;

    /// <summary>
    /// Левая стена (границы уровня).
    /// </summary>
    public Transform LeftWall;

    /// <summary>
    /// Правая стена (границы уровня).
    /// </summary>
    public Transform RightWall;

    /// <summary>
    /// Флаг проверяюзий, находится ли персонаж на платформе.
    /// </summary>
    private bool _isOnPlatform => _rigidbody.IsTouching(Platform);

    /// <summary>
    /// Компонент <see cref="Rigidbody2D"/>.
    /// </summary>
    private Rigidbody2D _rigidbody;

    /// <summary>
    /// Входной параметр для движения.
    /// </summary>
    private float _moveInput;

    /// <summary>
    /// Стартовая координата Y перед прыжком.
    /// </summary>
    private float _initialJumpYPosition;

    /// <summary>
    /// Метод, вызываемый при инициализации.
    /// </summary>
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Метод вызываемый каждый кадр.
    /// </summary>
    private void Update()
    {
        JumpProcessing();
        AnimationsProcessing();
        MoveProcessing();
        FallProcessing();
    }

    /// <summary>
    /// Метод, вызываемый при контакте с триггером.
    /// </summary>
    /// <param name="collision"><see cref="Collider2D"/>.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        OutOfLevelLimitProcessing(collision);
        EndLevelProcessing(collision);
    }

    /// <summary>
    /// Метод обработки движений вправо и влево.
    /// </summary>
    private void MoveProcessing()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        _rigidbody.linearVelocity = new Vector2(_moveInput * MoveSpeed, _rigidbody.linearVelocity.y);

        if (_moveInput > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
        }
    }

    /// <summary>
    /// Метод постоянного прыжка вверх.
    /// </summary>
    private void JumpProcessing()
    {
        if (_isOnPlatform &&
            !Input.GetKey(KeyCode.Space))
        {
            _initialJumpYPosition = transform.position.y;

            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0f);

            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            Animator.SetBool("IsWallJump", false);
        }

        if (transform.position.y >= _initialJumpYPosition + MaxJumpHeight)
        {
            if (_rigidbody.linearVelocity.y > 0)
            {
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0f);
            }
        }
    }

    /// <summary>
    /// Метод обработки падения.
    /// </summary>
    private void FallProcessing()
    {
        if (_rigidbody.linearVelocity.y < 0)
        {
            _rigidbody.gravityScale = FallMultiplier;
        }
        else if (_rigidbody.linearVelocity.y > 0)
        {
            _rigidbody.gravityScale = 1f;
        }
    }

    /// <summary>
    /// Метод обработки анимаций.
    /// </summary>
    private void AnimationsProcessing()
    {
        Animator.SetFloat("VerticalMove", _rigidbody.linearVelocity.y);
        Animator.SetBool("IsOnPlatform", _isOnPlatform);
    }

    /// <summary>
    /// Метод обработки окончания уровня (проигрыша).
    /// </summary>
    /// <param name="collision"><see cref="Collider2D"/>.</param>
    private void EndLevelProcessing(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    /// <summary>
    /// Метод обработки выхода персонажа за пределы карты (к правой или левой стене).
    /// </summary>
    /// <param name="collision"><see cref="Collider2D"/>.</param>
    private void OutOfLevelLimitProcessing(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Animator.SetBool("IsWallJump", true);

            if (collision.transform == LeftWall)
            {
                transform.position = new Vector2(RightWall.position.x - 1.5f, transform.position.y);
            }
            else if (collision.transform == RightWall)
            {
                transform.position = new Vector2(LeftWall.position.x + 1.5f, transform.position.y);
            }

            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}
