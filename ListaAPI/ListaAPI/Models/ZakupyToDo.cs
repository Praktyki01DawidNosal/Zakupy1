using System.ComponentModel.DataAnnotations;

namespace ListaAPI.Models
{
    public class ZakupyToDo
    {
        [ Key ]
        
        public int Id { get; set; }
        public string? ZakupyToDoName { get; set; }
    }
}
