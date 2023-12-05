using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public enum BirdState
    {
        Waiting,
        BeforeShoot,
        AfterShoot
    }
    public BirdState state = BirdState.BeforeShoot;
    //等待 发射前 发射后
    private bool isMouseDown = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShoot:
                MoveControl();
                break;
            case BirdState.AfterShoot:
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        if(state ==BirdState.BeforeShoot)
        {
            isMouseDown = true;
        }
    }
    private void OnMouseUp()
    {
        if(state == BirdState.BeforeShoot)
        {
            isMouseDown = false;
        }
    }
    private void MoveControl()
    {
        if(isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }
    private Vector3 GetMousePosition()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        return mp;
    }
}
