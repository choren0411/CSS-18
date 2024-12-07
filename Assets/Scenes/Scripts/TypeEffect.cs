//TypeEffect ��ũ��Ʈ ����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public GameObject EndCursor;    //��ȭâ �� ȭ��ǥ
    Text msgText;   //��ȭ �ؽ�Ʈ
    AudioSource audioSource;    //����

    public int CharPerSeconds;  //���� ��� �ӵ� ����
    public bool isAnim;   //�ִϸ��̼� ���� �Ǵ�
    string targetMsg;    //ǥ���� ��ȭ ���ڿ� ����
    int index;  //���ڿ� �ε���
    float interval; //CPS ���� ����

    void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {   //�ִϸ��̼� ���� ���϶�. ��, ��� �߿� �����̽��ٸ� ������ ��
            msgText.text = targetMsg;  //��� ���ڿ� ���� ���
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //����Ʈ ����
        isAnim = true;
        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        //����Ʈ ������
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];

        //���� ���
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        index++;

        //���
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}