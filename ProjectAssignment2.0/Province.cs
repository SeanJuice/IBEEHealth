using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAssignment2._0
{
    public class Province
    {
        private int provinceID;
        private string provinceName;

        public int ProvinceID
        {
            get
            {
                return provinceID;
            }

            set
            {
                provinceID = value;
            }
        }

        public string ProvinceName
        {
            get
            {
                return provinceName;
            }

            set
            {
                provinceName = value;
            }
        }
    }
}