using UnityEngine;
using TMPro;  // �� TextMeshPro

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;  // �������ʴ���ṹ� UI (TextMeshPro)
    private int score = 0;  // ��ṹ�������

    void Start()
    {
        UpdateScoreText();  // ������鹡���ʴ���ṹ
    }

    // �ѧ��ѹ����Ѻ������ṹ
    public void AddScore(int points)
    {
        score += points;  // ������ṹ
        UpdateScoreText();  // �Ѿവ UI
    }

    // �Ѿവ��ͤ�������ʴ���ṹ
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;  // �Ѿവ��ͤ���
    }
}
