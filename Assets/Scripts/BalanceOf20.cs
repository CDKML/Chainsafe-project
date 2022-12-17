using Assets.Scripts;
using DORA.Documents.Api.Extensions;
using System.Numerics;
using UnityEngine;

public class BalanceOf20 : MonoBehaviour
{
    public GameObject sphere;
    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = ContractEnum.ERC20.GetEnumDescription();
#if UNITY_EDITOR
        string account = "0x56b217cc582e19B3ca933Fd411E85ca7DeF68445";
#else
        string account = PlayerPrefs.GetString("Account");
#endif

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print("Balance ERC20: " + balanceOf);
        if (balanceOf > 0)
        {
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
}
