using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;

namespace SportWord.Core.Application.UseCases
{
    public class ProductoCarritoUseCase : IDetailRepository<Productos, Guid>
    {
        private readonly IBaseRepository<Productos, Guid> productoRepository;
        private readonly IDetailRepository<Carrito_Productos, Guid> carritoProductoRepository;
        public ProductoCarritoUseCase(IBaseRepository<Productos, Guid> productoRepository, IDetailRepository<Carrito_Productos, Guid> carritoProductoRepository)
        {
            this.productoRepository = productoRepository;
            this.carritoProductoRepository = carritoProductoRepository;
        }

        public Productos Create(Productos productos)
        {
            var createdproducto = productoRepository.Create(productos);
            productos.carrito_productos.ForEach(detail =>
            {
                carritoProductoRepository.Create(detail);
            });
            return createdproducto;

        }

        public List<Productos> GetDetailsByTransaction(Guid trasactionId)
        {
            throw new NotImplementedException();
        }

        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }
    }
}
