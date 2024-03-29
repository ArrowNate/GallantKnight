using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 200f;

    private float zAngle;

    private void Start()
    {
        if (Random.Range(0, 2) > 0) rotateSpeed *= -1;
    }

    private void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            GameoverUIController.instance.GameoverPanel();

            Destroy(collision.gameObject);
        }
    }
}