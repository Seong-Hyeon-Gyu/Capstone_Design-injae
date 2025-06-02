using System.Collections;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    // Y축 회전 설정
    [Header("Y(MAX/MIN)")]
    public float maxY = 50f;
    public float minY = -50f;
    [Header("Delta Angle")]
    public float stepAngle = 10f;

    private float currentY;
    private bool increasing = true; // true면 증가, false면 감소
    [Header("speed")]
    public float rotationSpeed = 5f;  // 회전 속도도
    private float lastTime = 0f; // 마지막 발사 시각

    void Start()
    {
        // 시작 시 현재 Y 회전값 초기화 (월드 기준)
        float rawY = transform.eulerAngles.y;
        currentY = (rawY > 180f) ? rawY - 360f : rawY;
    }

    void Update()
    {
        if (Time.time - lastTime > rotationSpeed)
        {
            StartCoroutine(Movement());
            lastTime = Time.time;
        }
        
    }

    /// <summary>
    /// Y축 회전값을 maxY, minY 사이에서 왕복하며
    /// maxY 만나면 stepAngle만큼 감소, minY 만나면 stepAngle만큼 증가
    /// </summary>
    IEnumerator Movement()
    {
        if (increasing)
        {
            currentY += stepAngle;
            if (currentY >= maxY)
            {
                currentY = maxY;
                increasing = false;
            }
        }
        else
        {
            currentY -= stepAngle;
            if (currentY <= minY)
            {
                currentY = minY;
                increasing = true;
            }
        }

        // 적용: 월드 Y 회전 설정
        Vector3 euler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(euler.x, currentY, euler.z);

        yield return new WaitForSeconds(10f);
    }
}
