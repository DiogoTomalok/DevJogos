using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{
    public Animator animator;
    public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.25f;
    float atkTimer = 0f;

    // Update is called once per frame
    void Update(){
        CheckMeleeTimer();
        if(Input.GetKeyDown(KeyCode.F) || Input.GetMouseButton(0)){
            OnAttack();
        }
    }

    public void OnAttack(){
        if(!isAttacking){
            Melee.SetActive(true);
            isAttacking = true;
            animator.SetTrigger("Attack");
        }
    }

    public void CheckMeleeTimer(){
        if(isAttacking){
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDuration){
                atkTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
            }
        }
    }
}
