using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    public GameObject[] items; // ������ ������ ������ �迭
    public Transform spawnPoint; // �������� ������ ��ġ
    public float collectRange = 2f; // �������� ������ �� �ִ� �Ÿ�

    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

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
            int randomIndex = Random.Range(0, items.Length);
            GameObject collectedItem = Instantiate(items[randomIndex], spawnPoint.position, Quaternion.identity);

            // �κ��丮�� ������ �߰�
            inventory.AddItem(collectedItem);
        }
        else
        {
            Debug.Log("�������� ������ �� �����ϴ�. �� ������ �ٰ�������.");
        }
    }
}
