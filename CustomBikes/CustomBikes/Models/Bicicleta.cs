using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomBikes.Models
{
    public class Bicicleta
    {
        public int BicicletaID { get; set; }
        [Required, StringLength(30)]
        public string Nome { get; set; }

        public int AroID { get; set; }
        public virtual Aro _Aro { get; set; }

        public int BancoID { get; set; }
        public virtual Banco _Banco { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria _Categoria { get; set; }

        public int GuidaoID { get; set; }
        public virtual Guidao _Guidao { get; set; }

        public int PneuID { get; set; }
        public virtual Pneu _Pneu { get; set; }

        public int QuadroID { get; set; }
        public virtual Quadro _Quadro { get; set; }
    }
}