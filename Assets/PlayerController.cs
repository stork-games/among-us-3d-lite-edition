using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Скорость передвижения игрока
    [SerializeField] private float speed = 10.0f;

    // Компонент CharacterController
    private CharacterController cc;
    Animator animator;

    void Start()
    {
        // Получаем компонент CharacterController
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Получаем нажатия предустановленных клавиш
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("IsWalking", isWalking);

        // Записываем данные в отдельную переменную
        Vector2 input = new Vector2(horizontal, vertical);
        // Определяем направление движения
        Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
        Vector3 moveDir = new Vector3(desiredMove.x * speed, 0, desiredMove.z * speed);
        // Передвигаем объект
        cc.Move(moveDir * Time.fixedDeltaTime);
    }
}
