﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePIM.General;

namespace SimplePIM.Memory
{
    public class MemRequest : Request
    {
        public UInt64 address;
        public UInt64 data;
        public UInt64 block_addr;
        public UInt64 ts_arrival = 0;
        public UInt64 ts_departure = 0;
        public UInt64 ts_issue = 0;
        public MemReqType memtype;
        public UInt64 cycle = 0;
        public bool pim = false;
        public int pid = 0;

        public MemRequest()
        {
            address = 0;
            data = 0;
            memtype = MemReqType.NULL;
        }

        public MemRequest(UInt64 address_, UInt64 data_,UInt64 block, MemReqType memtype_)
        {
            address = address_;
            data = data_;
            memtype = memtype_;
        }
    }
    
    public enum MemReqType
    {
        //basic memory requests
        READ,
        WRITE,
        RETURN_DATA,
        NULL
    }
}
