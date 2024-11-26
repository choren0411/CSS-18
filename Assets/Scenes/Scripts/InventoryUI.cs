using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // �κ��丮 �г�
    public List<Image> itemSlots; // ������ ���� ����Ʈ

    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // ��� ������ ���ϴ�
        foreach (Image slot in itemSlots)
        {
            slot.sprite = null;
            slot.enabled = false;
        }

        // �κ��丮�� �ִ� �������� ���Կ� ä��ϴ�
        for (int i = 0; i < inventory.collectedItems.Count; i++)
        {
            if (i < itemSlots.Count)
            {
                GameObject item = inventory.collectedItems[i];
                Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;
                itemSlots[i].sprite = itemSprite;
                itemSlots[i].enabled = true;
            }
        }
    }
}
