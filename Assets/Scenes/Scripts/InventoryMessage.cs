using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText; // �޽��� �ؽ�Ʈ
    public float displayTime = 2f; // �޽����� ǥ�õǴ� �ð�

    public void ShowMessage(string message)
    {
        messageText.text = message; // �޽��� ����
        gameObject.SetActive(true); // �޽��� Ȱ��ȭ
        Invoke("HideMessage", displayTime); // ���� �ð� �� �޽��� �����
    }

    void HideMessage()
    {
        gameObject.SetActive(false); // �޽��� ��Ȱ��ȭ
    }
}
