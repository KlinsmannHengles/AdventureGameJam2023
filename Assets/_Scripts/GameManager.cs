using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DAY { ONE, TWO, THREE}
public class GameManager : MonoBehaviour
{
    [SerializeField] private DAY day;

    // Start is called before the first frame update
    void Start()
    {
        day = DAY.ONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeToDay(DAY day)
    {
        switch (day)
        {
            case DAY.ONE:
                break;
            case DAY.TWO:
                break;
            case DAY.THREE:
                break;
        }
    }



}
