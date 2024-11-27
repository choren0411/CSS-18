using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>(); // ������ ������ ������ ���
    public int maxSlots = 6; // �κ��丮 ���� �ִ� ����

    // ������ ���� á���� Ȯ��
    public bool IsFull()
    {
        return collectedItems.Count >= maxSlots; // ���� ������ ���� �ִ� ���� �� �̻��̸� true ��ȯ
    }

    // �������� �κ��丮�� �߰�
    public void AddItem(GameObject item)
    {
        if (IsFull())
        {
            Debug.Log("������ ���� á���ϴ�!");
            return; // ������ ���� á���� �߰����� ����
        }

        collectedItems.Add(item); // ������ �����͸� �κ��丮�� �߰�
        Debug.Log(item.name + "��(��) �κ��丮�� �߰��߽��ϴ�!");

        // UI ������Ʈ
        FindObjectOfType<InventoryUI>().UpdateInventoryUI();
    }
}
