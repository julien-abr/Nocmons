using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLightingManager : MonoBehaviour
{
    [ContextMenu("test moi cette merde")]
    public void AmbiantColorIsChanging()
    {
        //test
        RenderSettings.ambientEquatorColor = Color.red;
    }

}
