using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    public GameObject[] items; // ������ ������ ������ �迭
    public Transform spawnPoint; // �������� ������ ��ġ
    public float collectRange = 2f; // �������� ������ �� �ִ� �Ÿ�

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
            Debug.LogError("items �迭�� ��� �ֽ��ϴ�. ������ �������� �߰��ϼ���!");
            return;
        }

        float distance = Vector2.Distance(transform.position, spawnPoint.position);
        if (distance <= collectRange)
        {
            Inventory inventory = GetComponent<Inventory>();
            if (inventory != null && inventory.IsFull())
            {
                // ������ ���� �� ��� �޽��� ǥ��
                InventoryMessage inventoryMessage = FindObjectOfType<InventoryMessage>();
                if (inventoryMessage != null)
                {
                    inventoryMessage.ShowMessage("������ ���� ���� ����á���ϴ�!");
                }
                return;
            }

            int randomIndex = Random.Range(0, items.Length);

            // �κ��丮�� ������ �߰� (Instantiate ����)
            if (inventory != null)
            {
                inventory.AddItem(items[randomIndex]); // ������ ��� �����͸� �߰�
            }

            Debug.Log("�������� �����߽��ϴ�: " + items[randomIndex].name);
        }
        else
        {
            Debug.Log("�������� ������ �� �����ϴ�. �� ������ �ٰ�������.");
        }
    }
}
