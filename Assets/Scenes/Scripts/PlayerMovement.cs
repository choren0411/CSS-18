//PlayerAction 스크립트 파일

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    public GameObject scanObject;
    float h;
    float v;
    bool isHorizonMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //이동 값 설정
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //이동 버튼 확인
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        //이동 방향 체크
        if (hDown || vUp)   //수평
            isHorizonMove = true;
        else if (vDown || hUp)  //수직
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //애니메이션 전환
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);

        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        //레이 방향 판단하기
        if (vDown && v == 1)    //위쪽 방향
            dirVec = Vector3.up;
        else if (vDown && v == -1)    //아래쪽 방향
            dirVec = Vector3.down;
        else if (hDown && h == -1)    //왼쪽 방향
            dirVec = Vector3.left;
        else if (hDown && h == 1)    //오른쪽 방향
            dirVec = Vector3.right;

        //오브젝트 스캔 출력
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        //수평, 수직 이동 결정
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //레이 사용하기
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;    //RayCast된 오브젝트를 변수로 저장
        }
        else
            scanObject = null;
    }
}