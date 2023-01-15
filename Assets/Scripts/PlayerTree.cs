using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTree : MonoBehaviour
{
    public float health = 3;
    [SerializeField]
    private GameControler gameControler;

    [SerializeField]
    private GameObject hpText;

    private TMP_Text hText;
    // Start is called before the first frame update
    void Start()
    {
        hText = hpText.GetComponent<TMP_Text>();
        hText.text = "HP :" + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        health--;
        hText.text = "HP :" + health;
        if (health <= 0)
        {
            gameControler.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
