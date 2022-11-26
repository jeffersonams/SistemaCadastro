using System.ComponentModel;

namespace SistemaDeTarefa.Enums
{
    public enum StatusTarefa
    {
        [Description("A Fazer")]
        AFazer = 1,

        [Description("Em Andamento")]
        EmAdamento = 2,

        [Description("Concluido")]
        Concluido = 3


    }
}
