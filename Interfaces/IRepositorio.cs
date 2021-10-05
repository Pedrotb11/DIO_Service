using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T> //quem for implementar essa interface vai poder usar o T, que é um tipo genérico.
    {
         List<T> Lista(); //Método lista, retorna lista de T
         T RetornaPorId(int id); // RetornaPorId recebe um Id e retorna um T
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}