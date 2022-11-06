namespace ApiGest.Domain.Entities;
using ApiGest.Domain.Common.Models;

public class Product: IEntity{
    public string? Name {get; set;} 
    public string? ProductSKU {get; set;}
    public string? ProductCode {get; set;}
    public string? ProductClass {get; set;}
    public string? ProductType {get; set;} 
    public string? UnitOfMeasure {get; set;}
    public string? ExternalId {get; set;}
    public string? Status {get; set;}
    public int? Quantity {get; set;}
    public bool isActive {get; set;} 
}