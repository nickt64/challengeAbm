using Logic.Interfaces;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Servicios
{
    public class Mapper
    {
        public static UsuarioDto UsuarioUsuarioDto(Usuario usuario)
        {
            string estado = usuario.Borrado == false ? "activo" : "inactivo";

            var usuarioDto = new UsuarioDto()
            {
                Id = usuario.Id,
                Telefono = usuario.Telefono,
                UserName = usuario.UserName,
                Email = usuario.Email,
                Estado = estado,
                NombreCompleto = usuario.Nombre + " " + usuario.Apellido,
                Borrado = usuario.Borrado
            };

            return usuarioDto;
        }

        public static void NuevoUsuarioDtoToUsuario(Usuario usuario, NuevoUsuarioDto usuarioDto)
        {
            usuario.Nombre = usuarioDto.Nombre;
            usuario.Apellido = usuarioDto.Apellido;
            usuario.UserName = usuarioDto.UserName;
            usuario.Email = usuarioDto.Email;
            usuario.Telefono = usuarioDto.Telefono;
            usuario.Borrado = usuarioDto.Borrado;
        }

        public static void UsuarioToNuevoUsuarioDto(NuevoUsuarioDto usuarioDto, Usuario usuario)
        {
            usuarioDto.Id = usuario.Id;
            usuarioDto.Nombre = usuario.Nombre;
            usuarioDto.Apellido = usuario.Apellido;
            usuarioDto.UserName = usuario.UserName;
            usuarioDto.Email = usuario.Email;
            usuarioDto.Telefono = usuario.Telefono;
            usuarioDto.Borrado = usuario.Borrado;
        }

    }
}
