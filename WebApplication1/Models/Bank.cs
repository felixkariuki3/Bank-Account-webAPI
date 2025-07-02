using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WebApplication1.Models
{
    public class Bank
    {
        [Key] 
       public int BankID { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public required string BankName { get; set; }
    }
}
