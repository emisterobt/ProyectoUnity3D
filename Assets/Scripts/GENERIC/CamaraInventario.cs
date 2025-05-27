using System.Collections.Generic;
using UnityEngine;

public class CamaraInventario : MonoBehaviour
{
    [SerializeField] private Camera currentCamera;
    public int index;
    public  List<Camera> cameras= new List<Camera>();

    private void Start()
    {
        currentCamera = cameras[0];
        cameras[index].transform.parent.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            index = index < cameras.Count -1 ? index + 1 : 0;
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].transform.parent.gameObject.SetActive(i == index);
            }

            currentCamera = cameras[index];
        }
    }




}
