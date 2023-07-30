using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int projectileDamageAmount = 5;
    [SerializeField] float projectileSpeed;

    private void Update() {
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Border") {
            Destroy(gameObject);
        }
    }
}
