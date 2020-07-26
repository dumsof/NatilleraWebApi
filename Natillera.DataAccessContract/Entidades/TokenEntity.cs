using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Natillera.DataAccessContract.Entidades
{

    public class TokenEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenId { get; set; }

        public string UserId { get; set; }

        public string Token { get; set; }

        public DateTime FechaExpiraToken { get; set; }
    }
}
