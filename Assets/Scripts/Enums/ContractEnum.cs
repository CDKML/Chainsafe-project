using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum ContractEnum
    {
        [Description("0xdAC17F958D2ee523a2206206994597C13D831ec7")]
        ERC20,
        
        [Description("0x60f80121c31a0d46b5279700f9df786054aa5ee5")]
        ERC721,

        [Description("0x2c1867bc3026178a47a677513746dcc6822a137a")]
        ERC1155
    }
}
