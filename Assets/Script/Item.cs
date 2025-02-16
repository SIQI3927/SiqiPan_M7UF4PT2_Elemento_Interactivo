using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    public int ID;
    public Sprite Sprite;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Item" + ID) == 1)
        {
            GameManager.gameManager.ItemCollected(Sprite, ID);
            Destroy(gameObject);
            
        }

    }
    public void OnCollected()
    {
        GameManager.gameManager.ItemCollected(Sprite, ID);
        Destroy(gameObject);

        PlayerPrefs.SetInt("Item" + ID, 1);
    }



}
