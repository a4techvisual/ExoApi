using ExoApi.Models;
using System.Collections.Generic;

namespace ExoApi.Interfaces
{
    // Contrato do repositório: define as operações de CRUD
    public interface IProjetoRepository
    {
        List<Projeto> Listar();
        Projeto BuscarPorId(int id);
        void Cadastrar(Projeto projeto);
        bool Atualizar(int id, Projeto projeto);
        bool Deletar(int id);
    }
}
