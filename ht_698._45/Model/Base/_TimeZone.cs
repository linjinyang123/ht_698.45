using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45.Model.Base
{
    public class _TimeZone
    {
        public int mday { get; set; }
        public int mMon { get; set; }
        public int mTimeIntervalNo { get; set; }
        public List<_TimeZone> getList(string strTimeZone, out bool result)
        {
            _TimeZone mTimeZone = new _TimeZone();
            result = true;
            List<_TimeZone> lstTimeZone = new List<_TimeZone>();
            try
            {
                var _TimeZones = strTimeZone.Split('#');
                foreach (string _TimeZone in _TimeZones)
                {
                    mTimeZone = new _TimeZone()
                    {
                        mMon = Convert.ToInt32(_TimeZone.Substring(0, 2)),
                        mday = Convert.ToInt32(_TimeZone.Substring(2, 2)),
                        mTimeIntervalNo = Convert.ToInt32(_TimeZone.Substring(4, 2)),
                    };
                    lstTimeZone.Add(mTimeZone);
                }
            }
            catch
            {
                result = false;
            }
            return lstTimeZone;
        }
    }
}