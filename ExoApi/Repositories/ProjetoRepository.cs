using ExoApi.Contexts;
using ExoApi.Interfaces;
using ExoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExoApi.Repositories
{
    // Repositório: concentra o acesso ao banco de dados
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SqlContext _context;

        public ProjetoRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public bool Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);
            if (projetoBuscado == null) return false;

            projetoBuscado.Titulo = projeto.Titulo;
            projetoBuscado.StatusProjeto = projeto.StatusProjeto;
            projetoBuscado.DataInicio = projeto.DataInicio;
            projetoBuscado.Tecnologias = projeto.Tecnologias;
            projetoBuscado.Requisitos = projeto.Requisitos;
            projetoBuscado.Area = projeto.Area;

            _context.Projetos.Update(projetoBuscado);
            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);
            if (projetoBuscado == null) return false;

            _context.Projetos.Remove(projetoBuscado);
            _context.SaveChanges();
            return true;
        }
    }
}
