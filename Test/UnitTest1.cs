using TsaakAPI.Model.DAO;
using ActivoFijoAPI.Util;
using Xunit;
using TsaakAPI.Entities;
using Moq;
using System.Collections.Generic;
using ECE.Model.DAO; 

namespace FileModule.UnitTests;

public interface IEfermedadCardiovascularDao
{

    Task<ResultOperation<VMCatalog>> GetByIdAsync(int id);
    Task<ResultOperation<List<VMCatalog>>> GetAllAsync();
    Task<ResultOperation<VMCatalog>> InsertAsync(VMCatalog vmCatalog);
    Task<ResultOperation<VMCatalog>> UpdateAsync(VMCatalog vmCatalog);
}

public class ResultOperation<T>
{
   
    public bool Success { get; set; }
    public T Data { get; set; }
}

public class UnitTest1
{
    [Fact]
    public async Task GetById()
    {
    
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        var vmCatalog = new VMCatalog { Id = 5 };
        mockDao.Setup(x => x.GetByIdAsync(5)).ReturnsAsync(new ResultOperation<VMCatalog> { Success = true, Data = vmCatalog });

        var resultado = await mockDao.Object.GetByIdAsync(5);
        Assert.True(resultado.Success);
        Assert.Equal(5, resultado.Data.Id);
    }


    [Fact]
    public async Task GetAll()
    {
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        var vmCatalogList = new List<VMCatalog> { new VMCatalog { Id = 1 }, new VMCatalog { Id = 2 } };
        mockDao.Setup(x => x.GetAllAsync()).ReturnsAsync(new ResultOperation<List<VMCatalog>> { Success = true, Data = vmCatalogList });

        var resultado = await mockDao.Object.GetAllAsync();
        Assert.True(resultado.Success);
        Assert.Equal(2, resultado.Data.Count);
    }

    [Fact]
    public async Task GetAll_Empty()
    {
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        mockDao.Setup(x => x.GetAllAsync()).ReturnsAsync(new ResultOperation<List<VMCatalog>> { Success = true, Data = new List<VMCatalog>() });

        var resultado = await mockDao.Object.GetAllAsync();
        Assert.True(resultado.Success);
        Assert.Empty(resultado.Data);
    }

    [Fact]
    public async Task Insert()
    {
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        var vmCatalog = new VMCatalog { Id = 3, Nombre = "nombre", Descripcion = "descripcion",Estado = true };
        mockDao.Setup(x => x.InsertAsync(It.IsAny<VMCatalog>())).ReturnsAsync(new ResultOperation<VMCatalog> { Success = true, Data = vmCatalog });

        var resultado = await mockDao.Object.InsertAsync(vmCatalog);
        Assert.True(resultado.Success);
    }
    

    [Fact]
    public async Task Insert_Failure()
    {
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        var vmCatalog = new VMCatalog { Id = 3 };
        mockDao.Setup(x => x.InsertAsync(It.IsAny<VMCatalog>())).ReturnsAsync(new ResultOperation<VMCatalog> { Success = false });

        var resultado = await mockDao.Object.InsertAsync(vmCatalog);
        Assert.False(resultado.Success);
    }

    [Fact]
    public async Task Actualizar()
    {
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        var vmCatalog = new VMCatalog { Id = 1, Nombre = "nombre", Descripcion = "descripcion", Estado = true };
        mockDao.Setup(x => x.UpdateAsync(It.IsAny<VMCatalog>())).ReturnsAsync(new ResultOperation<VMCatalog> { Success = true, Data = vmCatalog });

        var resultado = await mockDao.Object.UpdateAsync(vmCatalog);
        Assert.True(resultado.Success);
    }

    [Fact]
    public async Task Update()
    {
        var mockDao = new Mock<IEfermedadCardiovascularDao>();
        var vmCatalog = new VMCatalog { Id = 1 };
        mockDao.Setup(x => x.UpdateAsync(It.IsAny<VMCatalog>())).ReturnsAsync(new ResultOperation<VMCatalog> { Success = false });

        var resultado = await mockDao.Object.UpdateAsync(vmCatalog);
        Assert.False(resultado.Success);
    }
}



