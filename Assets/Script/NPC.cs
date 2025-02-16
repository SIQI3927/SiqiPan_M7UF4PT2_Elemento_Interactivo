using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPC: MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    private PlayerController _playerMover;
    private bool _canBuy = true;
    private float time = 1f;
    public GameObject HUD;

    private void OnTriggerEnter(Collider other)
    {
        if(_canBuy)
       {
            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);


            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));

            _playerMover = other.GetComponent<PlayerController>();
            _playerMover.canMove = false;
            UI.SetActive(true);
            HUD.SetActive(false);
            _canBuy = false;
       }


    }

    private void OnTriggerExit(Collider other) 
    {
        StartCoroutine(WaitForABit());

    }

    public void ExitNPC()
    {
        
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Player"));
        HUD.SetActive(true);
        UI.SetActive(false);
        
        _playerMover.canMove = true;
    }

    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(time);
        _canBuy = true;

    }

}
