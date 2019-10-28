using Desafio.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Desafio.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("favoritos.sqlite");

            _conexao = new SQLiteConnection(caminho);

            _conexao.CreateTable<Favorita>();
        }

        public List<Favorita> ConsultarDados()
        {
            return _conexao.Table<Favorita>().ToList();
        }

        public Favorita ObterCidadePorId(int id)
        {
           return _conexao.Table<Favorita>().Where(x => x.id == id).FirstOrDefault();
        }

        public void SalvarFavorito(Favorita cidadeDados)
        {
            _conexao.Insert(cidadeDados);
        }

        public void RemoverFavoritos(Favorita favorita)
        {
            //_conexao.Delete(_conexao.Table<Favorita>().Where(x => x.id == favorita.id));
            _conexao.Execute("DELETE FROM Favorita WHERE ID = '" + favorita.id + "';");
        }
    }
}
