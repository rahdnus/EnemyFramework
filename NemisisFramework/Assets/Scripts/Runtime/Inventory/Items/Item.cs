using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField]private ItemData refData;
    ItemData data;
    void Awake()
    {
        data=Instantiate(refData);
    }
    public void OnTriggerEnter(Collider other)
    {
        bool result= other.GetComponent<Entity>().inventory.AddtoInventory(ref data);
        if(result)
        {
            Destroy(gameObject);
        }
    }
}
