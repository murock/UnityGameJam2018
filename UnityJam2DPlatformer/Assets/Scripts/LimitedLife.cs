using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLife : MonoBehaviour {

    [SerializeField]
    private float lifeTime = 30f;

    public void Awake()
    {

    }

    public void startLife()
    {
        Debug.Log("Coroutine kicked off");
        StartCoroutine(DestroySelfAfterSeconds(lifeTime));
    }

    IEnumerator DestroySelfAfterSeconds(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Debug.Log("back in object pool");
        GameManager.Instance.Pool.ReleaseObject(this.gameObject);
    }
}
