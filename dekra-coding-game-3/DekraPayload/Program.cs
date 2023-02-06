namespace DekraPayload;

public class Program
{
    public static void Main(string[] args)
    {

    }
}

public class MyPayload
{
    public string SomefilterableString { get; set; }
    public string SomeOtherString { get; set; }
}
public class MyObject
{
    public Guid TechnicalId { get; set; }
    public MyPayload Payload { get; set; }
}
public interface IMyObjectRepository
{
    List<MyObject> GetAll();
    MyObject GetById(Guid id);
    List<MyObject> GetByPredicate(Func<MyObject, bool> predicate);
}
public class MyService
{
    private IMyObjectRepository myRepo;
    public MyService(IMyObjectRepository repo)
    {
        myRepo = repo;
    }
    public List<MyPayload> GetAllMyPayloads(string filter)
    {
        // Lignes Corrigées
        //var values = myRepo.getAll();

        //var filteredList = new List<MyObject>;
        //var filteredList = new List<MyObject>();

        //foreach (var value in values)
        //{
        //    if (value.Payload.SomefilterableString == filter)
        //        filteredList.Add(value);
        //}

        var values = myRepo.GetAll();
        // Utilisation de Linq pour optimiser la requête
        var filteredList = values.Where(x => x.Payload.SomefilterableString == filter).ToList();

        var returnMyPayloadList = filteredList.Select(x => new MyPayload()
        {
            SomefilterableString = x.Payload.SomefilterableString,
            SomeOtherString = x.Payload.SomeOtherString
        }).ToList();

        return returnMyPayloadList;
    }
}