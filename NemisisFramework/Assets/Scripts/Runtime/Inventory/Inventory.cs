using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public List<ItemData> items=new List<ItemData>();
   public ItemData tempitem;
   [SerializeField] int MAX_WEIGHT=40;
    public int currentWeight=39;
/// <summary>
/// Adds item to Inventory and returns true when theres no residue
/// </summary>
    public bool AddtoInventory(ref ItemData item)
    {
        if (item.GetType() == typeof(Consumables_ItemData))
        {
            Consumables_ItemData newitem = item as Consumables_ItemData;
            if (currentWeight >= MAX_WEIGHT)
                return false;

            int newWeight=currentWeight+newitem.amount*newitem.weight;
            int residualamount=newWeight>MAX_WEIGHT?Mathf.CeilToInt((float)((newWeight-MAX_WEIGHT)%MAX_WEIGHT)/newitem.weight):0;
            int amounttoAdd=newitem.amount-residualamount;//holy shit wtf is this
           
           
            Debug.Log(residualamount);
            if(amounttoAdd!=0)
            {
                Consumables_ItemData consumable = FindConsumablesItem(newitem);
                if (consumable != null)
                {
                consumable.amount+=amounttoAdd;
                }
                else
                {
                items.Add(Instantiate(newitem));
                }
                currentWeight+=amounttoAdd*newitem.weight;
            }
             newitem.amount=residualamount;
            if(newitem.amount>0)
            {
                return false;
            }
            return true;
        }
       
        return false;
    }
    public void RemovefromInventory(ItemData item,int stock=0)
    {
        if (item.GetType() == typeof(Consumables_ItemData))
        {
            Consumables_ItemData refItem = item as Consumables_ItemData;

            Consumables_ItemData invItem = FindConsumablesItem(refItem);
            if (invItem == null)
                return;
            
            int decr=invItem.amount>stock?stock:invItem.amount;
            

            invItem.amount-=decr;
            if(invItem.amount<=0)
                items.Remove(invItem);

            currentWeight-=decr*refItem.weight;
        }

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            RemovefromInventory(tempitem,3);
        }
    }
     public Consumables_ItemData FindConsumablesItem(Consumables_ItemData item)
    {
        if (items.Find(x=>x.data_ID==item.data_ID))        
        foreach(ItemData a in items)
        {
            if (a.GetType() == typeof(Consumables_ItemData))
            {
                if (a.data_ID == item.data_ID)
                {
                    return a as Consumables_ItemData;  
                }
            }
       }
       return null;
    }
    
}
// public class Slot
// {
//     public ItemData itemData;
//     public int inventoryindex;
//     public Slot(ItemData itemData,int inventoryindex)
//     {
//         this.itemData=itemData;
//         this.inventoryindex=inventoryindex;
//     }
// }
