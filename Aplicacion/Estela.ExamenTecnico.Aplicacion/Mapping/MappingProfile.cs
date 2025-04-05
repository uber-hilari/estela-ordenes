using AutoMapper;
using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Models.Requests;
using Estela.ExamenTecnico.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CrearProductoRq, Producto>();
            CreateMap<Producto, ProductoItemRp>()
                .ForMember(c => c.Id, x => x.MapFrom(v => v.Id.Cadena()));

            CreateMap<Orden, OrdenItemRp>()
                .ForMember(c => c.Id, x => x.MapFrom(v => v.Id.Cadena()));
            CreateMap<LineaOrden, LineaOrdenItemRp>()
                .ForMember(c => c.IdProducto, x => x.MapFrom(v => v.Producto.Id.Cadena()))
                .ForMember(c => c.Producto, x => x.MapFrom(v => v.Producto.Nombre));
        }
    }
}
