using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ItemBuildObject", menuName = "Inventory/Create ItemBuildObject")]
public class BuildItem : Item
{

    public GameObject prafabToBuild;
    public GameObject buildModel;
    BuildSystem BS;
    public override void Use()
    {
       
        BS = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<BuildSystem>();
        if (BS != null)
        {

            BS.setBuild(this.prafabToBuild, this.buildModel);
         
        }
          
        else Debug.Log("Nie znalezion Build System");
    }
    public override void UnUse()
    {
        BS = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<BuildSystem>();
        if (BS != null)
        {
                     
        }
        else Debug.Log("Nie znalezion Build System");
    }
}
