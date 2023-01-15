using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomBomb : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //explosion particles and sfx
            audioSource.Play(); 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
