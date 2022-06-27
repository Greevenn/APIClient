using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;
namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class ProductoCarritoRepository : IDetailRepository<Carrito_Productos, Guid>
    {
        private DB db;
        public ProductoCarritoRepository(DB db)
        {
            this.db = db;
        }

        public Carrito_Productos Create(Carrito_Productos entity)
        {
            db.carrito_productos.Add(entity);
            return entity;
        }

        public List<Carrito_Productos> GetDetailsByTransaction(Guid trasactionId)
        {
           var selectedcarrito = db.carrito_productos
                .Where(p => p.producto_id == trasactionId)
                .ToList();
            return selectedcarrito;
        }

        public void saveAllChanges()
        {
            db.SaveChanges(); //salvar todo
        }
        public void Cancelar(Guid trasactionId)
        {
            var selectedcarrito = GetDetailsByTransaction(trasactionId);
            if (selectedcarrito != null)
            {
                selectedcarrito.ForEach(detail =>
                {
                    db.carrito_productos.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se ha encontrado producto para eliminar");
        }
    }
}
