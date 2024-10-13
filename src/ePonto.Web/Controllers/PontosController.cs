using ePonto.Features.ConsultaPontos;
using ePonto.Features.MarcacaoPontos;
using ePonto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ePonto.Controllers;

public class PontosController : Controller
{
    private readonly ConsultaPontosInterface _consultaPontosInterface;
    private readonly MarcacaoPontoInterface _marcacaoPontoInterface;

    public PontosController(
        ConsultaPontosInterface consultaPontosInterface,
        MarcacaoPontoInterface marcacaoPontoInterface)
    {
        _consultaPontosInterface = consultaPontosInterface;
        _marcacaoPontoInterface = marcacaoPontoInterface;
    }

    // GET: PontosController
    public async Task<ActionResult<PontosViewModel>> Index()
    {
        var request = new ConsultaPontosRequest();

        var response = await _consultaPontosInterface.ConsultaPontos(request);

        var model = new PontosViewModel();

        model.Pontos = response.Pontos;

        var result = View(model);

        return await Task.FromResult(result);
    }

    // GET: PontosController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: PontosController/Create
    public async Task<ActionResult<MarcacaoPontoViewModel>> MarcacaoPonto()
    {
        var model = new MarcacaoPontoViewModel();

        var result = View(model);

        return await Task.FromResult(result);
    }

    // POST: PontosController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Marcar(MarcacaoPontoFormModel model)
    {
        try
        {
            var request = new MarcacaoPontoRequest();

            var response = await _marcacaoPontoInterface.MarcaPonto(request);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
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
