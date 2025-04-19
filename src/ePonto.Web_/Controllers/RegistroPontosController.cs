using ePonto.Features.BuscaContratos;
using ePonto.Features.GestaoContratos;
using ePonto.Features.RegistroPontos;
using ePonto.Models.RegistroPontos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ePonto.Controllers;

public class RegistroPontosController : Controller
{
    private readonly ConsultaPontosInterface _consultaPontosInterface;
    private readonly RegistroPontosInterface _registroPontosInterface;
    private readonly MarcacaoPontosInterface _marcacaoPontosInterface;
    private readonly ConsultaContratosInterface _consultaContratosInterface;
    private readonly BuscaContratosInterface _buscaContratosInterface;

    public RegistroPontosController(
        ConsultaPontosInterface consultaPontosInterface,
        RegistroPontosInterface registroPontosInterface,
        MarcacaoPontosInterface marcacaoPontosInterface,
        ConsultaContratosInterface consultaContratosInterface,
        BuscaContratosInterface buscaContratosInterface)
    {
        _consultaPontosInterface = consultaPontosInterface;
        _registroPontosInterface = registroPontosInterface;
        _marcacaoPontosInterface = marcacaoPontosInterface;
        _consultaContratosInterface = consultaContratosInterface;
        _buscaContratosInterface = buscaContratosInterface;
    }

    // GET: PontosController
    public async Task<ActionResult<IndexViewModel>> Index()
    {
        var request = new ConsultaPontosRequest();

        var response = await _consultaPontosInterface.ConsultarPontos(request);

        var model = new IndexViewModel();

        model.Pontos = response.Pontos.Select(x => new IndexViewModel.PontoViewModel
        {
            DataHora = x.DataHora,
            Observacao = x.Observacao
        }).ToArray();

        var result = View(model);

        return await Task.FromResult(result);
    }

    // GET: PontosController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: PontosController/Create
    public async Task<ActionResult<RegistrarViewModel>> Registrar()
    {
        var model = new RegistrarViewModel();

        model.Ponto = new RegistrarViewModel.PontoViewModel();

        var result = View(model);

        return await Task.FromResult(result);
    }

    // POST: PontosController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Registrar(RegistrarViewModel model)
    {
        try
        {
            var request = new RegistroPontoRequest();

            var response = await _registroPontosInterface.RegistrarPonto(request);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(model);
        }
    }

    public async Task<ActionResult<MarcarViewModel>> Marcar()
    {
        var model = new MarcarViewModel();

        model.Ponto = new MarcarViewModel.PontoViewModel();

        var result = View(model);

        return await Task.FromResult(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Marcar(MarcarViewModel model)
    {
        try
        {
            var request = new MarcacaoPontoRequest();

            var response = await _marcacaoPontosInterface.MarcarPonto(request);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(model);
        }
    }
    // GET: PontosController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: PontosController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PontosController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PontosController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
