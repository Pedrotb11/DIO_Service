using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie> //implementa uma interface IRepositorio da classe Serie, se tiveesse um repositorio de filme por exemplo eu criaria outra classe, talvez FilmeRepositorio, e faria do mesmo modo. o que está sendo passado aí ele vai substituir no T lá na interface IRepositorio. na hora de compilar ele vai substituir o <T> por <serie>.
    {
        private List<Serie> listaSerie = new List<Serie>(); //essa variavel instancia uma nova lista
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto; //quem chamar o atualiza vai passar um id e um objeto, e ele vai pegar o objeto e por naquela posicao do vetor.
        }

        public void Exclui(int id) // a gente tá considerando que o id é o índice do vetor
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id]; 
        }
    }
}