using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float recoil;
    public Rigidbody kickPoint;
    public GameObject shell;
    public Transform firingPos;
    public float fireSpeed;
    public float rotSpeed;
    public bool allowFire;
    public float fireRate;


    private Vector3 mousePos;
    private Rigidbody rb;

    private void Start()
    {
        allowFire = true;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - transform.position.y));
        Vector3 direction = mousePos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Fire1")&&(allowFire))
        {
            Fire();
        }
    }
    public void Fire()
    {
        allowFire = false;
        GameObject projectile = Instantiate(shell, firingPos.position, transform.rotation);
        rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * fireSpeed;
        kickPoint.AddForce(-transform.forward * recoil);
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
