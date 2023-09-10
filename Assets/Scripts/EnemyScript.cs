using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyParticles;
    private void OnCollisionEnter2D(Collision2D collision) {
        bool isColloid = collision.collider.GetComponent<AngryBird>() != null;
        if(isColloid == true) {
            Destroy(gameObject);
            Instantiate(enemyParticles, transform.position, Quaternion.identity);
        }
    }
}
