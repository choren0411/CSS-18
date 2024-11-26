using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        collectedItems.Add(item);
        Debug.Log(item.name + "��(��) �κ��丮�� �߰��߽��ϴ�!");

        // UI ������Ʈ
        FindObjectOfType<InventoryUI>().UpdateInventoryUI();
    }
}