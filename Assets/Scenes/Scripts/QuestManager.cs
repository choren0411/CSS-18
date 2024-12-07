//QuestManager 스크립트 파일

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questID;
    public int questActionIndex;    //퀘스트 대화 순서

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        //퀘스트 제목과와 해당 퀘스트에 연관된 NPC들의 ID 입력
        questList.Add(10, new QuestData("마을 사람들과 대화하기.", new int[] { 2000, 1000 }));
        questList.Add(20, new QuestData("루도의 동전 찾아주기.", new int[] { 300, 1000 }));
    }

    public int GetQuestTalkIndex(int id)
    {   //NPC ID를 받아 퀘스트 번호 반환
        //퀘스트 번호 + 퀘스트 대화 순서 = 퀘스트 대화 ID
        return questID + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questID].npcID[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questID].npcID.Length)    //퀘스트 대화 순서 끝에 도달했을 때
            NextQuest();

        return questList[questID].questName;
    }

    void NextQuest()
    {
        questID += 10;
        questActionIndex = 0;
    }
}