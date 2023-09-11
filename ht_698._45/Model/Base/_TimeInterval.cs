using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45.Model.Base
{
    public class _TimeInterval
    {
        public int mHour { get; set; }
        public int mMiu { get; set; }
        public int mRate { get; set; }
        public List<_TimeInterval> getList(string strTimeInterval, out bool result)
        {
            _TimeInterval mTimeInterval = new _TimeInterval();
            result = true;
            List<_TimeInterval> lstTimeInterval = new List<_TimeInterval>();
            try
            {
                var _TimeZones = strTimeInterval.Split('#');
                foreach (string _TimeZone in _TimeZones)
                {
                    mTimeInterval = new _TimeInterval()
                    {
                        mHour = Convert.ToInt32(_TimeZone.Substring(0, 2)),
                        mMiu = Convert.ToInt32(_TimeZone.Substring(2, 2)),
                        mRate = Convert.ToInt32(_TimeZone.Substring(4, 2)),
                    };
                    lstTimeInterval.Add(mTimeInterval);
                }
            }
            catch
            {
                result = false;
            }
            return lstTimeInterval;
        }
    }
}