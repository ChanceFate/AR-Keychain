using UnityEngine;
using System.Collections;

public class SwitchImage : MonoBehaviour
{

    public Collider coll;
    public Renderer rend;

    private Material[] materials;
    private int index = 0;

    // Use this for initialization
    IEnumerator Start()
    {

#if UNITY_STANDALONE

        // load movietexture file
        WWW www = WWW.LoadFromCacheOrDownload("file://" + Application.dataPath + "/AssetBundles/movietexture.unity3d", 1);

        // Load and retrieve AssetBundle
        AssetBundle bundle = www.assetBundle;

        // Load movietexture asynchronously
        AssetBundleRequest request = bundle.LoadAssetAsync("123-Hic-4.mat", typeof(Material));

        // Wait for completion
        yield return request;

        // Get the reference to the loaded object
        Material movTexture = request.asset as Material;

        // set size of material array
        materials = new Material[3];

        // Assign materials from "Assets/Resources/" to the material array
        materials[0] = Resources.Load<Material>("Pirates!");
        materials[1] = Resources.Load<Material>("DrummerBoy");
        materials[2] = movTexture;

#elif UNITY_ANDROID

        // set size of material array
        materials = new Material[2];

        // Assign materials from "Assets/Resources/" to the material array
        materials[0] = Resources.Load<Material>("Pirates!");
        materials[1] = Resources.Load<Material>("DrummerBoy");

#endif

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

        Debug.Log(materials[matnum].name);

        rend.sharedMaterial = materials[matnum];
    }
}