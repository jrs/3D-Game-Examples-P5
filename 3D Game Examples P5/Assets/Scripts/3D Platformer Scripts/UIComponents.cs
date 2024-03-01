using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIComponents : MonoBehaviour
{
    [SerializeField] private int _coinCount = 0;
    [SerializeField] private int _amountToOpenTheDoor = 2;
    [SerializeField] private TextMeshProUGUI _coinCountText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayCoinCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayCoinCount()
    {
        _coinCountText.text = "Coins: " + _coinCount.ToString();
    }

    public void UpdateCoinCount()
    {
        _coinCount++;
        DisplayCoinCount();

        if(_coinCount >= _amountToOpenTheDoor)
        {
            GameObject.Find("Door").GetComponent<Doors>().DoorCanBeOpened();
        }
    }
}
