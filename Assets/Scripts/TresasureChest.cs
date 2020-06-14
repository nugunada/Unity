using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresasureChest : MonoBehaviour
{
    public bool interactable = false;
    private Animator anim;

    public Rigidbody coinPrefab;
    public Transform spawner;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("openChest", true) ;//상자를 열고

            //코인 인스턴스를 생성
            Rigidbody coinInstance;
            coinInstance = Instantiate(coinPrefab, spawner.position, spawner.rotation) as Rigidbody;
            coinInstance.AddForce(spawner.up * 100);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactable = true;           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
}
