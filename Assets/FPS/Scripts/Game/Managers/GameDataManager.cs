using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public interface IManager
{
    public void Init();
}


public class CoreManager : IManager
{
    public void Init()
    {

    }
}
