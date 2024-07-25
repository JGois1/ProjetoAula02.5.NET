﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Modelo de entidade
    /// </summary>
    public class Product
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        #endregion
    }
}
