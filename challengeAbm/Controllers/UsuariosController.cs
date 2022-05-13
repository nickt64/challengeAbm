using Data.Interfaces;
using Logic.Interfaces;
using Logic.Servicios;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.ViewModels;

namespace challengeAbm.WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private IUsuariosServicios _usuariosServicio;

        public UsuariosController(IUsuariosServicios usuariosServicio)
        {
            _usuariosServicio = usuariosServicio;
        }

        public async Task<IActionResult> Index(bool? estado)
        {
            try
            {
                var usuarios = await _usuariosServicio.GetUsuarios(estado);

                var viewModel = new UsuarioVM
                {
                    ListaUsuarios = usuarios
                };

                return View(viewModel);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var usuario = await _usuariosServicio.Detalle(id);

                return View(usuario);
            }

            return View(new NuevoUsuarioDto());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NuevoUsuarioDto nuevoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (nuevoUsuario.Id > 0)
                    {
                        await _usuariosServicio.UpdateUsuario(nuevoUsuario);
                    }
                    else
                    {
                        await _usuariosServicio.InsertUsuario(nuevoUsuario);
                    }
                }

            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                await _usuariosServicio.Delete(id);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ReActivar(int id)
        {
            try
            {
                await _usuariosServicio.ReActivar(id);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
