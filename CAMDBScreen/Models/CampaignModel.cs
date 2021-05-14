using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMDBScreen.Models
{
    public class CampaignModel
    {
        public int row { get; set; }
        public string campaigncode { get; set; }
        public string campaigntype { get; set; }
        public string campaigndesc { get; set; }
        public string customertype { get; set; }
        public string benefit { get; set; }
        //public string perioddate { get; set; }
        public string status { get; set; }
        // public string campaigntype { get; set; }
        public string campaigntypedesc { get; set; }
       // public string benafit { get; set; }
        // public string customertype { get; set; }
        public string cardtype { get; set; }
        public string actiontype { get; set; }
        public decimal? bint { get; set; }
        public decimal? cru { get; set; }
        public decimal? bill { get; set; }
        public decimal? bday { get; set; }
        public string registerby { get; set; }
        public string approveby { get; set; }
        public string registerdate { get; set; }
        public string _registerdate { get; set; }
        public string updatedate { get; set; }
        public  string _updatedate { get; set; }
        public string perioddate { get; set; }
        public string _perioddate { get; set; }
        public string campaignstatus { get; set; }

        public decimal? withdrawamount { get; set; }
        public decimal? withinday { get; set; }
        public decimal? remainob { get; set; }
        public decimal? periodob { get; set; }
        public string processlabel { get; set; }
        public string lastdate { get; set; }
    }
}
