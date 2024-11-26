using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    public GameObject[] items; // 생성할 아이템 프리팹 배열
    public Transform spawnPoint; // 아이템을 생성할 위치
    public float collectRange = 2f; // 아이템을 수집할 수 있는 거리

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
            Debug.LogError("items 배열이 비어 있습니다. 아이템 프리팹을 추가하세요!");
            return;
        }

        float distance = Vector2.Distance(transform.position, spawnPoint.position);
        if (distance <= collectRange)
        {
            int randomIndex = Random.Range(0, items.Length);
            GameObject collectedItem = Instantiate(items[randomIndex], spawnPoint.position, Quaternion.identity);

            // 인벤토리에 아이템 추가
            inventory.AddItem(collectedItem);
        }
        else
        {
            Debug.Log("아이템을 수집할 수 없습니다. 더 가까이 다가가세요.");
        }
    }
}
