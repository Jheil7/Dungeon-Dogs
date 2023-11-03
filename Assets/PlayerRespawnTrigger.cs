using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnTrigger : MonoBehaviour
{
    public void RespawnTrigger() {
        gameObject.GetComponentInParent<PlayerRespawn>().Respawn();       
    }
}
