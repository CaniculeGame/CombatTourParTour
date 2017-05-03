using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string Intitule;
    public float Mana;
    public string IntituleType;
    public string Caracteristique;
    public float Power;
    public int animationA;
    public int animationB;
}

public class ScrollList : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public ScrollList otherShop;
    public SimpleObjectPool buttonObjectPool;
    public int Maxitem = -1;




    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }


    public void AddItem(Item itemToAdd, ScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }



    public int NombreItem() { return itemList.Count; }
    public bool MaxItemAtteint()
    {
        if (Maxitem == -1)
            return false;
        else if (itemList.Count < Maxitem && Maxitem != -1 )
            return false;
        else
            return true;
    }

    public void TryTransferItemToOtherList(Item item)
    {
        if (!otherShop.MaxItemAtteint())
        {
            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
        }
        Debug.Log("attempted");
    }
}