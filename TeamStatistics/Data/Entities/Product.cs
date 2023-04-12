using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.Data.Entities
{
    public enum ProductEnum
    {
        CARA = 1, CM, CRT, EPMM, PPS, PFS, SMARTonFHIR, AvailabilityAPI, ReferralAPI, Cognito, Launcher, Dynatrace, Other
    };

    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";
    }
}
