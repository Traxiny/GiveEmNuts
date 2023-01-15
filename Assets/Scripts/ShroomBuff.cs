using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomBuff : MonoBehaviour
{
    private Shooting shooting;
    private TreeTurret treeTurret;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MotherTree"))
        {
            shooting = collision.GetComponentInChildren<Shooting>();
            shooting.timeBetweenFiring -= 0.1f;
        }else if (collision.CompareTag("TreeTurret"))
        {
            treeTurret = collision.GetComponent<TreeTurret>();
            treeTurret.timeBetweenFiring -= 0.05f;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
