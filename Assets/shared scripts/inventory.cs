
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public TextMeshProUGUI inventorytext;
    bool isOpened = false;
    public GameObject inventoryPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            isOpened = !isOpened;
            inventoryPanel.SetActive(isOpened);
        
           
            Debug.Log("c");

        }
    }
    List<Item>Inventory = new List<Item>()
    {
        new Potions()
        {
            name = "Gems" ,Quantity  = 1 ,Heal = 100
        }
    };

    public class Item {
        public string name;
        public int Quantity;

    }
    public class Potions:Item {
        public int Heal;
    }
    public void Additem(string itemNAme)
    {
        inventorytext.text += itemNAme + "\n"; 

    }

}
