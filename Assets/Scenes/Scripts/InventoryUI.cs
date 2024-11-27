using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // 인벤토리 패널
    public List<Image> itemSlots; // 아이템 슬롯 리스트

    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // 모든 슬롯 초기화
        foreach (Image slot in itemSlots)
        {
            slot.sprite = null;
            slot.enabled = false;
        }

        // 인벤토리에 있는 아이템을 슬롯에 표시
        for (int i = 0; i < inventory.collectedItems.Count; i++)
        {
            if (i < itemSlots.Count)
            {
                GameObject item = inventory.collectedItems[i];
                Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;
                itemSlots[i].sprite = itemSprite; // 슬롯에 아이템 스프라이트 표시
                itemSlots[i].enabled = true;
            }
        }
    }
}
