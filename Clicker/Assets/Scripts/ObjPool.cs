using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class ObjPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T[] mOriginArr;
    private List<T>[] mPool;

    void Start()
    {
        PoolSetup();
    }

    public T GetFromPool(int id)
    {
        for(int i= 0; i < mPool[id].Count; i++)
        {
            if(!mPool[id][i].gameObject.activeInHierarchy)
            {
                mPool[id][i].gameObject.SetActive(true);
                return mPool[id][i];
            }
        }
        return GetNewObj(id);
    }

    protected void PoolSetup()
    {
        mPool = new List<T>[mOriginArr.Length];
        for (int i = 0; i < mPool.Length; i++)
        {
            mPool[i] = new List<T>();
        }
    }

    protected virtual T GetNewObj(int id)
    {
        T newObj = Instantiate(mOriginArr[id]);
        mPool[id].Add(newObj);
        return newObj;
    }
}