using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWeaponController : MonoBehaviour
{
    public float fireRate = 20f;
    public float force = 80;

    public GameObject cameraGameObject;
    public ParticleSystem flash;
    public GameObject bullerEffect;
    private Animator animations;

    private float readyToFire;

    private void Start()
    {
        animations = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time >= readyToFire) {
            animations.SetInteger("Fire", -1);
        }

        if (Input.GetButton("Fire1") && Time.time >= readyToFire) {
            readyToFire = Time.time + 1f / fireRate;
            fire();
            animations.SetInteger("Fire", 2);
        }
    }
    /*private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time >= readyToFire) {
            readyToFire = Time.time + 1f / fireRate;
            fire();
        }
    }*/

    private void fire()
    {
        flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cameraGameObject.transform.position, cameraGameObject.transform.forward, out hit)) {
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
            Instantiate(bullerEffect,hit.point,Quaternion.LookRotation(hit.normal));
        }

    }
}
