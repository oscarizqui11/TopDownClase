using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesCount : MonoBehaviour
{
    public HealthBehaviour _hb;
    public GameObject heartUI;
    public float offSetrX;
    public float offSetY;
    public float spaceBetween;

    public GameObject[] hearts;
    private int lifesUI;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = Instantiate(heartUI);
            hearts[i].transform.SetParent(transform);
            hearts[i].transform.position = transform.position;
            hearts[i].transform.localScale = transform.localScale;
            hearts[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(offSetrX + (hearts[i].GetComponent<RectTransform>().sizeDelta.x + spaceBetween) * i, offSetY);
        }

        UpdateHeartsUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifesUI != _hb.health)
        {
            UpdateHeartsUI();
        }
    }

    public void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < _hb.health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }

        lifesUI = _hb.health;
    }
}
