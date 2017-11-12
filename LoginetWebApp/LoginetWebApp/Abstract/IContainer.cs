namespace LoginetWebApp.Abstract
{
    public interface IContainer
    {
        IDataSource ResolveDataSource();
        IOptions ResolveoOptions();
    }
}