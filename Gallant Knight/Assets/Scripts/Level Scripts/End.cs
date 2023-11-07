using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            GameoverUIController.instance.GameoverPanel();

            Destroy(collision.gameObject);
        }
    }
}
