using Assets.Scripts;
using DORA.Documents.Api.Extensions;
using System.Numerics;
using UnityEngine;

public class BalanceOf721 : MonoBehaviour
{
    public GameObject sphere;
    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = ContractEnum.ERC721.GetEnumDescription();
#if UNITY_EDITOR
        string account = "0x60F80121C31A0d46B5279700f9DF786054aa5eE5";
#else
        string account = PlayerPrefs.GetString("Account");
#endif

        int balance = await ERC721.BalanceOf(chain, network, contract, account);
        print("Balance Of ERC721: " + balance);
        if(balance > 0)
        {
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

    }
}
