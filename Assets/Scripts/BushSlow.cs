using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushSlow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy tmp = collision.gameObject.GetComponent<Enemy>();
            tmp.slowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy tmp = collision.gameObject.GetComponent<Enemy>();
            tmp.slowed = false;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
