using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    public GameObject[] items; // 생성할 아이템 프리팹 배열
    public Transform spawnPoint; // 아이템을 생성할 위치
    public float collectRange = 2f; // 아이템을 수집할 수 있는 거리

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }

    void CollectItem()
    {
        if (items == null || items.Length == 0)
        {
            Debug.LogError("items 배열이 비어 있습니다. 아이템 프리팹을 추가하세요!");
            return;
        }

        float distance = Vector2.Distance(transform.position, spawnPoint.position);
        if (distance <= collectRange)
        {
            Inventory inventory = GetComponent<Inventory>();
            if (inventory != null && inventory.IsFull())
            {
                // 슬롯이 가득 찬 경우 메시지 표시
                InventoryMessage inventoryMessage = FindObjectOfType<InventoryMessage>();
                if (inventoryMessage != null)
                {
                    inventoryMessage.ShowMessage("슬롯이 현재 전부 가득찼습니다!");
                }
                return;
            }

            int randomIndex = Random.Range(0, items.Length);

            // 인벤토리에 아이템 추가 (Instantiate 제거)
            if (inventory != null)
            {
                inventory.AddItem(items[randomIndex]); // 프리팹 대신 데이터를 추가
            }

            Debug.Log("아이템을 수집했습니다: " + items[randomIndex].name);
        }
        else
        {
            Debug.Log("아이템을 수집할 수 없습니다. 더 가까이 다가가세요.");
        }
    }
}
