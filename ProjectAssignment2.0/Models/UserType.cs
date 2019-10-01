using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAssignment2._0.Models
{
    public class UserType
    {
        private int mUserTypeID;
        private string mDescription;

        public int UserTypeID
        {
            get
            {
                return mUserTypeID;
            }

            set
            {
                mUserTypeID = value;
            }
        }

        public string Description
        {
            get
            {
                return mDescription;
            }

            set
            {
                mDescription = value;
            }
        }

        public UserType()
        {}

    }
}