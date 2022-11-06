namespace ApiGest.Domain.Entities;
using ApiGest.Domain.Common.Models;

public class Supplier: IEntity{
    public String? Name {get; set;}
    public DateTime? ContractDate {get; set;}
    public DateTime LastDelivery {get; set;}
}