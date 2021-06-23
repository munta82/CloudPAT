using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Models.ViewModels
{
    public class PPATViewModel
    {        
        public string Pscode { get; set; }
        public string Psname { get; set; }
        public string VillageCode { get; set; }
        public string MandalCode { get; set; }
        public string Accode { get; set; }
        public string Pccode { get; set; }
        public string StateCode { get; set; }
        public string IsActive { get; set; }

        public string Ifcode { get; set; }
        public string Ifname { get; set; }

        public string PpatPifcode { get; set; }
        public string PpatPifname { get; set; }

        public string PpatPrfcode { get; set; }
        public string PpatPrfname { get; set; }

        public string PpatSfcode { get; set; }
        public string PpatSfname { get; set; }

        public string PpatVpfcode { get; set; }
        public string PpatVpfname { get; set; }

        public string SubCasteCode { get; set; }
        public string SubCasteName { get; set; }
        public string CommunityCode { get; set; }

        public string UserDisplayName { get; set; }
        public string UserMobile { get; set; }
        public string Occupation { get; set; }
        public string EducationCode { get; set; }
        public string Remarks { get; set; }
        public string MeasureAppCode { get; set; }
        public string MeasureAppName { get; set; }
    }
}
