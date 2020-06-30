using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace meii.Business.Entities.Enums
{
    public enum Bandeira
    {
        [Description("Visa")]
        visa,
        [Description("MasterCard")]
        masterCard,
        [Description("Elo")]
        elo,
    }
}
