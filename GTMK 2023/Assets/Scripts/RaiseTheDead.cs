using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaiseTheDead : MonoBehaviour
{

    private bool canTrigger;
    private bool isGraveOpen;
    public GameManager gm;

    [SerializeField] GameObject obituary;
    [SerializeField] TextMeshProUGUI nome;
    [SerializeField] TextMeshProUGUI sobrenome;
    [SerializeField] TextMeshProUGUI data;
    [SerializeField] TextMeshProUGUI mensagem;

    // Generate the description
    // Name values
    // Family Name values
    // Birth date / Death date
        // Age
    // Death Message
    public enum jobs {NA, DOCTOR, LAWYER, MECHANIC, KID, OLDMAN};
    public jobs job;

    void Start()
    {
        obituary.SetActive(false);
        job = jobs.NA;
        canTrigger = false;
        isGraveOpen = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            canTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canTrigger){
            if(Input.GetKeyDown(KeyCode.E)){
                if(job == jobs.NA) GenerateObituary();
                isGraveOpen = true;
                Time.timeScale = 0f;
                // See obituary
                obituary.SetActive(true);
            }
            if(isGraveOpen && Input.GetKeyDown(KeyCode.Escape)){
                isGraveOpen = false;
                Time.timeScale = 1f;
                // Closes obituary
                obituary.SetActive(false);
            }
            
        }
    }

    private void GenerateObituary(){
        job = (jobs) Random.Range(1, 6);
        Debug.Log(job);
        nome.text = gm.GenerateFirstName();
        sobrenome.text = gm.GenerateLastName();
        data.text = gm.GenerateDate(job);
        mensagem.text = gm.GenerateMessage(job);
    }
}
