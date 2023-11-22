using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{

    private int count;
    private float currentTime; // in seconds

    public TextMeshProUGUI countText;
    public TextMeshProUGUI currentTimeText;
    public GameObject winTextObject;

    public static GameManager Manager;



    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        winTextObject.SetActive(false);
        currentTime = 0;
        SetCurrentTimeText();
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetCurrentTimeText()
    {
        currentTimeText.text = "Chrono: " + currentTime.ToString("00.0");
    }

    public void Awake()
    {
        if(GameManager.Manager != null) { Destroy(this); }
        Manager = this;
    }


     public void Collect(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count = count + 1;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        SetCurrentTimeText();
    }
}
