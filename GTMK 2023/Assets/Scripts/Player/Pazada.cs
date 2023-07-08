using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazada : MonoBehaviour
{
    private bool isAttacking;
    private BoxCollider pa;
    public float kbForce = 10f, kbDelay = .5f;

    private void Start() {
        pa = GetComponent<BoxCollider>();
    }

    private float attackDuration = 1f;
    private float attackTimer;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && attackTimer <= 0f){
            Debug.Log("Attacking...");
            attackTimer = attackDuration;
            isAttacking = true;
            pa.enabled = true;
        }

        if(attackTimer > 0f){
            attackTimer -= Time.deltaTime;
        }
        else if(isAttacking){
            isAttacking = false;
            pa.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit! Target: " + other.gameObject.tag);
        if(other.gameObject.tag == "Zombie"){
            Vector3 playerPos = transform.position;
            Vector3 zombiePos = other.gameObject.transform.position;
            Vector3 knockbackDir = new Vector3(zombiePos.x - playerPos.x, 0, zombiePos.z - playerPos.z).normalized;

            Debug.Log(knockbackDir);
            Rigidbody zombieRb = other.gameObject.GetComponentInChildren<Rigidbody>();
            zombieRb.AddForce(knockbackDir * kbForce, ForceMode.Impulse);
            StartCoroutine(KnockBackCooldown(zombieRb));

            ZombieAI zombieAi = other.gameObject.GetComponent<ZombieAI>();
            if(zombieAi.state != ZombieAI.states.FOLLOW){
                StartCoroutine(zombieAi.Follow());
            }
        }
    }

    IEnumerator KnockBackCooldown(Rigidbody rb){
        yield return new WaitForSeconds(kbDelay);
        rb.velocity = Vector3.zero;
    }
}
