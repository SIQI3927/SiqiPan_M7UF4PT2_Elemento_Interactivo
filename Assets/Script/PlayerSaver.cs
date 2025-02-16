using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    public Transform player;
    
    private void OnTriggerEnter(Collider other)
    {
        player = other.transform;
        SavePositionRotation();
    }

    private void SavePositionRotation()
    {
        PlayerPrefs.SetFloat("playerPosX", player.position.x);
        PlayerPrefs.SetFloat("playerPosY", player.position.y);
        PlayerPrefs.SetFloat("playerPosZ", player.position.z);
        
        PlayerPrefs.SetFloat("playerRotX", player.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("playerRotY", player.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("playerRotZ", player.rotation.eulerAngles.z);


        Debug.Log("Player position and rotation saved.");
    }
}
