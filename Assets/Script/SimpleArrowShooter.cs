using UnityEngine;

public class SimpleArrowShooter : MonoBehaviour
{
    [SerializeField] Transform shootPoint;              // �ش�ԧ�١���
    [SerializeField] Rigidbody2D arrowPrefab;           // ���Ὼ�ͧ�١���
    [SerializeField] float arrowSpeed = 10f;            // ���������١���
    [SerializeField] int maxArrows = 3;                 // �ӹǹ�١����٧�ش
    [SerializeField] ArrowUIManager arrowUIManager;     // ��ҧ�֧ UI �ͧ�١���

    private int arrowsLeft;

    void Start()
    {
        arrowsLeft = maxArrows;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && arrowsLeft > 0)
        {
            // ���˹觢ͧ�������š��ԧ
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            // �ӹǳ��ȷҧ����ԧ
            Vector2 direction = (mouseWorldPos - shootPoint.position).normalized;

            // ���ҧ�١���
            Rigidbody2D arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

            // ��ع�١�������ѹ�����ȷҧ
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle);

            // ��˹����������١���
            arrow.linearVelocity = direction * arrowSpeed;

            // �ѡ�ӹǹ�١��ٷ�������
            arrowsLeft--;

            // ź�ͤ͹�١���� UI
            if (arrowUIManager != null)
            {
                arrowUIManager.UseArrow();
            }
        }
    }
}
