using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public void RespawnTrigger() {
        gameObject.GetComponentInParent<PlayerRespawn>().Respawn();       
    }
}
