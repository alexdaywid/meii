using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace meii.Business.Entities.Enums
{
    public enum Situacao
    {
        [Description("Pedente")]
        pedente,
        [Description("Cancelado")]
        cancelado,
        [Description("Finalizado")]
        finalizado
    }
}
