using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    // O SQLiteDatabaseHelper é uma classe auxiliar que fornece métodos para interagir com um banco de dados SQLite. Ele encapsula as operações de inserção, atualização, exclusão e consulta de registros na tabela Produto.
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        //Controla todo o CRUD do SQLite, ou seja, as operações de Create (Criar), Read (Ler), Update (Atualizar) e Delete (Excluir) em um banco de dados SQLite. Ele utiliza a biblioteca SQLite para realizar essas operações de forma assíncrona, permitindo que o aplicativo continue responsivo durante as operações de banco de dados.
        public SQLiteDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _connection.InsertAsync(p);// Retorna o número de linhas afetadas
        }

        
        public Task<List<Produto>> Update(Produto p) 
        {
            // O método UpdateAsync do SQLiteAsyncConnection é usado para atualizar um registro existente na tabela. Ele compara o objeto fornecido com os registros existentes usando a chave primária (Id) e atualiza os campos correspondentes.
            string sql = "UPDATE Produto SET Descricao = ?, preco = ?, Quantidade = ? WHERE Id = ?";

            // O método QueryAsync é usado para executar uma consulta SQL personalizada. Ele retorna uma lista de objetos do tipo especificado (neste caso, Produto) com base nos resultados da consulta. Os parâmetros fornecidos (p.Descricao, p.Preco, p.Quantidade, p.Id) são usados para preencher os valores na consulta SQL.
            return _connection.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.Quantidade, p.Id);
        }

        // O método DeleteAsync é usado para excluir um registro da tabela com base em uma condição especificada. Ele retorna o número de linhas afetadas pela operação de exclusão.
        public Task<int> Delete(int id)
        {
            // O método Table é usado para acessar a tabela Produto e o método DeleteAsync é chamado com uma expressão lambda que especifica a condição de exclusão (p => p.Id == id). Isso significa que o registro com o Id correspondente será excluído da tabela.
            return _connection.Table<Produto>().DeleteAsync(p => p.Id == id); // Retorna o número de linhas afetadas
        }

        public Task<List<Produto>> GetAll()
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string query)
        {
            // O método Search é usado para realizar uma consulta de pesquisa na tabela Produto com base em uma string de consulta fornecida. Ele constrói uma consulta SQL usando a cláusula LIKE para encontrar registros que correspondam à descrição do produto.
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%"+query+"%'";

            return _connection.QueryAsync<Produto>(sql);// Retorna uma lista de produtos que correspondem à consulta de pesquisa
        }

    }
}
