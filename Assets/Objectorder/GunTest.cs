using UnityEngine;
//Gun 오브젝트트
public class GunTest : MonoBehaviour
{

    [Header("bullet")]
    public GameObject bulletPrefab;

    [Header("shot speed")]
    public float bulletSpeed = 20f;

    // Pistol_A_Barrel 트랜스폼 참조
    private Transform barrel;
    public float fireCooldown = 5f;  // 발사 간격 (초)
    private float lastFireTime = 0f; // 마지막 발사 시각

    public GameObject player;
    private MotionTest other;

    void Start()
    {

        barrel = transform.Find("Pistol_A_Barrel");
        if (barrel == null)
            Debug.LogError("자식 오브젝트 'Pistol_A_Barrel'을 찾을 수 없습니다.");

        other = player.GetComponent<MotionTest>();
        if (other == null)
            Debug.LogError("Player에 OtherScript가 없습니다!");
    }

    void Update()
    {
        
        if (other.isFist && Time.time - lastFireTime > fireCooldown)
        {
            //Debug.Log("[GunTest] 조건 충족: Shot() 호출");
            Shot();
            lastFireTime = Time.time;
        }
    }
    public void Shot()
    {
        if (barrel == null || bulletPrefab == null) return;

        
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);

        //Rigidbody를 이용해 속도 부여
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = barrel.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("발사된 프리팹에 Rigidbody 컴포넌트가 없습니다.");
        }

        Destroy(bullet, 10f);
    }
    
}
