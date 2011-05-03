using System.ComponentModel;

namespace ISIS
{
    public enum CourseTypes
    {

        [Description("Continuing Education WECM")]
        CWECM = 1,

        [Description("Continuing Education")]
        CE = 2,

        [Description("General Academic")]
        ACAD = 3,

        [Description("Regular Technical")]
        TECH = 4,

        [Description("Technical in WECM")]
        WECM = 5,

        [Description("Non-funded")]
        NF = 6,

        [Description("Non-reported Lab Course")]
        NLAB = 7,

        [Description("Non-funded developmental")]
        NFDEV = 8,

        [Description("Non-funded ROTC")]
        NROTC = 9,

        [Description("Exempt from Rider 50")]
        R50 = 10,

        [Description("Virtual College")]
        VCT = 11,

        [Description("Honors")]
        HONOR = 12

    }
}
