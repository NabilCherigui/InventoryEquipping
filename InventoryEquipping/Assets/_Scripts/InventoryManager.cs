using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
//My first attempt
    [SerializeField] private GameObject[] _bodyParts;
    private Dictionary <string, GameObject> _body = new Dictionary<string, GameObject>();
    
    [SerializeField] private bool _equipHelmet;
    [SerializeField] private bool _helmetOn;
    [SerializeField] private GameObject _selectedItem;
    
    [SerializeField] private GameObject[] _itemsHead, _itemsTorso, _itemsArmLeft, _itemsArmRight, _itemsLegLeft, _itemsLegRight;
    private Dictionary <string, GameObject> _headItems = new Dictionary<string, GameObject>();
    private Dictionary <string, GameObject> _torsoItems = new Dictionary<string, GameObject>();
    private Dictionary <string, GameObject> _armLeftItems = new Dictionary<string, GameObject>();
    private Dictionary <string, GameObject> _armRightItems = new Dictionary<string, GameObject>();
    private Dictionary <string, GameObject> _legLeftItems = new Dictionary<string, GameObject>();
    private Dictionary <string, GameObject> _legRightItems = new Dictionary<string, GameObject>();
    
    private Dictionary <string, GameObject> _equipedItems = new Dictionary<string, GameObject>();
    
    private GameObject _tempHelmet;

    private void Start() 
    {
        ArrayToDictionary(_bodyParts, _body);
        ArrayToDictionary(_itemsHead, _headItems);
        ArrayToDictionary(_itemsTorso, _torsoItems);
        ArrayToDictionary(_itemsArmLeft, _armLeftItems);
        ArrayToDictionary(_itemsArmRight, _armRightItems);
        ArrayToDictionary(_itemsLegLeft, _legLeftItems);
        ArrayToDictionary(_itemsLegRight, _legRightItems);
        
        /*for (var i = 0; i < _bodyParts.Length; i++)
        {
            _body.Add(_bodyParts[i].name, _bodyParts[i]);
        }*/

        _selectedItem = _itemsHead[0];
    }
    
    private void Update()
    {

        if (_selectedItem)
        {
            for (int i = 0; i < _itemsHead.Length; i++)
            {
                if (_selectedItem == _itemsHead[i])
                {
                    if (_body["Head"].transform.childCount > 1)
                    {
                        print("bluytay");
                        foreach (Transform child in _body["Head"].transform)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    _equipedItems.Add("Head", Equip(_body["Head"], _headItems[_itemsHead[i].name]));
                }
            }
            for (int i = 0; i < _itemsTorso.Length; i++)
            {
                if (_selectedItem == _itemsTorso[i])
                {
                    Equip(_body["Torso"], _torsoItems[_itemsTorso[i].name]);
                }
            }
            for (int i = 0; i < _itemsArmLeft.Length; i++)
            {
                if (_selectedItem == _itemsArmLeft[i])
                {
                    Equip(_body["ArmLeft"], _armLeftItems[_itemsArmLeft[i].name]);
                }
            }
            for (int i = 0; i < _itemsArmRight.Length; i++)
            {
                if (_selectedItem == _itemsArmRight[i])
                {
                    Equip(_body["ArmRight"], _armRightItems[_itemsArmRight[i].name]);
                }
            }
            for (int i = 0; i < _itemsLegLeft.Length; i++)
            {
                if (_selectedItem == _itemsLegLeft[i])
                {
                    Equip(_body["LegLeft"], _legLeftItems[_itemsLegLeft[i].name]);
                }
            }
            for (int i = 0; i < _itemsLegRight.Length; i++)
            {
                if (_selectedItem == _itemsLegRight[i])
                {
                    Equip(_body["RightLeft"], _legRightItems[_itemsLegRight[i].name]);
                }
            }
            
        }
                
        if (_helmetOn == false && _equipHelmet)
        {
            _tempHelmet = Equip(_body["Head"], _selectedItem);
            _helmetOn = true;
        }
        else if(_equipHelmet == false)
        {
            Destroy(_tempHelmet);
            _helmetOn = false;
        }
    }

    private GameObject Equip(GameObject bodyPart, GameObject item)
    {
        var tempItem = Instantiate(item, bodyPart.transform.position, bodyPart.transform.rotation);
        tempItem.transform.SetParent(bodyPart.transform, true);
        return tempItem;
    }

    private void ArrayToDictionary(GameObject[] array, Dictionary<string,GameObject> dictionary)
    {
        for (var i = 0; i < array.Length; i++)
        {
            dictionary.Add(array[i].name, array[i]);
        }
    } 
}
    