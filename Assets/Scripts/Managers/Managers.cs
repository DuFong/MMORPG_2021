using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { if (s_instance == null) Init(); return s_instance; } }

    InputManager _inputManager = new InputManager();
    ResourceManager _resourceManager = new ResourceManager();

    public static InputManager Input { get { return Instance._inputManager; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _inputManager.OnUpdate();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject managers = GameObject.Find("@Managers");
            if(managers == null)
            {
                managers = new GameObject("@Managers");
                managers.AddComponent<Managers>();
            }
            s_instance = managers.GetComponent<Managers>();
        }
    }
}
