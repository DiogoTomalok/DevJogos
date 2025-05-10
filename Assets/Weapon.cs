using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision){
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
    }
}
