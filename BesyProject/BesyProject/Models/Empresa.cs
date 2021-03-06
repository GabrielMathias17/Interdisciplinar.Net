﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BesyProject.Models
{
    public class Empresa
    {
        public long EmpresaId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "O nome tem que estar entre  2-255 caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public long Telefone { get; set; }
        public long Cnpj { get; set; }
        public string Especialidade { get; set; }
        [Required]
        public long? ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}