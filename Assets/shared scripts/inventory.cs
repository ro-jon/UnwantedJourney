
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inventory : MonoBehaviour
{

    public TextMeshProUGUI inventorytext;
    bool isOpened = false;
    public GameObject inventoryPanel;
    private void Awake()
    {


    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.DeleteKey("inventory");
        }
        loadInventory();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed ");
            if (Inventory.Count > 0)
            {
                Inventory[0].Use(gameObject);
                Inventory.RemoveAt(0);
                UpdateText();
                Debug.Log("new Count" + Inventory.Count);


            }
        }
        //first chcek if the panel is active or not with bool 

        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            // toggle it ,
            inventoryPanel.SetActive(isOpened);


            Debug.Log("c");

        }
    }
    List<Item> Inventory = new List<Item>()
    {
        
    };


    List<string> names = new List<string>()
    
    {
        
    };


    public class Item
    {
        public string name;
        public int Quantity;
        public virtual void Use(GameObject PLAYER)
        {
            
            
            
            
        }

    }
    public class Potions : Item
    {
        public int Heal=100;
        public override void Use(GameObject PLAYER)
        {
            playerMovement pm = PLAYER.GetComponent<playerMovement>();
            pm.CurrentHealth += Heal;
            pm.HealthBar.value = pm.CurrentHealth;
            Debug.Log("consume");

        }
    }
    public class Weapons : Item
    {
        public override void Use(GameObject PLAYER)
        {
            Debug.Log("empty");
        }
    }
    public void Additem(string itemNAme)
    {
        inventorytext.text += itemNAme + "\n";
        Item newItem;
        {
            if (itemNAme == "Potions")
            {
                newItem = new Potions();
            }
            else if (itemNAme == "Sword")
            {
                newItem = new Weapons();

            }
            else
            {
                newItem = new Item();
            }
            newItem.name = itemNAme;
            Inventory.Add(newItem);
            SaveInventory();    


        }
    }

   
       

    
    public void UpdateText()
    {
        inventorytext.text = "";

        foreach (Item item in Inventory)
        {
            inventorytext.text += item.name + "\n";
        }

    }
    public void SaveInventory()
    {
        foreach(Item item in Inventory)
        {
            names.Add(item.name);
        }
        string saved = string.Join(",", names);
        PlayerPrefs.SetString("inventory", saved);
        Debug.Log("saved" + saved);
    }
    void loadInventory()
    {
        string saved = PlayerPrefs.GetString("inventory");
        if (saved == "")
            return;
        string[] itemNames  = saved.Split(',');
        foreach (string itemName in itemNames)
        {
            Additem(itemName);
        }
    }
}
