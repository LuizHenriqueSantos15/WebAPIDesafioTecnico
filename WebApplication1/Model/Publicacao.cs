using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Publicacao
    {
        public int Id { get; set; }
        public string Autor { get; set; }// o autor será um usuario logo salvarei o ID desse usuário.
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
