//QuestManager ��ũ��Ʈ ����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questID;
    public int questActionIndex;    //����Ʈ ��ȭ ����

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        //����Ʈ ������� �ش� ����Ʈ�� ������ NPC���� ID �Է�
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�.", new int[] { 2000, 1000 }));
        questList.Add(20, new QuestData("�絵�� ���� ã���ֱ�.", new int[] { 300, 1000 }));
    }

    public int GetQuestTalkIndex(int id)
    {   //NPC ID�� �޾� ����Ʈ ��ȣ ��ȯ
        //����Ʈ ��ȣ + ����Ʈ ��ȭ ���� = ����Ʈ ��ȭ ID
        return questID + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questID].npcID[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questID].npcID.Length)    //����Ʈ ��ȭ ���� ���� �������� ��
            NextQuest();

        return questList[questID].questName;
    }

    void NextQuest()
    {
        questID += 10;
        questActionIndex = 0;
    }
}