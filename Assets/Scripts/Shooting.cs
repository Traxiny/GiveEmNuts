using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField]
    private AudioSource audioSource;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private bool fireMode = true;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update
    void Start()
    {
        mainCam =  Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);


        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        /*if (Input.GetKeyDown("space") && !fireMode)
        {
            fireMode = true;
        }
        else if (Input.GetKeyDown("space") && fireMode)
        {
            fireMode = false;
        }*/

        if (fireMode)
        {
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                audioSource.Play();
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }

        }


    }
}
