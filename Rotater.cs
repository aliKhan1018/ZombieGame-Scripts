using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    public float rotSpeed = 5f;


    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * rotSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //gun.MaxBulletCount += 20;
        }
    }
}
