using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Item
    {
        public string strOAD { get; set; }
        public string itemName { get; set; }
        public int itemOrder { get; set; }
        public string itemValue { get; set; }
        public string itemMode { get; set; }
        public string itemAgreement { get; set; }
        public string mComName { get; set; }
        public OAD mOAD { get; set; }

        public int encryptTypeNo { get; set; }
        public Item()
        { }
    }
}