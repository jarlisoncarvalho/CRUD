using System.Globalization;
using Crud.Enums;


namespace Crud.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public StatusTarefa Status{ get; set; }
    }
}
