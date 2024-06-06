namespace CarteiraDeJogosForms.Classes.Interfaces;

public interface IHttpClient
{
    Task<HttpResponseMessage> PostRequisition(string endPoint, object body);
    Task<HttpResponseMessage> PutRequisition(string endPoint, object body);
    Task<HttpResponseMessage> GetRequisition(string endPoint);
    Task<HttpResponseMessage> DeleteRequisition(string endPoint);
}