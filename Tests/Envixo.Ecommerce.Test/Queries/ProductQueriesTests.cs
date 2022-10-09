using System.Collections.Generic;
using System.Linq;
using Envixo.Ecommerce.App.Domain.Products;
using Envixo.Ecommerce.App.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Envixo.Ecommerce.Test.Queries;

[TestClass]
public class ProductQueriesTests
{
    private IList<Product> _products;
    public ProductQueriesTests()
    {
        var id = new Product();
        _products = new List<Product>();

        _products.Add(new Product("Produto 01", "Descrição 01", "Midia 01", true, 120, 10, "Tag 01", id.Category));
        _products.Add(new Product("Produto 02", "Descrição 02", "Midia 02", true, 120, 10, "Tag 01", id.Category));
        _products.Add(new Product("Produto 03", "Descrição 03", "Midia 03", true, 120, 10, "Tag 01", id.Category));
        _products.Add(new Product("Produto 04", "Descrição 04", "Midia 04", false, 120, 10, "Tag 01", id.Category));
        _products.Add(new Product("Produto 05", "Descrição 05", "Midia 05", true, 120, 10, "Tag 01", id.Category));
    }

    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
        Assert.AreEqual(result.Count(), 3);
    }

    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
        Assert.AreEqual(result.Count(), 2);
    }
}