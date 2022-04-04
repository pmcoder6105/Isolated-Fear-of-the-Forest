using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject StockHomeSupplies;
    [SerializeField] GameObject OrderCleaningSupplies;
    [SerializeField] GameObject Appliances;
    [SerializeField] GameObject laptop;
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
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        MainScreen.transform.position = MainScreenPos;
        StockHomeSupplies.transform.position = StockHomeSuppliesPos;
        OrderCleaningSupplies.transform.position = OrderCleaningSuppliesPos;
        Appliances.transform.position = AppliancesPos;
        //if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(laptop))
        //{
        //
        //}
        
    }

    void OnMouseOver()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        MainScreen.SetActive(true);
        StockHomeSupplies.SetActive(true);
        OrderCleaningSupplies.SetActive(true);
        Appliances.SetActive(true);
    }
    private void OnMouseExit()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        MainScreen.SetActive(false);
        StockHomeSupplies.SetActive(false);
        OrderCleaningSupplies.SetActive(false);
        Appliances.SetActive(false);
    }
}
