using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_App
{
    class Blockchain 
    {
        public string[] transation;
        public List<Dictionary<string,string>> chain;
        // create the genesis block
        public void Create_Block(int _nonce,string _prevHash)
        {
            BlockFeats blockFeats = new BlockFeats();
            var block = new Dictionary<string, string>();
            block.Add("Timestamp", blockFeats.timestamp.ToString());
            block.Add("transactions", blockFeats.nonce.ToString());
            block.Add("Block_Number",((blockFeats.chain).Length+1).ToString());
            block.Add("Nonce", blockFeats.nonce.ToString());

            int length = blockFeats.transaction.Length;
            // now to empty the transactions done
            Array.Clear(blockFeats.transaction,0,length);

            // now to append the block to the chain
            chain.Add(block);
        }
    }
    class BlockFeats
    {
        public DateTime timestamp{ get; set; }
        public int nonce { get; set; }
        public string[] transaction { get; set; }
        public int[] chain { get; set; }
    }
}
