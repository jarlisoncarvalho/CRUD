using System.ComponentModel;

namespace Crud.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        Emandamento = 2,
        [Description("Concluido")]
        Concluido = 3,

    }
}
