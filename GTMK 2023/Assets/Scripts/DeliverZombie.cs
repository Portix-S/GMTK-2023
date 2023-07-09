using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverZombie : MonoBehaviour
{
    public GameManager gm;
    public RaiseTheDead.jobs job;
    ZombieAI zai;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger detected");
        if(other.gameObject.tag == "Zombie"){
            Debug.Log("Zombie Delivered");
            zai = other.gameObject.GetComponent<ZombieAI>();
            if(!zai.isTakingKnockBack){
                Debug.Log("Not weee");
                return;
            }

            Debug.Log("Delivered");
            DoDeliver();
        }
    }

    private void DoDeliver(){
        if(job == zai.job)
            gm.points += 50;
        else 
            gm.points -= 30;

        Destroy(zai.gameObject);
        gm.Deliver();
    }
}
