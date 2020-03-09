using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour { 
    
    public enum State {OnFire, Idle};
    State currentState;
    public GameObject rubble;
    float percentage = 100f;

    float refreshRate = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireCheck()
    {
        if(currentState == State.OnFire)
        {
            percentage--;
            if(percentage <= 0)
            {
                Instantiate(rubble, transform.position, Quaternion.identity);
            }
        }

        yield return new WaitForSeconds(refreshRate);
    }

}
