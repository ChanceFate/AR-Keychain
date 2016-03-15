using UnityEngine;
using System.Collections;

public class OpenPresent : MonoBehaviour
{

    public GameObject prefab;
    public Collider coll;

	// Use this for initialization
	void Start ()
    {

        coll = GetComponent<Collider>();

	}
	
	// Update is called once per frame
	void Update ()
    {

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

        if(Input.touchCount == 1)
        {
           if(Input.GetTouch(0).phase == TouchPhase.Began)
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
        GameObject obj = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        obj.transform.parent = this.transform.parent;
        gameObject.SetActive(false);
    }
}
