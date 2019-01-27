using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();    
    }
    // Update is called once per frame
    void Update()
    {
        // If left mouse is down and pointer is over game object
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            GetInteraction();
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Output raycast info to interactionInfo
        RaycastHit interactionInfo;

        // Hit an object with a raycast, store it as an interacted object so we 
        // can do something with it later on

        // If our ray hits
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            // Get game object of collider that our ray hit
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                // Get the interactable component of the interacted object
                // and move to it
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
;            }
            else // Player agent not interactable object
            {
                playerAgent.stoppingDistance = 0;
                // Set player destination to the click point
                playerAgent.destination = interactionInfo.point;
            }
        }
    }

}
