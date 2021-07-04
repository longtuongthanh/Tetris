using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectComponent : MonoBehaviour
{
    public void DestoryAfterAnimation()
    {
        Destroy(this.gameObject);
    }
}
