using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;                      //�� �ӵ�

    public float rotationSpeed = 1f;
    public GameObject bulletPrefab;
    public GameObject EnemyPivot;
    public Transform firePoint;
    public float fireRate = 1f;
    public float nextFireTime;
    private Rigidbody rb;                           //������ �ٵ� ����
    private Transform player;                   //�÷��̾� ��ġ ����
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                         //�ڱ� �ڽ��� ������ �ٵ� �� �Է�
        GameObject Temp = GameObject.FindGameObjectWithTag("Player");                      //�÷��̾��� ��ġ �� �Է�

        if (Temp != null)
        {
            player = Temp.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        


            if (Vector3.Distance(player.position, transform.position) > 0.5f)                                          //Vector3.Distance �Ÿ� ���� �Լ�
            {
                Vector3 direction = (player.position - transform.position).normalized;                  //�÷��̾�� ���� ��ġ ���͸� �����Ͽ� ���� ���͸� ����
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);           //���̵�
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
