using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

    //All the body parts
    [SerializeField] private GameObject[] _bodyParts;
    private Dictionary <string, GameObject> _body = new Dictionary<string, GameObject>();

    //All equippable  items
    [SerializeField] private GameObject[] _allItems;
    private Dictionary <string, GameObject> _items = new Dictionary<string, GameObject>();
    public GameObject[] AllItems {get {return _allItems; }}
    
    //All equipped  items
    private Dictionary <string, GameObject> _itemsEquiped = new Dictionary<string, GameObject>();

    [SerializeField] private List<string> _itemsSelected;

    private void Start() 
    {
        ArrayToDictionary(_bodyParts, _body);
        ArrayToDictionary(_allItems, _items);
        
        _itemsSelected.Add("ArmPieceLeft1");
        _itemsSelected.Add("ArmPieceRight1");
        _itemsSelected.Add("LegPieceLeft1");
        _itemsSelected.Add("LegPieceRight1");
        _itemsSelected.Add("Helmet1");
        _itemsSelected.Add("ChestPiece1");

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _itemsEquiped.Clear();

            for (var i = 0; i < _bodyParts.Length; i++)
            {
                foreach (Transform child in _bodyParts[i].transform) 
                {
                    Destroy(child.gameObject);
                }
            }
            
            for (var i = 0; i < _itemsSelected.Count; i++)
            {
                _itemsEquiped.Add(_items[_itemsSelected[i]].name,_items[_itemsSelected[i]]);
                MakeChild(_body[_itemsEquiped[_itemsSelected[i]].GetComponent<Item>().BodyPart],_itemsEquiped[_itemsSelected[i]]);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _itemsSelected.RemoveAt(4);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _itemsSelected.Add("Helmet");
        }
    }

    private void ArrayToDictionary(GameObject[] array, Dictionary<string, GameObject> dictionary)
    {
        for (var i = 0; i < array.Length; i++)
        {
            dictionary.Add(array[i].name, array[i]);
        }
    }
    
    private GameObject MakeChild(GameObject parent, GameObject child)
    {
        var tempItem = Instantiate(child, parent.transform.position, parent.transform.rotation);
        tempItem.transform.SetParent(parent.transform, true);
        return tempItem;
    }
}
