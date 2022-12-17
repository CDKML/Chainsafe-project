using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ImportNFTTexture : MonoBehaviour
{
    public class Response {
        public string image;
    }
    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = "0x76BE3b62873462d2142405439777e971754E8E77";
        string tokenId = "10299";

        // fetch uri from chain
        string uri = await ERC1155.URI(chain, network, contract, tokenId);
        print("uri: " + uri);

        // fetch json from uri
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        await webRequest.SendWebRequest();
        Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

        // parse json to get image uri
        string imageUri = data.image;
        print("imageUri: " + imageUri);
        if (imageUri.StartsWith("ipfs://"))
        {
            imageUri = imageUri.Replace("ipfs://", "https://ipfs.io/ipfs/");
        }
        Debug.Log("Revised URI: " + imageUri);
        // fetch image and display in game
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri);
        await textureRequest.SendWebRequest();
        gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
    }
}
