
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    public GameObject[] cars;
    public Button next;
    public Button prev;

    public GameManager gameManager;

    [HideInInspector]
    public int index;
   

    private void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        for(int i =0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);    
        }

    }

    private void Update()
    {
        if(index >= cars.Length-1)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }

        if(index <= 0)
        {
            prev.interactable = false;
        }
        else
        {
            prev.interactable=true;
        }
    }

    public void Next()
    {
        index++;
        for(int i=0; i < cars.Length;i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }
       
    }
    public void Prev()
    {
        index--;
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }
      
    }

    public void Play()
    {
        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
        gameManager.index = index;
        Debug.Log("CarSelector Index:" + index);
        Debug.Log("gameManager Index:" + index);

        SceneManager.LoadSceneAsync("Level01");
    }
}
