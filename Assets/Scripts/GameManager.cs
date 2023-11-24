using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour{

    private int count;
    private float currentTime; // in seconds

    public TextMeshProUGUI countText;
    public TextMeshProUGUI currentTimeText;
    public GameObject winTextObject;

    public static GameManager Manager;
    public List<ZoneManager> Zones;
    public int currentZone;



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
        if (Zones.Count < currentZone+1)
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
            Zones[currentZone].CollectibleCount -= 1;
            count = count + 1;
            other.gameObject.SetActive(false);
            if (Zones[currentZone].CollectibleCount== 0){
                Zones[currentZone].Door.SetActive(false);
                currentZone++;
            }
            SetCountText();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        SetCurrentTimeText();
    }
}
