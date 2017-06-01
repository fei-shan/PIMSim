﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePIM.Configs;

namespace SimplePIM.Procs
{
    public class PageConverter
    {
        public UInt64 page_size = 0;

        public UInt64 stride = 0;

      

        public Dictionary<UInt64, UInt64> page_table;
        public List<UInt64> frame;
        public UInt64 curr_fid;
        
        public PageConverter(bool random = false)
        {

            page_size = Config.page_size;
            if (!random)
            {
                stride = (UInt64)(Config.channel * Config.rank * Config.bank);

            }
            frame = new List<UInt64>();
            page_table = new Dictionary<UInt64, UInt64>();
        }


        public UInt64 scan_page(UInt64 addr_)
        {
            UInt64 page = addr_ / page_size;
            UInt64 offset = addr_ % page_size;

            if (page_table.ContainsKey(page))
            {
                //TLB HIT
                return page_table[page] * page_size + offset;
            }
            UInt64 index;
            index= page / stride;
            index *= stride;
            index += curr_fid;
            frame.Add(index);
            page_table.Add(page, index);

            curr_fid = (curr_fid + 1) % stride;

            return index * page_size + offset;

        }
    }
}
