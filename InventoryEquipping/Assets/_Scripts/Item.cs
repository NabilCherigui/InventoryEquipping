using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Equip
{

    //PUT THIS ON EVERY ITEM
    [SerializeField] private string _bodyPart;

    [SerializeField] private string _itemType;
    
    public string BodyPart {get {return _bodyPart; }}
    public string ItemType {get {return _itemType; }}

}
