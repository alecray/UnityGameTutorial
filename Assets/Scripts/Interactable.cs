using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
 * Interactable class
 */
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        // Set the player's destination = to this Interactable's position
        playerAgent.destination = this.transform.position;
    }

    void Update()
    {
        // Check if hasn't interacted
        // And we have a player agent
        // And a path is not pending
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public virtual void Interact()
    {
        // interacting w/ base class not NPC
        Debug.Log("Interacting with base class.");
    }
}
