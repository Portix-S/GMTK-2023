using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaiseTheDead : MonoBehaviour
{

    private bool canTrigger;
    public GameManager gm;
    public GameObject zombie;
    public bool isRaised;

    [SerializeField] GameObject obituary;
    [SerializeField] TextMeshProUGUI nomeUI;
    [SerializeField] TextMeshProUGUI sobrenomeUI;
    [SerializeField] TextMeshProUGUI dataUI;
    [SerializeField] TextMeshProUGUI mensagemUI;

    private string nome, sobrenome, data, mensagem;

    [SerializeField] Button raiseButton;
    [SerializeField] Button skipButton;

    public enum jobs {NA, DOCTOR, LAWYER, MECHANIC, KID, OLDMAN};
    public jobs job;

    void Start()
    {
        obituary.SetActive(false);
        gm.isMenuOpen = false;
        this.job = jobs.NA;
        this.canTrigger = false;
        this.isRaised = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            this.canTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            this.canTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canTrigger){
            if(Input.GetKeyDown(KeyCode.E)){
                if(this.job == jobs.NA) {
                    GenerateObituary();
                }
                raiseButton.onClick.AddListener(Raise);
                skipButton.onClick.AddListener(CloseObituary);
                this.UpdateUI();
                Debug.Log(isRaised);
                OpenObituary();
            }
            if(gm.isMenuOpen && Input.GetKeyDown(KeyCode.Escape)){
                CloseObituary();
            }
            
        }
    }

    public void OpenObituary(){
        Time.timeScale = 0f;
        // See obituary
        obituary.SetActive(true);
        gm.isMenuOpen = true;
    }

    public void CloseObituary(){
        Time.timeScale = 1f;
        raiseButton.onClick.RemoveAllListeners();
        skipButton.onClick.RemoveAllListeners();
        // Closes obituary
        obituary.SetActive(false);
        gm.isMenuOpen = false;
    }

    private void GenerateObituary(){
        this.job = (jobs) Random.Range(1, 6);
        Debug.Log(job);
        this.nome = gm.GenerateFirstName();
        this.sobrenome = gm.GenerateLastName();
        this.data = gm.GenerateDate(job);
        this.mensagem = gm.GenerateMessage(job);
        this.UpdateUI();

        Debug.Log(nome + " " + sobrenome);
        Debug.Log(data);
        Debug.Log(mensagem);
    }

    private void UpdateUI(){
        print(job);
        nomeUI.text = this.nome;
        sobrenomeUI.text = this.sobrenome;
        dataUI.text = this.data;
        mensagemUI.text = this.mensagem;

        raiseButton.enabled = !this.isRaised;
    }

    IEnumerator RaiseZombie(){
        yield return new WaitForSeconds(1.5f); // Wait for animation duration
        Transform spawnPos = GetComponentsInChildren<Transform>()[2];
        Instantiate(zombie, spawnPos.position, spawnPos.rotation);
    }
    public void Raise(){
        GetComponentInChildren<Animator>().enabled = true;
        if(!this.isRaised){
            this.isRaised = true;
            CloseObituary();
            StartCoroutine(RaiseZombie());
        }
    }
}
