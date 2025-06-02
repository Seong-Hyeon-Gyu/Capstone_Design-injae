using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
//LowpolyHands Object
public class MotionTest : MonoBehaviour
{
    private Controller controller;
    [Header("fist detection")]
    [Tooltip("1에 가까울수록 꽉 쥔 상태를 의미")]
    [Range(0f, 1f)]
    public float fistThreshold = 0.8f;

    private bool wasFist = false;

    public bool isFist=false;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        if (frame.Hands.Count == 0)
        {
            if (isFist)
                //Debug.Log("[MotionTest] 손 소실로 주먹 해제");
            isFist = false;
            wasFist = false;
            return;
        }
        Hand hand = frame.Hands[0];
        

        float grabStrength = hand.GrabStrength; // 0 (편 상태) ~ 1 (꽉 쥔 상태)
        
        // 현재 프레임이 주먹 상태인지
        isFist = grabStrength >= fistThreshold;

        if (isFist && !wasFist)
        {
            //Debug.Log($"[MotionTest] 주먹 모양 감지! GrabStrength: {grabStrength:F2}");
        }
        else if (!isFist && wasFist)
        {
            //Debug.Log($"[MotionTest] 주먹 모양 해제. GrabStrength: {grabStrength:F2}");
        }

        wasFist = isFist;
    }
}
