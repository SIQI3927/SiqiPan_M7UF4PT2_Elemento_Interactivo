using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSaver : MonoBehaviour
{
    public int ID;

    private void Start()
    {

        if(PlayerPrefs.HasKey("Orb" + ID) && PlayerPrefs.GetInt("Orb" + ID) == 1)
            LoadOrb();

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Orb" + ID, 1);
    }

    public void LoadOrb()
    {
        GameManager.gameManager.OrbCollected();
        gameObject.SetActive(false);
    }
}
