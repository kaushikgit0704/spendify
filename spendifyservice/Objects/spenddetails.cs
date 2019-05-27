using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spendifyservice.Objects
{
    public class spenddetails
    {
        private int _id;
        private string _spenderName;
        private string _spendDescription;
        private decimal _spendAmount;
        private DateTime _spenddate;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string spenderName
        {
            get
            {
                return _spenderName;
            }
            set
            {
                _spenderName = value;
            }
        }

        public string spendDescription
        {
            get
            {
                return _spendDescription;
            }
            set
            {
                _spendDescription = value;
            }
        }

        public decimal spendAmount
        {
            get
            {
                return _spendAmount;
            }
            set
            {
                _spendAmount = value;
            }
        }

        public DateTime spenddate
        {
            get
            {
                return _spenddate;
            }
            set
            {
                _spenddate = value;
            }
        }
    }
}