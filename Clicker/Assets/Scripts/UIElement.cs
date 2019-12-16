using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class UIElement : MonoBehaviour
{
    [SerializeField] private Image mIcon;
    [SerializeField] private Text mNameText, mLevelText, mContentsText, mPurchaseText, mCostText;
    [SerializeField] private Button mPurchaseButton;
    private int mID;

    public void Init(AnimHash.TowIntPramCallback callback)
    {
        mPurchaseButton.onClick.AddListener( () => { callback(mID, 1); } );
    }
}
