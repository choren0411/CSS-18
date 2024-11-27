using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트
    private Animator animator; // Animator 컴포넌트
    private Vector2 movement; // 이동 방향

    void Start()
    {
        // 컴포넌트 초기화
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 입력값 받아오기 (WASD 또는 방향키)
        movement.x = Input.GetAxisRaw("Horizontal"); // 좌우 입력값 (-1, 0, 1)
        movement.y = Input.GetAxisRaw("Vertical");   // 상하 입력값 (-1, 0, 1)

        // 마지막 이동 방향 업데이트 (움직임이 있을 때만)
        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x); // 마지막 X 방향 저장
            animator.SetFloat("LastVertical", movement.y);   // 마지막 Y 방향 저장
        }

        // 애니메이터 파라미터 업데이트
        animator.SetFloat("Horizontal", movement.x); // 현재 X 방향
        animator.SetFloat("Vertical", movement.y);   // 현재 Y 방향
        animator.SetFloat("Speed", movement.sqrMagnitude); // 이동 크기 (속도)
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용한 캐릭터 이동 처리
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}