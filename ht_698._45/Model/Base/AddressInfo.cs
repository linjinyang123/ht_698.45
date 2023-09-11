using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ht_698._45.Entity;
namespace ht_698._45.Model.Base
{
    public class AddressInfo
    {
        public string Address { get; set; }
        public void getAddress(out List<string> lstAddress)
        {
            lstAddress = new List<string>();
            AddressDao mAddressDao = new AddressDao();
            mAddressDao.GetBH(out lstAddress);
        }
    }
}