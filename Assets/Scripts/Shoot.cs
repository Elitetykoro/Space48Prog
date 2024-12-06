using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shooting : MonoBehaviour
{
    private float cooldownCounter = 0f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] public float cooldownTime = 3f;

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }
    }
}
