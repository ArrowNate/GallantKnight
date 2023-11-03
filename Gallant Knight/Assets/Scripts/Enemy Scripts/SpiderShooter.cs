using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField] GameObject web;
    [SerializeField] private float minShootTime = 2f, maxShootTime = 5f;

    private float shootTimer;

    private Transform webSpawnPoint;

    private void Awake()
    {
        webSpawnPoint = transform.GetChild(0).transform;
    }

    private void Start()
    {
        //Invoke("ShootBullet", Random.Range(minShootTime, maxShootTime));
        shootTimer = Time.time + Random.Range(minShootTime, maxShootTime);
        //StartCoroutine(StartShooting());
    }

    private void Update()
    {
        if (Time.time > shootTimer)
        {
        ShootBullet();
        shootTimer = Time.time + Random.Range(minShootTime, maxShootTime);
        }
    }

    void ShootBullet()
    {
        Instantiate(web, webSpawnPoint.position, Quaternion.identity);
        //Invoke("ShootBullet", Random.Range(minShootTime, maxShootTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG)) Destroy(collision.gameObject);
    }

    /*    IEnumerator StartShooting()
        {
            yield return new WaitForSeconds(Random.Range(minShootTime, maxShootTime));
            ShootBullet();

            //StartCoroutine(StartShooting());
        }*/
}
