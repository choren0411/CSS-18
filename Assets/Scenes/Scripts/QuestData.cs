//QuestData 스크립트 파일

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName;
    public int[] npcID;

    public QuestData(string name, int[] npc)
    {    //생성자
        questName = name;
        npcID = npc;
    }
}