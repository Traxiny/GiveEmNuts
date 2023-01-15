using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject motherTree;
    private Vector2 target;
    public bool slowed;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (slowed)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, (speed/2) * Time.deltaTime);

        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
