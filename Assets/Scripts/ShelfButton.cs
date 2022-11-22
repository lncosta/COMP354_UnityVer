using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButton : MonoBehaviour
{

    public ShelfType thisShelfType;

    public ShelfManager shelfManager; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAction()
    {
       shelfManager.setActive(thisShelfType);
    }
}
