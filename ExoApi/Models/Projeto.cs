using System;

namespace ExoApi.Models
{
    // Model: representa a tabela Projetos do banco
    public class Projeto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string StatusProjeto { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Tecnologias { get; set; }
        public string Requisitos { get; set; }
        public string Area { get; set; }
    }
}
