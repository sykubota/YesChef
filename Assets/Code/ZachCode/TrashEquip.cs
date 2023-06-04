using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TrashEquip : MonoBehaviour
{
    public GameObject Trash;
    public Transform TrashParent;
    public bool isCarrying = false;

    private void Start()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Update()
    {
        
    }


    void Equip()
    {
        if(!isCarrying)
        {
            Trash.GetComponent<Rigidbody>().isKinematic = true;

            Trash.transform.position = TrashParent.transform.position;
            Trash.transform.rotation = TrashParent.transform.rotation;

            Trash.transform.SetParent(TrashParent);
            Trash.GetComponent<ConveyorBelt>().enabled = false;
            Trash.GetComponent<BoxCollider>().enabled = true;
            isCarrying = true;
        }
        
        


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isCarrying)  
        {
           
            if (Input.GetKey(KeyCode.Space))
            {
                Equip();
                

            }
            
      
                        
            }
        
        

        }
    }