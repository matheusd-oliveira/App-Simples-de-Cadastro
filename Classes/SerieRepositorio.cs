

public class SerieRepositorio : IRepositorio<Series>
{   

    private List<Series> listaSerie = new List<Series>();

    public void Atualiza(int id, Series objeto)
    {
        listaSerie[id] = objeto;
    }

    public void Exclui(int id)
    {
        listaSerie[id].excluir();
    }

    public void Insere(Series objeto)
    {
        listaSerie.Add(objeto);
    }

    public List<Series> List()
    {
        return listaSerie;
    }

    public int ProximoId()
    {
        return listaSerie.Count;
    }

    public Series RetornaPorId(int id)
    {
        return listaSerie[id];
    }
}