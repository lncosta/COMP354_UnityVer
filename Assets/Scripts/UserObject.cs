using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[SerializeField]
public class UserObject
{
    [SerializeField] UserData _data;
    [SerializeField] public UserData Data { get => _data; set { _data = value; } }
}
