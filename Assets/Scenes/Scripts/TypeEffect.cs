//TypeEffect 스크립트 파일

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public GameObject EndCursor;    //대화창 끝 화살표
    Text msgText;   //대화 텍스트
    AudioSource audioSource;    //사운드

    public int CharPerSeconds;  //글자 재생 속도 변수
    public bool isAnim;   //애니메이션 실행 판단
    string targetMsg;    //표시할 대화 문자열 변수
    int index;  //문자열 인덱스
    float interval; //CPS 보조 변수

    void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {   //애니메이션 실행 중일때. 즉, 대사 중에 스페이스바를 눌렀을 때
            msgText.text = targetMsg;  //대사 문자열 전부 출력
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

        //이펙트 시작
        isAnim = true;
        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        //이펙트 끝내기
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];

        //사운드 출력
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        index++;

        //재귀
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}