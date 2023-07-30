using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float speed;
    public float xRange;
    public float yRange;

    [SerializeField] Transform weapon;
    [SerializeField] float offset;

    [SerializeField] GameObject fireProjectile;
    [SerializeField] Transform shotPoint;
    [SerializeField] float fireRate;
    float nextFireTime = 0f;

    private void Update() {
        if (!PauseMenu.isPaused) {
            Movement();
            CheckBoundaries();
            WeaponRotation();
            FireProjectiles();
        }
    }

    private void Movement() {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += movementInput.normalized * speed * Time.deltaTime;
    }

    public void CheckBoundaries() {
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, 0);
        }

        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, 0);
        }

        if (transform.position.y > yRange) {
            transform.position = new Vector3(transform.position.x, yRange, 0);
        }

        if (transform.position.y < -yRange) {
            transform.position = new Vector3(transform.position.x, -yRange, 0);
        }
    }

    private void WeaponRotation() {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + offset);
    }

    private void FireProjectiles() {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime) {
            Instantiate(fireProjectile, shotPoint.position, shotPoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }
}
