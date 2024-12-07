//TalkManager ��ũ��Ʈ ����

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
        //��ȭ ������ Cow :1000,1004,   Chicken:1001 , Jack: 1002 , Witch: 1003 
        talkData.Add(1000, new string[] { "���޿�-", "����ľ�--" });
        talkData.Add(1001, new string[] { "ó������ ���ε�", "�������� ���� �� �� ȯ����" });
        talkData.Add(1002, new string[] { "�ȳ�?", "�� ������?", "���� �������� ���̾�", "��? ���� ���ϴ°ž�?", "�׷� ������� �ѹ� ã�ư���. ������� ���� �ذ��� �ֽðŵ�! " }) ;
        talkData.Add(1003, new string[] { "ó������ ���̷α���", "�̰��� �ΰ����� ������ �͵��� ���̴� ���̶���", "�Ѷ��� �̰��� ���� ��ȭ�ο� ���̾�����..", "..��Ҹ��� ��ã�� �ʹٰ�?", " �� ���� û���ϴ� ���� �����ָ� ��Ҹ��� �ٰ� ", "������ �� 5���� ��ƿ���" });
        talkData.Add(1004, new string[] { "������ ��? �� ���� �η��ִ°�.", "Ǯ���̳� �ʴ��̿��� [E]�� ������", "�ݹ� ������ �����ž�" });

        //Obj ������ �ʹ�����: 104
        talkData.Add(100, new string[] { "�Ӹ� ���� �����̴�", "...��Ӹ� �����ϱ�?" });
        talkData.Add(101, new string[] { "����� ���̴�." });
        talkData.Add(102, new string[] { "�ε巯�� Ǯ�̴�." });
        talkData.Add(103, new string[] { "ǳ���� ���̴� �����̴�" });
        talkData.Add(104, new string[] { "...! ", " �������� ���� �׿��ִ�" });
        talkData.Add(105, new string[] { " �̰� �����ϱ�? " });

        //����Ʈ ��ȭ ������, ����Ʈ ��ȣ + NPC ID
        //talkData.Add(10 + 1003, new string[] { "���.:0", "�� ������ ���� ������ �ִٴµ�:1", "������ ȣ���� �ִ� �絵�� �˷��ٰž�.:0" });
        //talkData.Add(11 + 1000, new string[] { "�ȳ�.:0", "Ȥ�� �� ȣ���� ������ ������ �°ž�?:0", "�׷��� ��� ��Ź �ϳ��� �ص��ɱ�?:1", "������ �� �� ��ó���� ���� �ϳ��� �Ҿ���Ⱦ�.:3", "�� ���� �� ã���ٷ�?:2" });

        //talkData.Add(20 + 2000, new string[] { "�絵�� ����?:1", "���� �긮�� �ٴϸ� ������!:3", "���߿� �絵���� �Ѹ��� �ؾ߰ھ�.:3" });
        //talkData.Add(20 + 1000, new string[] { "ã���� �� �� ��������.:1" });
        //talkData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�." });
        //talkData.Add(21 + 1000, new string[] { "��, ã���༭ ����.:2" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}