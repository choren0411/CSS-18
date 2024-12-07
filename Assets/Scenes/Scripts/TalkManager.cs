//TalkManager 스크립트 파일

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateDate();
    }

    void GenerateDate()
    {
        //대화 데이터 Cow :1000,1004,   Chicken:1001 , Jack: 1002 , Witch: 1003 
        talkData.Add(1000, new string[] { "음메에-", "배고파아--" });
        talkData.Add(1001, new string[] { "처음보는 얼굴인데", "케이포네 섬에 온 걸 환영해" });
        talkData.Add(1002, new string[] { "안녕?", "넌 누구야?", "여긴 케이포네 섬이야", "응? 말을 못하는거야?", "그럼 마녀님을 한번 찾아가봐. 마녀님은 뭐든 해결해 주시거든! " }) ;
        talkData.Add(1003, new string[] { "처음보는 아이로구나", "이곳은 인간에게 버려진 것들이 모이는 곳이란다", "한때는 이곳도 그저 평화로운 섬이었지만..", "..목소리를 되찾고 싶다고?", " 이 섬을 청소하는 일을 도와주면 목소리를 줄게 ", "버려진 옷 5개를 모아오렴" });
        talkData.Add(1004, new string[] { "버려진 옷? 이 섬에 널려있는걸.", "풀숲이나 옷더미에서 [E]를 눌러봐", "금방 모을수 있을거야" });

        //Obj 데이터 옷무더기: 104
        talkData.Add(100, new string[] { "머리 없는 나무이다", "...대머리 나무일까?" });
        talkData.Add(101, new string[] { "평범한 돌이다." });
        talkData.Add(102, new string[] { "부드러운 풀이다." });
        talkData.Add(103, new string[] { "풍성해 보이는 나무이다" });
        talkData.Add(104, new string[] { "...! ", " 보물들이 높이 쌓여있다" });
        talkData.Add(105, new string[] { " 이건 무엇일까? " });

        //퀘스트 대화 데이터, 퀘스트 번호 + NPC ID
        //talkData.Add(10 + 1003, new string[] { "어서와.:0", "이 마을에 놀라운 전설이 있다는데:1", "오른쪽 호수에 있는 루도가 알려줄거야.:0" });
        //talkData.Add(11 + 1000, new string[] { "안녕.:0", "혹시 이 호수의 전설을 들으러 온거야?:0", "그러면 대신 부탁 하나만 해도될까?:1", "얼마전에 내 집 근처에서 동전 하나를 잃어버렸어.:3", "그 동전 좀 찾아줄래?:2" });

        //talkData.Add(20 + 2000, new string[] { "루도의 동전?:1", "돈을 흘리고 다니면 못쓰지!:3", "나중에 루도에게 한마디 해야겠어.:3" });
        //talkData.Add(20 + 1000, new string[] { "찾으면 꼭 좀 가져다줘.:1" });
        //talkData.Add(20 + 5000, new string[] { "근처에서 동전을 찾았다." });
        //talkData.Add(21 + 1000, new string[] { "오, 찾아줘서 고마워.:2" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}