using UnityEngine;
using System.Collections;

public class SwitchImage : MonoBehaviour
{

    public Material[] materials;
    public Collider coll;
    public Renderer rend;

    private int index = 0;

    // Use this for initialization
    void Start()
    {

        coll = GetComponent<Collider>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (materials.Length == 0)
            return;

#if UNITY_STANDALONE

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(coll.Raycast(ray,out hit,100F))
            {
                OnMouseDown();
            }
        }

#elif UNITY_ANDROID

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (coll.Raycast(ray, out hit, 100F))
                {
                    OnMouseDown();
                }
            }
        }

#endif

    }

    void OnMouseDown()
    {
        index++;        
        int matnum = (index/2) % (materials.Length);

        Debug.Log(matnum);

        rend.sharedMaterial = materials[matnum];
    }
}