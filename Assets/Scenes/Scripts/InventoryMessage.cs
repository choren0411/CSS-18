using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText; // 메시지 텍스트
    public float displayTime = 2f; // 메시지가 표시되는 시간

    public void ShowMessage(string message)
    {
        messageText.text = message; // 메시지 설정
        gameObject.SetActive(true); // 메시지 활성화
        Invoke("HideMessage", displayTime); // 일정 시간 후 메시지 숨기기
    }

    void HideMessage()
    {
        gameObject.SetActive(false); // 메시지 비활성화
    }
}
