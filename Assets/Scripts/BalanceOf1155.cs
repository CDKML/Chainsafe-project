using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class BalanceOf1155 : MonoBehaviour
{
    public GameObject sphere;
    async void Start()
    {
        string chain = "ethereum";
        string network = "goerli";
        string contract = "0x2c1867bc3026178a47a677513746dcc6822a137a";
#if UNITY_EDITOR
        string account = "0xd25b827D92b0fd656A1c829933e9b0b836d5C3e2";
#else
        string account = PlayerPrefs.GetString("Account");
#endif
        string tokenId = "0x01559ae4021aee70424836ca173b6a4e647287d15cee8ac42d8c2d8d128927e5";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);
        if(balanceOf > 1)
        {
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

    }
}
