using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;                      //적 속도

    public float rotationSpeed = 1f;
    public GameObject bulletPrefab;
    public GameObject EnemyPivot;
    public Transform firePoint;
    public float fireRate = 1f;
    public float nextFireTime;
    private Rigidbody rb;                           //리지드 바디 선언
    private Transform player;                   //플레이어 위치 선언
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                         //자기 자신의 리지드 바디 값 입력
        GameObject Temp = GameObject.FindGameObjectWithTag("Player");                      //플레이어의 위치 값 입력

        if (Temp != null)
        {
            player = Temp.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        


            if (Vector3.Distance(player.position, transform.position) > 0.5f)                                          //Vector3.Distance 거리 지원 함수
            {
                Vector3 direction = (player.position - transform.position).normalized;                  //플레이어와 나의 위치 백터를 뺄샘하여 방향 백터를 설정
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);           //적이동
            }

            Vector3 targetDirection = (player.position - EnemyPivot.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            EnemyPivot.transform.rotation =
                Quaternion.Lerp(EnemyPivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time * 1f / fireRate;
            GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            temp.GetComponent<ProjectileMove>().launchDirection = firePoint.localRotation * Vector3.forward;
            temp.GetComponent<ProjectileMove>().projecectiletype = ProjectileMove.PROJECTILETYPE.ENEMY;
        }
    }
    
}
