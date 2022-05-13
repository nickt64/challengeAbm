using Data.Interfaces;
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
    public class UsuariosServicios : IUsuariosServicios
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuariosServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarios(bool? estado)
        {
            var listaUsuarios = estado != null
                ? await _unitOfWork.UsuarioRepository.ObtenerPorEstado(estado.Value)
                : await _unitOfWork.UsuarioRepository.GetAll();

            var usuariosDtos = new List<UsuarioDto>();

            foreach (var usuario in listaUsuarios)
            {
                usuariosDtos.Add(Mapper.UsuarioUsuarioDto(usuario));
            }

            return usuariosDtos;
        }

        public async Task<NuevoUsuarioDto> Detalle(int id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);

            var nuevoUsuario = new NuevoUsuarioDto();

            Mapper.UsuarioToNuevoUsuarioDto(nuevoUsuario, usuario);

            return nuevoUsuario;
        }

        public async Task InsertUsuario(NuevoUsuarioDto nuevoUsuario)
        {
            var usuario = new Usuario();

            Mapper.NuevoUsuarioDtoToUsuario(usuario, nuevoUsuario);

            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUsuario(NuevoUsuarioDto UsuarioEditado)
        {
            var usuarioBd = await _unitOfWork.UsuarioRepository.GetById(UsuarioEditado.Id);

            if (usuarioBd == null)
            {
                throw new Exception("Usuario no existe con el ID: " + UsuarioEditado.Id);
            }

            Mapper.NuevoUsuarioDtoToUsuario(usuarioBd, UsuarioEditado);

            _unitOfWork.UsuarioRepository.Update(usuarioBd);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {
            var entidad = await _unitOfWork.UsuarioRepository.GetById(id);

            if (entidad == null || entidad.Borrado == true)
            {
                throw new Exception("Usuario no existe con el ID: " + id);
            }

            _unitOfWork.UsuarioRepository.Delete(entidad);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ReActivar(int id)
        {
            var entidad = await _unitOfWork.UsuarioRepository.GetById(id);

            if (entidad == null || entidad.Borrado == false)
            {
                throw new Exception("Usuario no existe o ya esta activo, con el ID: " + id);
            }

            _unitOfWork.UsuarioRepository.ReActivar(entidad);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
