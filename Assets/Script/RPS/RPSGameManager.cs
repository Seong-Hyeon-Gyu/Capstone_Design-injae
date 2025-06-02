using Leap;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RPSGameManager : MonoBehaviour
{
    [Header("Hand Pose Detector Reference")]
    public HandPoseDetector handPoseDetector;

    [Header("UI References")]
    public Button restartButton;
    public Text resultText;

    private bool roundEnded = false;

    private void Start()
    {
        if (handPoseDetector == null)
        {
            Debug.LogError("HandPoseDetector is not assigned.");
            return;
        }

        // 이벤트 바인딩
        handPoseDetector.OnPoseDetected.AddListener(OnPlayerPoseDetected);

        // UI 초기화
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

        resultText.text = "손 모양으로 가위/바위/보를 내세요!";
    }

    private void OnPlayerPoseDetected()
    {
        if (roundEnded) return;

        var pose = handPoseDetector.GetCurrentlyDetectedPose();
        if (pose == null) return;

        string poseName = pose.name.ToLower(); // 이름 기준 판단
        string result = "";

        if (poseName.Contains("rock"))
        {
            result = "👊 바위를 냈습니다!";
        }
        else if (poseName.Contains("paper"))
        {
            result = "✋ 보를 냈습니다!";
        }
        else if (poseName.Contains("scissors"))
        {
            result = "✌️ 가위를 냈습니다!";
        }
        else
        {
            result = "알 수 없는 포즈입니다.";
        }

        // 결과 출력
        resultText.text = result;
        roundEnded = true;

        // 버튼 활성화
        restartButton.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        // 게임 리셋
        roundEnded = false;
        resultText.text = "손 모양으로 가위/바위/보를 내세요!";
        restartButton.gameObject.SetActive(false);
    }
}
