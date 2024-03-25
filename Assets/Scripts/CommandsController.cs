using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void HandleAnthem(List<Quadrant> l_e_quadrants)
    {
        if(l_e_quadrants[0] == Quadrant.HighLeftQuadrant && l_e_quadrants[1] == Quadrant.HighLeftQuadrant)
        {
            if(l_e_quadrants[2] == Quadrant.HighRightQuadrant && l_e_quadrants[3] == Quadrant.LowRightQuadrant)
            {
                AttackCommand();
            }
            else {
                ForwardCommand();
            }
        }
        else{
            if(l_e_quadrants[2] == Quadrant.HighRightQuadrant && l_e_quadrants[3] == Quadrant.LowRightQuadrant)
            {
                DefenseCommand();
            }
            else {
                RetreatCommand();
            }
        }
    }
    void AttackCommand()
    {
        Debug.Log("Attack!");
    }
    void DefenseCommand()
    {
        Debug.Log("Defense!");
    }
    void ForwardCommand()
    {
        Debug.Log("Forward!");
    }
    void RetreatCommand()
    {
        Debug.Log("Retreat!");
    }
}
