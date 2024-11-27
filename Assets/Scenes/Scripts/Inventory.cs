using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>(); // 수집한 아이템 데이터 목록
    public int maxSlots = 6; // 인벤토리 슬롯 최대 개수

    // 슬롯이 가득 찼는지 확인
    public bool IsFull()
    {
        return collectedItems.Count >= maxSlots; // 현재 아이템 수가 최대 슬롯 수 이상이면 true 반환
    }

    // 아이템을 인벤토리에 추가
    public void AddItem(GameObject item)
    {
        if (IsFull())
        {
            Debug.Log("슬롯이 가득 찼습니다!");
            return; // 슬롯이 가득 찼으면 추가하지 않음
        }

        collectedItems.Add(item); // 아이템 데이터를 인벤토리에 추가
        Debug.Log(item.name + "을(를) 인벤토리에 추가했습니다!");

        // UI 업데이트
        FindObjectOfType<InventoryUI>().UpdateInventoryUI();
    }
}
