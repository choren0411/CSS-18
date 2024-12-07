//PlayerAction ��ũ��Ʈ ����

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
        //�̵� �� ����
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //�̵� ��ư Ȯ��
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        //�̵� ���� üũ
        if (hDown || vUp)   //����
            isHorizonMove = true;
        else if (vDown || hUp)  //����
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //�ִϸ��̼� ��ȯ
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

        //���� ���� �Ǵ��ϱ�
        if (vDown && v == 1)    //���� ����
            dirVec = Vector3.up;
        else if (vDown && v == -1)    //�Ʒ��� ����
            dirVec = Vector3.down;
        else if (hDown && h == -1)    //���� ����
            dirVec = Vector3.left;
        else if (hDown && h == 1)    //������ ����
            dirVec = Vector3.right;

        //������Ʈ ��ĵ ���
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        //����, ���� �̵� ����
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //���� ����ϱ�
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;    //RayCast�� ������Ʈ�� ������ ����
        }
        else
            scanObject = null;
    }
}