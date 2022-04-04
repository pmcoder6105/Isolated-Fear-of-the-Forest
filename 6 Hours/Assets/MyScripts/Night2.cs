using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject StockHomeSupplies;
    [SerializeField] GameObject OrderCleaningSupplies;
    [SerializeField] GameObject Appliances;
    Vector3 MainScreenPos;
    Vector3 StockHomeSuppliesPos;
    Vector3 OrderCleaningSuppliesPos;
    Vector3 AppliancesPos;

    // Start is called before the first frame update
    void Start()
    {
        MainScreenPos = MainScreen.transform.position;
        StockHomeSuppliesPos = StockHomeSupplies.transform.position;
        OrderCleaningSuppliesPos = OrderCleaningSupplies.transform.position;
        AppliancesPos = Appliances.transform.position;
        this.gameObject.GetComponent<Animator>().Play("EnterRoomNight2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        MainScreen.transform.position = MainScreenPos;
        StockHomeSupplies.transform.position = StockHomeSuppliesPos;
        OrderCleaningSupplies.transform.position = OrderCleaningSuppliesPos;
        Appliances.transform.position = AppliancesPos; 
    }
}
