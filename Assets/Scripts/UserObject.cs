using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserObject
{
    [SerializeField] UserData _data;
    public UserData Data { get => _data; set { _data = value; } }
}
