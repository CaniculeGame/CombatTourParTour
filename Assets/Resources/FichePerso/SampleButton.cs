using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;


    private Item item;
    private ScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, ScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.Intitule +  "  MP " +item.Mana+"  TPE " + item.IntituleType+ "   CAR "+ item.Caracteristique + "  FOR: "+item.Power;
        scrollList = currentScrollList;
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherList(item);
    }
}