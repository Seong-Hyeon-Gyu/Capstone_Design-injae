using UnityEngine;
using TMPro;

public class textS : MonoBehaviour
{
    // Legacy Text 대신 TMP_Text 또는 TextMeshProUGUI 사용
    private TMP_Text Msg;
    public ObjectManager om;

    void Start()
    {
        Msg = GetComponent<TMP_Text>();  // 또는 GetComponent<TextMeshProUGUI>();
        if (Msg == null) 
            Debug.LogError("TMP_Text component 이 스크립트가 붙은 오브젝트에 없습니다!");
        
        om = FindObjectOfType<ObjectManager>();
    }

    void Update()
    {
        Msg.text = $"점수: {ObjectManager.Score}\n레벨: {ObjectManager.Level}\n찬스: \u2665*{ObjectManager.life}";
    }
}