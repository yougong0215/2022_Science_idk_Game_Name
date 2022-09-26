using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookLook : MonoBehaviour
{
    [SerializeField] GameObject[] Players;
    private Transform _player= null;
    public Transform Player
    {
        get
        {
            if(_player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return _player;
        }

    }
    float _offset;
    float _mins;
    float _shouderOffesetY;
    float _shouderOffesetZ;
    float _shouderMins;
    [SerializeField] float _originrayX;
    [SerializeField] float _originrayY;
    [SerializeField] float _sense = 1;

    void Update()
    {
        CameraAltitude();


    }

    void CameraAltitude()
    {


        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;


            return;
        }
        transform.localEulerAngles = new Vector3(_originrayX, _originrayY, 0);

        //Input.GetAxisRaw("CameraAltitude") / 20;


        //_mins -= (Input.GetAxisRaw("Mouse Y") / 100.0f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _originrayY += Input.GetAxisRaw("Mouse X") * _sense;


        _originrayX -= Input.GetAxisRaw("Mouse Y") * _sense;
        //_originrayX = Mathf.Lerp(-20, 90, _mins);
        //_originrayX = Mathf.Clamp(_originrayX, -20, 90);




        _mins = Mathf.Clamp(_mins, 0, 1);
        _offset = Mathf.Lerp(-2, 0, _mins);
        _offset = Mathf.Clamp(_offset, -2, 0);





    }
}
