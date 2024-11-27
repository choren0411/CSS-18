using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ĳ���� �̵� �ӵ�
    private Rigidbody2D rb; // Rigidbody2D ������Ʈ
    private Animator animator; // Animator ������Ʈ
    private Vector2 movement; // �̵� ����

    void Start()
    {
        // ������Ʈ �ʱ�ȭ
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �Է°� �޾ƿ��� (WASD �Ǵ� ����Ű)
        movement.x = Input.GetAxisRaw("Horizontal"); // �¿� �Է°� (-1, 0, 1)
        movement.y = Input.GetAxisRaw("Vertical");   // ���� �Է°� (-1, 0, 1)

        // ������ �̵� ���� ������Ʈ (�������� ���� ����)
        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x); // ������ X ���� ����
            animator.SetFloat("LastVertical", movement.y);   // ������ Y ���� ����
        }

        // �ִϸ����� �Ķ���� ������Ʈ
        animator.SetFloat("Horizontal", movement.x); // ���� X ����
        animator.SetFloat("Vertical", movement.y);   // ���� Y ����
        animator.SetFloat("Speed", movement.sqrMagnitude); // �̵� ũ�� (�ӵ�)
    }

    void FixedUpdate()
    {
        // Rigidbody2D�� ����� ĳ���� �̵� ó��
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}