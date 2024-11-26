using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        collectedItems.Add(item);
        Debug.Log(item.name + "을(를) 인벤토리에 추가했습니다!");

        // UI 업데이트
        FindObjectOfType<InventoryUI>().UpdateInventoryUI();
    }
}