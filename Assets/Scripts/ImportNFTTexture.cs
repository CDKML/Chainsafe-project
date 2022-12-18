using Assets.Scripts;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ImportNFTTexture : MonoBehaviour
{
    public string chain = "ethereum";
    public string network = "goerli";
    public string contract = "0xe39883043563650dc0ad64377f8aa3fb539947e5";
    public string tokenId = "435";
    public ContractEnum ERCType = ContractEnum.ERC721;

    public class Response {
        public string image;
    }

    private async Task<string> GetUriAsync()
    {
        switch (ERCType)
        {
            case ContractEnum.ERC721:
                return await ERC721.URI(chain, network, contract, tokenId);
            case ContractEnum.ERC1155:
                return await ERC721.URI(chain, network, contract, tokenId);
            default:
                Debug.LogError("Unknown ERC type");
                return null;
        }
    }

    async void Start()
    {
        string uri = await GetUriAsync();
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
