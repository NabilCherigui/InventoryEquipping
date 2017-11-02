using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Equip Script
    [SerializeField] private Equip _equip;
    
    //Item Categories
    [SerializeField] private string[] _categories;
    
    //Menu that hold the Categories
    [SerializeField] private GameObject _inventoryList;
    
    //Object that holds the Category buttons
    [SerializeField] private GameObject _inventoryGrid;
    
    //Menu that hold the Items
    [SerializeField] private GameObject _inventoryListItems;
    
    //Object that holds the Item buttons
    [SerializeField] private GameObject _inventoryGridItems;
    
    //Button prefab
    [SerializeField] private GameObject _button;
    
    //List holding the Category buttons
    [SerializeField] private List<GameObject> _buttonsCategory;
    
    private RectTransform _inventoryGridRect;
    private RectTransform _inventoryGridItemsRect;

    private void Start()
    {
        _inventoryGridRect = _inventoryGrid.GetComponent<RectTransform>();
        _inventoryGridItemsRect = _inventoryGridItems.GetComponent<RectTransform>();
        
        for (var i = 0; i < _categories.Length; i++)
        {
            _buttonsCategory.Add(MakeChild(_inventoryGrid, _button));
            _buttonsCategory[i].GetComponentInChildren<Text>().text = _categories[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryList.SetActive(!_inventoryList.activeSelf);
            _inventoryListItems.SetActive(!_inventoryListItems.activeSelf);
            _inventoryGridRect.anchoredPosition = new Vector3(0,0,0);
            _inventoryGridItemsRect.anchoredPosition = new Vector3(0,0,0);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            _buttonsCategory.Add(MakeChild(_inventoryGrid, _button));
            
            for (var i = 0; i < _buttonsCategory.Count; i++)
            {
                _buttonsCategory[i].GetComponentInChildren<Text>().text = _equip.AllItems[i].name;
            }
        }
    }
    
    private GameObject MakeChild(GameObject parent, GameObject child)
    {
        var tempItem = Instantiate(child, parent.transform.position, parent.transform.rotation);
        tempItem.transform.SetParent(parent.transform, true);
        return tempItem;
    }
}
