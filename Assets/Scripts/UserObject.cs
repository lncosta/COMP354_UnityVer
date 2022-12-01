using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserObject : MonoBehaviour
{
    [SerializeField] UserData _data;
    public UserData Data { get => _data; }
}
