using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public Animator talkPanel;
    public TypeEffect talk;
    public GameObject scanObject;
    public GameObject menuSet; // ����޴� GameObject
    public GameObject player;
    public bool isAction; // ��ȭâ Ȱ��ȭ ���� üũ
    public int talkIndex;

    void Update()
    {
        // ���� �޴� Ȱ��ȭ/��Ȱ��ȭ
        if (Input.GetButtonDown("Cancel")) // Esc Ű �Է�
        {
            if (menuSet.activeSelf) // �޴��� Ȱ��ȭ ���¶��
                menuSet.SetActive(false); // ��Ȱ��ȭ
            else
                menuSet.SetActive(true); // Ȱ��ȭ
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);

        // ��ȭâ Ȱ��ȭ, ��Ȱ��ȭ
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id)
    {
        string talkData = "";

        // ��ȭ ������ �ҷ�����
        if (talk.isAnim) // ��� ��� ���� ��
        {
            talk.SetMsg(""); // ��� �ߴ�
            return;
        }
        else
        {
            talkData = talkManager.GetTalk(id, talkIndex);
        }

        // ��ȭ�� ������ ���߱�
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        // ��ȭ ���
        talk.SetMsg(talkData);

        // ��ȭâ ���� �� ��ȭ �ε��� ����
        isAction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        // �÷��̾� ��ġ ����
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();

        // ���� �� �޴� �ݱ�
        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // ����� �����Ͱ� ���ٸ�
            return;

        // ����� ������ �ҷ�����
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        // ������ ����
        player.transform.position = new Vector3(x, y, -2);
    }

    public void GameExit()
    {
        // ���� ����
        Application.Quit();
    }
}