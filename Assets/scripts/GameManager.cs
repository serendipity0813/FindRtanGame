using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timeTxt;
    public Text countTxt;
    public GameObject endTxt;
    public GameObject card;
    float time;
    public static GameManager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioClip success;
    public AudioClip fail;
    public AudioClip open;
    public AudioSource audioSource;

    public bool limit_check = false;
    public int count = 0;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        countTxt.text = count.ToString();
    }


    public void IsMatched()
    {

        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        count++;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
            audioSource.PlayOneShot(success);

            int cardsLeft = GameObject.Find("cards").transform.childCount;

            if (cardsLeft < 3)
            {
                Time.timeScale = 0f;
                endTxt.SetActive(true);
            }
        }
        else
        {
            time = time + 0.5f;
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            audioSource.PlayOneShot(fail);
        }

        firstCard = null;
        secondCard = null;


    }

}