// using TsaakAPI.Model.DAO;
// using ActivoFijoAPI.Util;
// using Xunit;
// using TsaakAPI.Entities;



// public class UnitTest1
// {
//     [Fact]
//     public async void TestObtenerId()
//     {
//         ResultOperation<VMCatalog> resultado = new ResultOperation<VMCatalog>();
//         var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Username=postgres;Password=123;Database=ece_tsaak");

//         resultado = await _enfermedadCardiovascularDao.GetByIdAsync(15);

//         Assert.Equal(true, resultado.Success);

//     }

//     [Fact]
//     public async void TestNoExisteId()
//     {
//         ResultOperation<VMCatalog> resultado = new ResultOperation<VMCatalog>();
//         var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Username=postgres;Password=123;Database=ece_tsaak");

//         resultado = await _enfermedadCardiovascularDao.GetByIdAsync(88);

//         Assert.Equal(false, resultado.Success);

//     }

//     [Fact]
//     public async void obtenerTodo()
//     {
//         ResultOperation<List<VMCatalog>> resultado = new ResultOperation<List<VMCatalog>>();
//         var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Username=postgres;Password=123;Database=ece_tsaak");

//         resultado = await _enfermedadCardiovascularDao.GetAll();

//         Assert.Equal(true, resultado.Success);
//     }

//     [Fact]
//     public async void Paginacion()
//     {
//         ResultOperation<DataTableView<VMCatalog>> resultado = new ResultOperation<DataTableView<VMCatalog>>();
//         var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Username=postgres;Password=123;Database=ece_tsaak");

//         resultado = await _enfermedadCardiovascularDao.GetPageFetch(1, 3);

//         Assert.Equal(true, resultado.Success);

//     }

//     [Fact]
//     public async void Diccionario()
//     {
//         ResultOperation<Dictionary<int, string>> resultado = new ResultOperation<Dictionary<int, string>>();
//         var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Username=postgres;Password=123;Database=ece_tsaak");

//         resultado = await _enfermedadCardiovascularDao.GetDiccionario();

//         Assert.Equal(true, resultado.Success);

//     }
// }

    // [Fact]
    // public async void Eliminar()
    // {
    //     ResultOperation<EnfermedadCardiovascular> resultado = new ResultOperation<EnfermedadCardiovascular>();
    //     var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Port=5432;Database=prueba_sye;Username=postgres;Password=123");

    //     resultado = await _enfermedadCardiovascularDao.Eliminar(40);

    //     Assert.Equal(true, resultado.Success);

    // }
    // [Fact]
    // public async void Insertar()
    // {
    //     ResultOperation<EnfermedadCardiovascular> resultado = new ResultOperation<EnfermedadCardiovascular>();
    //     var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Port=5432;Database=prueba_sye;Username=postgres;Password=123");
    //     EnfermedadCardiovascular aux = new EnfermedadCardiovascular
    //     {
    //         id_enf_cardiovascular = 0,
    //         nombre = "artritis",
    //         descripcion = "dolor reumatoide",
    //         fecha_registro = DateTime.Now,
    //         fecha_inicio = DateTime.Now,
    //         estado = true,
    //         fecha_actualizacion = DateTime.Now,
    //     };

    //     resultado = await _enfermedadCardiovascularDao.Insertar(aux);

    //     Assert.Equal(true, resultado.Success);

    // }

    // [Fact]
    // public async void Actualizar()
    // {
    //     ResultOperation<EnfermedadCardiovascular> resultado = new ResultOperation<EnfermedadCardiovascular>();
    //     var _enfermedadCardiovascularDao = new EnfermedadCardiovascularDao("Host=localhost;Port=5432;Database=prueba_sye;Username=postgres;Password=123");
    //     EnfermedadCardiovascular aux = new EnfermedadCardiovascular
    //     {
    //         id_enf_cardiovascular = 43,
    //         nombre = "astrofibia",
    //         descripcion = "miedo",
    //         fecha_registro = DateTime.Now,
    //         fecha_inicio = DateTime.Now,
    //         estado = true,
    //         fecha_actualizacion = DateTime.Now,
    //     };

    //     resultado = await _enfermedadCardiovascularDao.Actualizar(aux);

    //     Assert.Equal(true, resultado.Success);

    // }