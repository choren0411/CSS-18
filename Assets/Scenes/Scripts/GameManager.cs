using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public Animator talkPanel;
    public TypeEffect talk;
    public GameObject scanObject;
    public GameObject menuSet; // 서브메뉴 GameObject
    public GameObject player;
    public bool isAction; // 대화창 활성화 여부 체크
    public int talkIndex;

    void Update()
    {
        // 서브 메뉴 활성화/비활성화
        if (Input.GetButtonDown("Cancel")) // Esc 키 입력
        {
            if (menuSet.activeSelf) // 메뉴가 활성화 상태라면
                menuSet.SetActive(false); // 비활성화
            else
                menuSet.SetActive(true); // 활성화
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);

        // 대화창 활성화, 비활성화
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id)
    {
        string talkData = "";

        // 대화 데이터 불러오기
        if (talk.isAnim) // 대사 출력 중일 때
        {
            talk.SetMsg(""); // 대사 중단
            return;
        }
        else
        {
            talkData = talkManager.GetTalk(id, talkIndex);
        }

        // 대화가 끝나면 멈추기
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        // 대화 출력
        talk.SetMsg(talkData);

        // 대화창 띄우기 및 대화 인덱스 증가
        isAction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        // 플레이어 위치 저장
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();

        // 저장 후 메뉴 닫기
        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // 저장된 데이터가 없다면
            return;

        // 저장된 데이터 불러오기
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        // 데이터 적용
        player.transform.position = new Vector3(x, y, -2);
    }

    public void GameExit()
    {
        // 게임 종료
        Application.Quit();
    }
}