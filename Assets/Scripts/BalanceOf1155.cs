using Assets.Scripts;
using DORA.Documents.Api.Extensions;
using System.Numerics;
using UnityEngine;

public class BalanceOf1155 : MonoBehaviour
{
    public GameObject sphere;
    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = ContractEnum.ERC1155.GetEnumDescription();
#if UNITY_EDITOR
        string account = "0xfF7BE45B7FeC2845bCD4368c130583312C87BBca";
#else
        string account = PlayerPrefs.GetString("Account");
#endif
        string tokenId = "603563865116060560926305792899920619944097728690633647694850460245753314334";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print("Balance Of ERC1155: " + balanceOf);
        if(balanceOf > 0)
        {
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }

    }
}
